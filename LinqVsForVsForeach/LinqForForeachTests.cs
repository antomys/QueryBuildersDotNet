using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Bogus;

namespace LinqVsForVsForeach;

[MemoryDiagnoser(true)]
public class LinqForForeachTests
{
    [Params(10, 100, 1000, 10000, 100000, 1000000)]
    public int ModelsCount { get; set; }

    private readonly Consumer _consumer = new();

    private TestModel[] _testInputModels;
    
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        Array.Clear(_testInputModels);
    }
    
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker<TestModel>();
        Randomizer.Seed = new Random(420);
        
        var test = faker
            .RuleFor(x=> x.TestInd, y=> y.Random.Int())
            .RuleFor(x=> x.TestString, y=> y.Random.String2(10))
            .RuleFor(x=> x.TestDateTime, y=> y.Date.Past())
            .Generate(ModelsCount);
        _testInputModels = test.ToArray();
    }

    [Benchmark(Baseline = true)]
    public void ForMethod()
    {
        var testOutputModels = new string[_testInputModels.Length];
        for (var i = 0; i < _testInputModels.Length; i++)
        {
            testOutputModels[i] = JsonSerializer.Serialize(_testInputModels[i]);
        }
        
        _consumer.Consume(testOutputModels);
    }
    
    [Benchmark]
    public void ForeachMethod()
    {
        var testOutputModels = new List<string>(_testInputModels.Length);
        foreach (var testModel in _testInputModels)
        {
            testOutputModels.Add(JsonSerializer.Serialize(testModel));
        }
        
        _consumer.Consume(testOutputModels);
    }

    [Benchmark]
    public void LinqMethod()
    {
        _testInputModels
            .Where(x=> x != null)
            .Select(x => JsonSerializer.Serialize(x))
            .Consume(_consumer);
    }
}