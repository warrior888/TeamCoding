using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows;
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
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP);

            if (reply?.Status != IPStatus.Success)
            {
                return;
            }

            //todo: instead of ip address we should use for example: TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIPAddress (contains ip address and port)
            //            "92.222.71.194" 25016
            //            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP 
            //            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerPort 

            ScManager = new SocketClientManager("92.222.71.194", 25016,
                new Dictionary<ModificationType, Action<IItem>>
                {
                        {ModificationType.Add, AddItem},
                        {ModificationType.Edit, EditItem},
                });
            ScManager.StartClient();
            PfManager = new ProjectFileManager();
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