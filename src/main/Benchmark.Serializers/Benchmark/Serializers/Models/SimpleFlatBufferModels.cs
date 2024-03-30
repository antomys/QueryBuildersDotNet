// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Benchmark.Serializers.Models
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct SimpleFlatBufferModels : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_24_3_25(); }
  public static SimpleFlatBufferModels GetRootAsSimpleFlatBufferModels(ByteBuffer _bb) { return GetRootAsSimpleFlatBufferModels(_bb, new SimpleFlatBufferModels()); }
  public static SimpleFlatBufferModels GetRootAsSimpleFlatBufferModels(ByteBuffer _bb, SimpleFlatBufferModels obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public static bool VerifySimpleFlatBufferModels(ByteBuffer _bb) {Google.FlatBuffers.Verifier verifier = new Google.FlatBuffers.Verifier(_bb); return verifier.VerifyBuffer("", false, SimpleFlatBufferModelsVerify.Verify); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SimpleFlatBufferModels __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Benchmark.Serializers.Models.SimpleFlatBufferModel? Models(int j) { int o = __p.__offset(4); return o != 0 ? (Benchmark.Serializers.Models.SimpleFlatBufferModel?)(new Benchmark.Serializers.Models.SimpleFlatBufferModel()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ModelsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<Benchmark.Serializers.Models.SimpleFlatBufferModels> CreateSimpleFlatBufferModels(FlatBufferBuilder builder,
      VectorOffset modelsOffset = default(VectorOffset)) {
    builder.StartTable(1);
    SimpleFlatBufferModels.AddModels(builder, modelsOffset);
    return SimpleFlatBufferModels.EndSimpleFlatBufferModels(builder);
  }

  public static void StartSimpleFlatBufferModels(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddModels(FlatBufferBuilder builder, VectorOffset modelsOffset) { builder.AddOffset(0, modelsOffset.Value, 0); }
  public static VectorOffset CreateModelsVector(FlatBufferBuilder builder, Offset<Benchmark.Serializers.Models.SimpleFlatBufferModel>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateModelsVectorBlock(FlatBufferBuilder builder, Offset<Benchmark.Serializers.Models.SimpleFlatBufferModel>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateModelsVectorBlock(FlatBufferBuilder builder, ArraySegment<Offset<Benchmark.Serializers.Models.SimpleFlatBufferModel>> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateModelsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<Offset<Benchmark.Serializers.Models.SimpleFlatBufferModel>>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartModelsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Benchmark.Serializers.Models.SimpleFlatBufferModels> EndSimpleFlatBufferModels(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Benchmark.Serializers.Models.SimpleFlatBufferModels>(o);
  }
  public static void FinishSimpleFlatBufferModelsBuffer(FlatBufferBuilder builder, Offset<Benchmark.Serializers.Models.SimpleFlatBufferModels> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedSimpleFlatBufferModelsBuffer(FlatBufferBuilder builder, Offset<Benchmark.Serializers.Models.SimpleFlatBufferModels> offset) { builder.FinishSizePrefixed(offset.Value); }
}


static public class SimpleFlatBufferModelsVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyVectorOfTables(tablePos, 4 /*Models*/, Benchmark.Serializers.Models.SimpleFlatBufferModelVerify.Verify, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}
