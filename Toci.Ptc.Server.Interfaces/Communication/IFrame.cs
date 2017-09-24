namespace Toci.Ptc.Server.Interfaces.Communication
{
    public interface IFrame<TEnvironment> //TEnvironment powerpoint vs excel SAP
    {
        string Base64EncodedContent { get; set; }
    }
}