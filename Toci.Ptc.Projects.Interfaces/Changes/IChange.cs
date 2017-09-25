using Microsoft.VisualStudio.Text;

namespace Toci.Ptc.Projects.Interfaces.Changes
{
    public interface IChange<TEnvironment> //: ITextSnapshot // ???
    {
        ChangeTypes ChgType { get; set; }

        string Base64EncodedContent { get; set; }

        //caretInfo caretposition 

        // string info = > dupa


    }
}