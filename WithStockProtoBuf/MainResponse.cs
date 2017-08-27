using ProtoBuf;

namespace ProtoBufNetTestHarness
{
    [ProtoContract]
    public class MainResponse
    {
        [ProtoMember(1)]
        public OuterResponse OuterResponse { get; set; }
        [ProtoMember(2)]
        public InnerResponse InnerResponse { get; set; }
    }

    [ProtoContract]
    public class OuterResponse
    {
        [ProtoMember(1)]
        public Result[] OuterResults { get; set; }
    }

    [ProtoContract]
    public class InnerResponse
    {
        [ProtoMember(1)]
        public Result[] InnerResults { get; set; }
    }

    [ProtoContract]
    public class Result
    {
        [ProtoMember(1)]
        public string TheString { get; set; }
    }
}