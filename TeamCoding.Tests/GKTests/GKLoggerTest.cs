using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCoding.Logging;
using Toci.Ptc.Broadcast;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Server.Interfaces.Communication;

//using TeamCoding.VisualStudio.Models;

namespace Toci.TeamCoding.Tests.GKTests
{
    [TestClass]
    public class GKLoggerTest
    {
        [TestMethod]
        public void TestMyLogger()
        {
            GK_Logger logger = new GK_Logger();

            logger.WriteToFile();
            
        }
    }

    public interface IHuman
    {
        bool Pee();

        string Talk();

        int Gender { get; set; }
    }

    public abstract class HumanBase : IHuman
    {
        public abstract bool Pee();

        public string Talk()
        {
            return "CZewsc";
        }

        public int Gender { get; set; }
    }

    public interface IUser
    {
        string Name { get; set; }

        bool Login(string user, string password);
    }

    public interface IClient : IUser
    {
        
    }

    public interface IEmployer : IUser
    {
        
    }

    public abstract class UserBase : IUser
    {
        public string Name { get; set; }

        public virtual bool Login(string user, string password)
        {
            throw new NotImplementedException();
        }
    }

    public class Client : UserBase
    {
        public override bool Login(string user, string password)
        {
            return false;
        }
    }

    public class Employer : Client
    {
        // login

        // pukniecie do api fb return false
    }

    public abstract class EnviroenmentBase
    {
        public abstract bool Save(string data);
    }

    public class EXcelEnvironment : EnviroenmentBase
    {
        public override bool Save(string data)
        {
            throw new NotImplementedException(); // todo excel style
        }
    }

    public class PowerPoint : EnviroenmentBase
    {
        public override bool Save(string data)
        {
            throw new NotImplementedException(); // todo excel style
        }

        public void ZrobMiBj()
        {
            
        }
    }

    public class ExcelEnvironment : IEnvironment
    {
        public void Bj()
        {
            
        }
    }

    public class TxtEnvironment : IEnvironment { }


    //public class ExcelServer : IServer<>

    //public class PowerPointBroadcast : BroadcastBase<IEnvironment, IDocument<IEnvironment, IChange<IEnvironment>, IUser>, >

    /*
    public class GhostRiderDocument : IDocument<EnviroenmentBase>
    {
        public DocumentType DocType { get; set; }
        public Dictionary<Ptc.Users.Interfaces.Skeleton.IUser, List<IChange<EnviroenmentBase>>> Changes { get; set; }

        public bool CreateChange(ChangeTypes chngType, string base64EncodedChange, EnviroenmentBase env)
        {
            //env.
            throw new NotImplementedException();
        }
    }

    public class ZombieDocument : IDocument<PowerPoint>
    {
        public DocumentType DocType { get; set; }
        public Dictionary<Ptc.Users.Interfaces.Skeleton.IUser, List<IChange<PowerPoint>>> Changes { get; set; }

        public bool CreateChange(ChangeTypes chngType, string base64EncodedChange, PowerPoint env)
        {
            env.ZrobMiBj();
            throw new NotImplementedException();
        }
    }
    */
}
