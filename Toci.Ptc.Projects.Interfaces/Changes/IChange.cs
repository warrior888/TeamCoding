using Microsoft.VisualStudio.Text;

namespace Toci.Ptc.Projects.Interfaces.Changes
{
    public interface IChange<TEnvironment> //: ITextSnapshot // ???
    {
        ChangeTypes ChgType { get; set; }

        string Base64EncodedContent { get; set; }

        TEnvironment Environment { get; set; }

        string GetChangeId();

        //caretInfo caretposition 

        // string info = > dupa


    }
}