# ProtoBuf-Net-Test-Harness

Iterations|[WithoutGroups](https://github.com/Singh400/ProtoBuf-Net-Test-Harness#withoutgroups) (MB) | [WithGroups](https://github.com/Singh400/ProtoBuf-Net-Test-Harness#withgroups) (MB)
------------ | ------------- | -------------
10,000|8.8|0.0
50,000|39|0.4
100,000|80|0.8
200,000|160|1.5
300,000|321|2.3

## WithoutGroups
This test harness creates an object that causes a high frequency of fragmentation on the large object heap when serialized with [**protobuf-net**](https://github.com/mgravell/protobuf-net).

![protobuf-net_loh_allocations](https://user-images.githubusercontent.com/1906778/29731677-39de6686-89dd-11e7-8e86-623ab168017c.png)

An issue has been opened up with [**protobuf-net**](https://github.com/mgravell/protobuf-net/issues/301).

## WithGroups
Large Object Heap (LOH) allocation and fragmentation is caused when ProtoBuf is left in it's default configuration. If you enable groups then LOH allocation and fragmentation will be reduced to nothing. For more detail see [this comment](https://github.com/mgravell/protobuf-net/issues/301#issuecomment-370178685) and [this StackOverflow question](https://stackoverflow.com/q/48358142).
