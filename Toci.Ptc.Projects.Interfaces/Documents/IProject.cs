﻿namespace Toci.Ptc.Projects.Interfaces.Documents
{
    public interface IProject<out TDocument> // 
    {
        TDocument GetDocument(string name);
    }
}