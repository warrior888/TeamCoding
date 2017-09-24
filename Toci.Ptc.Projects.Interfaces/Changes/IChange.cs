using Microsoft.VisualStudio.Text;

namespace Toci.Ptc.Projects.Interfaces.Changes
{
    public interface IChange : ITextSnapshot // ???
    {
        ChangeTypes ChgType { get; set; }

        int Line { get; set; } // ??

        //caretInfo caretposition 

         // string info = > dupa


    }
}