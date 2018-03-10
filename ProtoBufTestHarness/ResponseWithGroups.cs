using ProtoBuf;

namespace ProtoBufTestHarness
{
    [ProtoContract(IsGroup = true)]
    public class ResponseWithGroups
    {
        [ProtoMember(1)]
        public OuterWithGroups OuterResponse { get; set; }
        [ProtoMember(2)]
        public InnerWithGroups InnerResponse { get; set; }
    }

    [ProtoContract(IsGroup = true)]
    public class OuterWithGroups
    {
        [ProtoMember(1)]
        public ResultWithGroups[] OuterResults { get; set; }
    }

    [ProtoContract(IsGroup = true)]
    public class InnerWithGroups
    {
        [ProtoMember(1)]
        public ResultWithGroups[] InnerResults { get; set; }
    }

    [ProtoContract(IsGroup = true)]
    public class ResultWithGroups
    {
        [ProtoMember(1)]
        public string TheString { get; set; }
    }
}