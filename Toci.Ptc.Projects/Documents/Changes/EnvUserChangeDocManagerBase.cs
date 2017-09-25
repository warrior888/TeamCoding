using System.Collections.Generic;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Projects.Interfaces.Managers;

namespace Toci.Ptc.Projects.Documents.Changes
{
    public abstract class EnvUserChangeDocManagerBase<TEnvironment, TUser, TChange, TDocument> : IEnvUserChangeDocManager<TEnvironment, TUser, TChange, TDocument>
        where TDocument : IDocument<TEnvironment, TChange, TUser>
    {
        public TDocument Document { get; set; }
        public TEnvironment Environment { get; set; }

        public abstract bool ChangeDocument(TChange change, TUser user);

        protected virtual List<TChange> GetChangesForUser(TUser user)
        {
            if (Document.Changes.ContainsKey(user))
            {
                return Document.Changes[user];
            }

            return new List<TChange>();
        }
    }
}