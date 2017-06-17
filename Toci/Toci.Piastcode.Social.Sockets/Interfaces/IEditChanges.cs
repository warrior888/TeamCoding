﻿using ProtoBuf;

namespace Toci.Piastcode.Social.Sockets.Interfaces
{
    [ProtoContract]
    public interface IEditChanges
    {
        [ProtoMember(1)]
        int PositionStart { get; set; }
        [ProtoMember(2)]
        int OldPositionEnd { get; set; }
        [ProtoMember(3)]
        string Text { get; set; }
    }
}