# ProtoBuf-Net-Test-Harness

## WithStockProtoBuf
This test harness creates an object that causes a high frequency of fragmentation on the large object heap when serialized with [**protobuf-net**](https://github.com/mgravell/protobuf-net).

![protobuf-net_loh_allocations](https://user-images.githubusercontent.com/1906778/29731677-39de6686-89dd-11e7-8e86-623ab168017c.png)

An issue has been opened up with [**protobuf-net**](https://github.com/mgravell/protobuf-net/issues/301).

## WithCachedPool
https://github.com/mgravell/protobuf-net/issues/301#issuecomment-325208496 explains that they implemented a "CachedPool" in which they saw fewer LOH allocations. A quick test in the harness reveals the same behaviour. See this comment for more information:  https://github.com/mgravell/protobuf-net/issues/301#issuecomment-325216098

![withstockprotobufnet_vs_withcachedpool](https://user-images.githubusercontent.com/1906778/29752872-ec7df3a2-8b5d-11e7-9be4-239a59b06675.png)

Iterations|WithStockProtoBuf (MB)|WithCachedPool (MB)
------------ | ------------- | -------------
10000|8.8|0.9
50000|39|4.3
100000|80|8.7
200000|160|17
300000|321|34
