using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;
using Toci.Ptc.Projects.Changes;
using Toci.Ptc.Projects.Documents;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;

namespace Toci.TeamCoding.Tests.GhostRider.Serialiation.Protobuf
{
    [TestClass]
    public class ProtobufPoc
    {
        [TestMethod]
        public void TestSerializationDeserialization()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                VsFileDocument frame = new VsFileDocument();

                frame.Changes = new List<VsChange>();
                frame.Content = "2 kurwa fnm iewhfuoheuwog wg wehg wig igo";
                frame.Kurwa = "fdsgsgfds";
                frame.Changes.Add(new VsChange { Text = "KURWA"});

                Serializer.Serialize(ms, frame);

                ms.Position = 0;

                VsFileDocument tusdocumenter = Serializer.Deserialize<VsFileDocument>(ms);
            }
        }
    }
}