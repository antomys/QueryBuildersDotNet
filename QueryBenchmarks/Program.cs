﻿using BenchmarkDotNet.Running;

namespace QueryBenchmarks;

class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<SerializationBenchmarks>();
    }
}