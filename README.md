# ProtoBuf-Net-Test-Harness

Iterations|[WithStockProtoBuf](https://github.com/Singh400/ProtoBuf-Net-Test-Harness#withstockprotobuf) (MB)|[WithCachedPool](https://github.com/Singh400/ProtoBuf-Net-Test-Harness#withcachedpool) (MB) |[WithArrayPool](https://github.com/Singh400/ProtoBuf-Net-Test-Harness#witharraypool) (MB)
------------ | ------------- | ------------- | -------------
10,000|8.8|0.9|0.9
50,000|39|4.3|4.3
100,000|80|8.7|8.7
200,000|160|17|17
300,000|321|34|34

## WithStockProtoBuf
This test harness creates an object that causes a high frequency of fragmentation on the large object heap when serialized with [**protobuf-net**](https://github.com/mgravell/protobuf-net).

![protobuf-net_loh_allocations](https://user-images.githubusercontent.com/1906778/29731677-39de6686-89dd-11e7-8e86-623ab168017c.png)

An issue has been opened up with [**protobuf-net**](https://github.com/mgravell/protobuf-net/issues/301).

## WithCachedPool
https://github.com/mgravell/protobuf-net/issues/301#issuecomment-325208496 explains that they implemented a "CachedPool" in which they saw fewer LOH allocations. A quick test in the harness reveals the same behaviour. See this comment for more information:  https://github.com/mgravell/protobuf-net/issues/301#issuecomment-325216098

![withstockprotobufnet_vs_withcachedpool](https://user-images.githubusercontent.com/1906778/29752872-ec7df3a2-8b5d-11e7-9be4-239a59b06675.png)

_WithStockProtoBuf_ is on the left, _WithCachedPool_ on the right.

## WithArrayPool
This implementation of protobuf-net is backed by [**System.Buffers.ArrayPool**](https://www.nuget.org/packages/System.Buffers/) and shows the same reduction in LOH allocations as the WithCachedPool version.

![withstockprotobufnet_vs_witharraypool](https://user-images.githubusercontent.com/1906778/29785987-65f1cb78-8c21-11e7-8c98-5203baefb932.png)

_WithStockProtoBuf_ is on the left, _WithArrayPool_ on the right.
