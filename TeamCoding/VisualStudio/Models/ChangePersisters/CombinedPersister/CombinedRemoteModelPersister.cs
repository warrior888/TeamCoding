﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCoding.Documents;

namespace TeamCoding.VisualStudio.Models.ChangePersisters.CombinedPersister
{
    public class CombinedRemoteModelPersister : IRemoteModelPersister
    {
        private readonly IRemoteModelPersister[] RemoteModelPersisters;
        private IRemotelyAccessedDocumentData[] CachedOpenFiles = null;
        public event EventHandler RemoteModelReceived
        {
            add
            {
                foreach (var remoteModelPersister in RemoteModelPersisters)
                {
                    remoteModelPersister.RemoteModelReceived += value;
                }
            }
            remove
            {
                foreach (var remoteModelPersister in RemoteModelPersisters)
                {
                    remoteModelPersister.RemoteModelReceived -= value;
                }
            }
        }
        public IEnumerable<IRemotelyAccessedDocumentData> GetOpenFiles()
        {
            if (CachedOpenFiles != null)
            {
                return CachedOpenFiles;
            }
            else
            {
                return CachedOpenFiles = RemoteModelPersisters.SelectMany(rmp => rmp.GetOpenFiles().ToArray()).GroupBy(scdd => new
                {
                    scdd.Repository,
                    scdd.RepositoryBranch,
                    scdd.RelativePath,
                    scdd.IdeUserIdentity.Id,
                    scdd.IdeUserIdentity,
                    scdd.DocumentChangesInfo

                }).Select(g => new RemotelyAccessedDocumentData()
                {
                    Repository = g.Key.Repository,
                    RepositoryBranch = g.Key.RepositoryBranch,
                    RelativePath = g.Key.RelativePath,
                    IdeUserIdentity = g.Key.IdeUserIdentity,
                    HasFocus = g.Any(scdd => scdd.HasFocus),
                    BeingEdited = g.Any(scdd => scdd.BeingEdited),
                    CaretPositionInfo = g.FirstOrDefault(scdd => scdd.CaretPositionInfo != null)?.CaretPositionInfo,
                    DocumentChangesInfo = g.Key.DocumentChangesInfo
                }).ToArray();
            }
        }
        public IEnumerable<(string UserId, SessionInteractions Interaction)> UserIdsWithSharedSessionInteractionsToLocalUser() => 
            RemoteModelPersisters.SelectMany(rmp => rmp.UserIdsWithSharedSessionInteractionsToLocalUser()).Distinct();

        public CombinedRemoteModelPersister(params IRemoteModelPersister[] remoteModelPersisters)
        {
            RemoteModelPersisters = remoteModelPersisters;
            foreach(var remoteModelPersister in RemoteModelPersisters)
            {
                remoteModelPersister.RemoteModelReceived += RemoteModelPersister_RemoteModelReceived;
            }
        }
        private void RemoteModelPersister_RemoteModelReceived(object sender, EventArgs e)
        {
            CachedOpenFiles = null;
        }
        public void Dispose()
        {
            foreach(var remoteModelPersister in RemoteModelPersisters)
            {
                remoteModelPersister.RemoteModelReceived -= RemoteModelPersister_RemoteModelReceived;
                remoteModelPersister.Dispose();
            }
        }

        protected virtual IRemotelyAccessedDocumentData SelectRemotelyAccessedDocumentData(IRemotelyAccessedDocumentData input)
        {
            return null;
        }
    } 
}
