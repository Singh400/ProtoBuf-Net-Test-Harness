using ProtoBuf;

namespace ProtoBufTestHarness
{
    [ProtoContract]
    public class ResponseWithoutGroups
    {
        [ProtoMember(1)]
        public OuterWithoutGroups OuterResponse { get; set; }
        [ProtoMember(2)]
        public InnerWithoutGroups InnerResponse { get; set; }
    }

    [ProtoContract]
    public class OuterWithoutGroups
    {
        [ProtoMember(1)]
        public ResultWithoutGroups[] OuterResults { get; set; }
    }

    [ProtoContract]
    public class InnerWithoutGroups
    {
        [ProtoMember(1)]
        public ResultWithoutGroups[] InnerResults { get; set; }
    }

    [ProtoContract]
    public class ResultWithoutGroups
    {
        [ProtoMember(1)]
        public string TheString { get; set; }
    }

    
}