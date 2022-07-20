﻿using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Serialization from byte array.
/// </summary>
public class ByteSerializationBenchmarks : JsonBenchmark
{
    /// <summary>
    ///     Global setup of test values.
    /// </summary>
    [GlobalSetup]
    public new void Setup() => base.Setup();
    
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark(Baseline = true)]
    public byte[] SystemTextJson()
     {
         return SystemTextJsonService.SystemTextJsonSerializeBytes(SimpleModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonGeneratedSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] Utf8Json()
    {
        return Utf8JsonService.Utf8JsonBytesSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] ZeroFormatter()
    {
        return ZeroFormatterService.ZeroFormatterSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="byte"/></returns>
    [Benchmark]
    public byte[] SpanJson()
    {
        return SpanJsonService.SpanJsonSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] MsgPackClassic()
    {
        return MsgPackService.MsgPackClassicSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] MsgPackLz4Block()
    {
        return MsgPackService.MsgPackLz4BlockSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] JsonSrcGen()
    {
        return JsonSrcGenService.JsonSrcGenSerializeBytes(SimpleSrcGenModels);
    }
}