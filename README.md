# ProtoBuf-Net-Test-Harness

This test harness creates an object that causes a high frequency of fragmentation on the large object heap when serialized with [**protobuf-net**](https://github.com/mgravell/protobuf-net).

![protobuf-net_loh_allocations](https://user-images.githubusercontent.com/1906778/29731677-39de6686-89dd-11e7-8e86-623ab168017c.png)

An issue has been opened up with [**protobuf-net**](https://github.com/mgravell/protobuf-net/issues/301).
