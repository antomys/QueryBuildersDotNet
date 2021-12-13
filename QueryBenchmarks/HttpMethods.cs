using System.Collections.Specialized;
using System.Text;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;

namespace QueryBenchmarks;
[MemoryDiagnoser]
public class HttpMethods
{
    private const string Url = "https://datausa.io/api/data";

    [Benchmark]
    public async Task BuildDictionaryQuery()
    {
        var queries = new Dictionary<string, string>
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        var queryString = QueryHelpers.AddQueryString(Url, queries);
        using var client = new HttpClient {BaseAddress = new Uri(queryString)};

        var response = await client.GetAsync(client.BaseAddress, CancellationToken.None);
    }

    [Benchmark]
    public async Task BuildFormUrlEncodedContentKeyValuePairQuery()
    {
        using var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        {
            new("drilldowns", "Nation"),
            new("measures", "Population")
        });

        var result = await content.ReadAsStringAsync();
        const string urlNew = Url + "?";
        using var client = new HttpClient {BaseAddress = new Uri(new Uri(urlNew), result)};

        var response = await client.GetAsync(client.BaseAddress, CancellationToken.None);
    }

    [Benchmark]
    public async Task BuildFormUrlEncodedContentDictionaryQuery()
    {
        using var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        });

        var result = await content.ReadAsStringAsync();
        const string urlNew = Url + "?";
        using var client = new HttpClient {BaseAddress = new Uri(new Uri(urlNew), result)};

        var response = await client.GetAsync(client.BaseAddress, CancellationToken.None);
    }

    [Benchmark]
    public async Task CustomMethodQuery()
    {
        var queryParams = new NameValueCollection
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        var urlNew = Url + ToQueryString(queryParams);
        using var client = new HttpClient {BaseAddress = new Uri(urlNew)};

        var response = await client.GetAsync(client.BaseAddress, CancellationToken.None);
    }

    [Benchmark]
    public async Task AspNetCoreQueryBuilderQuery()
    {
        var qb = new QueryBuilder
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        var newUrl = Url + qb.ToQueryString();

        using var client = new HttpClient {BaseAddress = new Uri(newUrl)};

        var response = await client.GetAsync(client.BaseAddress, CancellationToken.None);
    }

    private string ToQueryString(NameValueCollection nvc)
    {
        var sb = new StringBuilder("?");

        var first = true;

        foreach (var key in nvc.AllKeys)
        foreach (var value in nvc.GetValues(key))
        {
            if (!first) sb.Append("&");

            sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));

            first = false;
        }

        return sb.ToString();
    }
}