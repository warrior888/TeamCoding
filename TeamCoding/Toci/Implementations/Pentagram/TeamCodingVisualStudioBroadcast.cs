using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.Text;
using TeamCoding.VisualStudio;
using Toci.Piastcode.Social.Client;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Sockets.Interfaces;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace TeamCoding.Toci.Implementations.Pentagram
{
    public class TeamCodingVisualStudioBroadcast : BroadcastManager 
    {
        public override bool BroadcastDocument(IUser user, IVsDocument doc)
        {
            throw new NotImplementedException();
        }

        public override bool BroadcastChange(IUser user, IVsDocument doc)
        {
            if (EnvironmentOpenedFilesManager.IsFileOpenedInEnv(doc.FilePath))
            {
                EnvOpenedFilesManager.SynContext.Post(new SendOrPostCallback(o => UpdateDocumentChange(doc)), null);
            }
            else
            {
                //string fileContent;
                try
                {
                    StreamReader stR = new StreamReader(ProjectManager.MakeAbsoluteFilePath(doc.FilePath));

                    StringBuilder sb = new StringBuilder(stR.ReadToEnd());
                    stR.Close();

                    foreach (var editChange in doc.Changes)
                    {
                        if (editChange.Text.Length < editChange.OldPositionEnd - editChange.PositionStart) //deletion
                            sb.Remove(editChange.PositionStart, editChange.OldPositionEnd - editChange.PositionStart);
                        sb.Insert(editChange.PositionStart, editChange.Text);

                    }

                    StreamWriter swR = new StreamWriter(ProjectManager.MakeAbsoluteFilePath(doc.FilePath));

                    swR.WriteLine(sb.ToString());
                    swR.Close();
                }
                catch (IOException ex)
                {
                    Debug.WriteLine("Err: " + ex.Message);
                }

            }

            return true;
        }


            /*
            IVsChange vsChange = change as IVsChange;

            if (EnvironmentOpenedFilesManager.IsFileOpenedInEnv(vsChange.FilePath))
            {
                EnvOpenedFilesManager.SynContext.Post(new SendOrPostCallback(o => UpdateFile(vsChange.FilePath, doc)), null);
            }
            else
            {
                //string fileContent;
                try
                {
                    StreamReader stR = new StreamReader(ProjectManager.MakeAbsoluteFilePath(vsChange.FilePath));

                    StringBuilder sb = new StringBuilder(stR.ReadToEnd());
                    stR.Close();

                    foreach (var editChange in doc.EditChanges)
                    {
                        if (editChange.Text.Length < editChange.OldPositionEnd - editChange.PositionStart) //deletion
                            sb.Remove(editChange.PositionStart, editChange.OldPositionEnd - editChange.PositionStart);
                        sb.Insert(editChange.PositionStart, editChange.Text);

                    }

                    StreamWriter swR = new StreamWriter(ProjectManager.MakeAbsoluteFilePath(filePath));

                    swR.WriteLine(sb.ToString());
                    swR.Close();
                }
                catch (IOException ex)
                {

                }
                
            }*/
        

        
    }
}