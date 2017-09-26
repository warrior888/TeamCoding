﻿using Toci.Ptc.Manager;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Documents.Changes.Managers
{
    public class VisualStudioEditDocManager : VisualStudioChangeDocManager
    {
        public VisualStudioEditDocManager(string projName) : base(projName)
        {
        }
    }
}