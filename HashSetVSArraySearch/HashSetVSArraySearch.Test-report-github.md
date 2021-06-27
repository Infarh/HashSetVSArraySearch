``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.301
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT


```
|        Method |      Mean |     Error |    StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |----------:|----------:|----------:|-----:|-------:|------:|------:|----------:|
|  LinearSearch | 26.953 μs | 0.2504 μs | 0.2342 μs |    2 | 0.0610 |     - |     - |     280 B |
| HashSetSearch |  1.999 μs | 0.0220 μs | 0.0195 μs |    1 | 0.0648 |     - |     - |     280 B |
