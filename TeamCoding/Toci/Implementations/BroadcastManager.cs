﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using EnvDTE;
using Microsoft.VisualStudio.Text;
using TeamCoding.Toci.Pentagram.Implementations;
using TeamCoding.Toci.Pentagram.Interfaces;
using TeamCoding.VisualStudio;
using Toci.Common.Extensions.Network;
using Toci.Piastcode.Social.Client;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Ptc.Projects.Documents;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Server;

namespace TeamCoding.Toci.Implementations
{
    public abstract class BroadcastManager : SocketClientManager
    {
        protected EnvOpenedFilesManager EnvironmentOpenedFilesManager;
        protected VisualStudioClient VsClient;

        protected static ProjectFileManager PfManager = new ProjectFileManager();
        protected static DTE Dte;
        public static bool IsRunning;

        protected BroadcastManager() : base(TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP)
        {
            //todo: instead of ip address we should use for example: TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIPAddress
            //            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerIP 
            //            TeamCodingPackage.Current.Settings.SharedSettings.ChangePropagationServerPort

            //"92.222.71.194" 25016

            //"54.36.98.229"
            EnvironmentOpenedFilesManager = TeamCodingPackage.Current.EnvironmentOpenedFilesManager;
            VsClient = new VisualStudioClient();

            CreateSocket(ServerIp);


            Task.Factory.StartNew(() => ReceiveBroadcastedDocument(CoreUser.UserSocket.ReceiveFromSocket()));
        }

        protected virtual void ReceiveBroadcastedDocument(byte[] data)
        {
            VsFileDocument document = (VsFileDocument)GetServer().Receive(data);

            EnvOpenedFilesManager.SynContext.Post(new SendOrPostCallback(o => UpdateDocumentChange(document)), null);
            //UpdateDocumentChange(document);
        }

	    public virtual void SetDte(DTE dte)
        {
            Dte = dte;
        }

        public virtual void Broadcast(IVsDocument item)
        {
            VsClient.Send(item); // send my change to the central server
        }

        protected static void AddItem(IItem item)
        {
            TcProjectItem prItem = item as TcProjectItem;

            PfManager.AddNewFile(prItem, Dte);

            //Dte.ActiveDocument.Name
        }

		private static void OverwriteItem(IItem item)
		{
			TcEditedProjectItem editedProjectItem = item as TcEditedProjectItem;
			PfManager.OverwriteItem(editedProjectItem.FilePath, editedProjectItem);
		}

        protected virtual bool UpdateDocumentChange(VsFileDocument document)
        {
            foreach (var editChange in document.Changes)
            {
                TeamCodingTextViewConnectionListener.IsEditPending = true;
                //EnvironmentOpenedFilesManager.GetEnvOpenedFile(filePath).Insert(editChange.PositionStart, editChange.Text);
                EnvironmentOpenedFilesManager.GetEnvOpenedFile(editChange.FilePath)
                    .Replace(new Span(editChange.PositionStart, editChange.OldPositionEnd - editChange.PositionStart), editChange.Text);
                TeamCodingTextViewConnectionListener.IsEditPending = false;
                //Dispatcher.CurrentDispatcher.Invoke(() => EnvironmentOpenedFilesManager.GetEnvOpenedFile(filePath).Insert(editChange.Position, editChange.Text));
            }

            return true;
        }
    }
}