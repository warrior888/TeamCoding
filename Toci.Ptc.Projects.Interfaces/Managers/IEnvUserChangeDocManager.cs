namespace Toci.Ptc.Projects.Interfaces.Managers
{
    public interface IEnvUserChangeDocManager<TEnvironment, TUser, TChange, TDocument>
    {
        TDocument Document { get; set; }
        TEnvironment Environment { get; set; }

        bool ChangeDocument(TChange change, TUser user);
    }
}