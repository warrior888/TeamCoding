using Microsoft.Build.Construction;
using net.r_eg.MvsSln;
using Toci.Ptc.Projects.Interfaces.Documents;

namespace Toci.Ptc.Projects.Project
{
    public abstract class ProjectBase : IProject<IVsDocument>
    {
        protected Sln Solution;

        protected ProjectBase(string slnPath)
        {
            Solution = new Sln(slnPath, SlnItems.All);
        }
        
        public virtual IVsDocument GetDocument(string name)
        {
            throw new System.NotImplementedException();
        }

        public Sln GetSln()
        {
            return Solution;
        }
    }
}