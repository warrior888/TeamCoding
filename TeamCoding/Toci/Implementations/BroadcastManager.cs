using System;
using System.Collections.Generic;
using System.IO;
using EnvDTE;
using Toci.Piastcode.Social.Client;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace TeamCoding.Toci.Implementations
{
    public class BroadcastManager
    {
        protected SocketClientManager ScManager;
        protected ProjectFileManager PfManager;
        protected DTE Dte;
        

        public BroadcastManager()
        {

            //todo: instead of ip address we should use for example: TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIPAddress
            //            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP 
            //            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerPort

            //"92.222.71.194" 25016
            if (TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP != null)
            {
                ScManager = new SocketClientManager(
                    TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP,
                    TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerPort,
                    new Dictionary<ModificationType, Action<IItem>>
                    {
                        {ModificationType.Add, AddItem},
                        {ModificationType.Edit, EditItem},
                    });
                ScManager.StartClient();
                PfManager = new ProjectFileManager();
            }
        }

        public virtual void SetDte(DTE dte)
        {
            Dte = dte;
        }

        
        public virtual void Broadcast(TcProjectItemsCollection collection)
        {
            foreach (var item in collection)
            {
                ScManager.BroadCastFile(item);
            }
        }

        protected virtual void AddItem(IItem item)
        {
            TcProjectItem prItem = item as TcProjectItem;

            PfManager.AddNewFile(prItem, Dte);

            //Dte.ActiveDocument.Name
        }

        protected virtual void EditItem(IItem item)
        {
            TcEditedProjectItem editedProjectItem = item as TcEditedProjectItem;
            PfManager.EditItem(editedProjectItem.FilePath, editedProjectItem);
        }
    }
}