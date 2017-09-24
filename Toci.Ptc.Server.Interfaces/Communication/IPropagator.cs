using System.Collections.Generic;

namespace Toci.Ptc.Server.Interfaces.Communication
{
    public interface IPropagator<TUser, TFrame, TEnvironment> : IServer<TFrame, TEnvironment>
    {
        bool Propagate(Dictionary<string, TUser> users, TEnvironment env, TFrame frame);
    }
}