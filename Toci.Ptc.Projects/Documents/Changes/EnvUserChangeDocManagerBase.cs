using Toci.Ptc.Projects.Interfaces.Managers;

namespace Toci.Ptc.Projects.Documents.Changes
{
    public class EnvUserChangeDocManagerBase<TEnvironment, TUser, TChange, TDocument> : IEnvUserChangeDocManager<TEnvironment, TUser, TChange, TDocument>
    {
        public TDocument Document { get; set; }
        public TEnvironment Environment { get; set; }

        public bool ChangeDocument(TChange change, TUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}