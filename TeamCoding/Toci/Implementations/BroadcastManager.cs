using System;
using System.Collections.Generic;
using System.IO;
using EnvDTE;
using TeamCoding.Toci.Pentagram.Implementations;
using TeamCoding.Toci.Pentagram.Interfaces;
using Toci.Piastcode.Social.Client;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Piastcode.Social.Sockets.Interfaces;
using Toci.Ptc.Broadcast;

namespace TeamCoding.Toci.Implementations
{
    public class BroadcastManager : SocketClientManager
    {
        protected static ProjectFileManager PfManager = new ProjectFileManager();
        protected static DTE Dte;
        public static bool IsRunning;
        IVsFileTcManager vsFileTcManager = new VsFileTcManager();

        public void StartSCMClient()
        {
            CreateSocket(ServerIp);
            //new VsFileTcManager().Connect(new TeamCodingUser {  });
        }

        //TODO: need method to Stop ScManager

        public static void StopSCMClient()
        {

        }

        public BroadcastManager() : base(
            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP, 
            new Dictionary<ModificationType, Action<IItem>>
            {
                {ModificationType.Add, AddItem},
                {ModificationType.Edit, EditItem},
                {ModificationType.Overwrite, OverwriteItem}
            })
        {
            //todo: instead of ip address we should use for example: TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIPAddress
            //            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP 
            //            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerPort

            //"92.222.71.194" 25016

                //"54.36.98.229"
      
        }


	    public virtual void SetDte(DTE dte)
        {
            Dte = dte;
        }


        public virtual void Broadcast(TcProjectItemsCollection collection)
        {
            foreach (var item in collection)
            {
                //ScManager.BroadCastFile(item);
            }
        }

        protected static void AddItem(IItem item)
        {
            TcProjectItem prItem = item as TcProjectItem;

            PfManager.AddNewFile(prItem, Dte);

            //Dte.ActiveDocument.Name
        }

        protected static void EditItem(IItem item)
        {
            TcEditedProjectItem editedProjectItem = item as TcEditedProjectItem;
            PfManager.EditItem(editedProjectItem.FilePath, editedProjectItem);
        }

		private static void OverwriteItem(IItem item)
		{
			TcEditedProjectItem editedProjectItem = item as TcEditedProjectItem;
			PfManager.OverwriteItem(editedProjectItem.FilePath, editedProjectItem);
		}
	}
}