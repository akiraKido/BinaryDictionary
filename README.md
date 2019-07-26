# BinaryDictionary
A fast dictionary only for "int"s

Insipired by "Programming Perls", the `Binary Dictionary` is a fast dictionary to add and find indexies.

# Usage

`Binary Dictionary` can scale to large numbers, but because one `int` value can only store up to 32 flags,
it can only cotnain up to the limit of the indexer ([which should be 0X7FEFFFFF](https://docs.microsoft.com/ja-jp/dotnet/api/system.array?redirectedfrom=MSDN&view=netframework-4.8)).

Additionally, if you are using a large number and only expect to use a few of them (i.e., [10000, 10002, 10003])
you would be better off using a `HashSet`.

The best scenario would be when you need a full set of discrete numbers which don't need to be sorted.

## Add
```
var binaryDictionary = new BinaryDictionary();
binaryDictionary.Add(1);
```

## Contains
```
var binaryDictionary = new BinaryDictionary();
binaryDictionary.Add(1);
binaryDictionary.Contains(1); // true
```

## Remove
```
var binaryDictionary = new BinaryDictionary();
binaryDictionary.Add(1);
binaryDictionary.Remove(1);
binaryDictionary.Contains(1); // false
```

# Benchmark

|                       Method |     Mean |       Error |      StdDev |
|----------------------------- |---------:|------------:|------------:|
|             BinaryDictionary | 29.55 ns |   0.2493 ns |   0.2210 ns |
|                      HashSet | 42.46 ns |   0.3258 ns |   0.2888 ns |
| LargeNumber_BinaryDictionary |  5.22  s | 103.4721 ms | 283.2534 ms |
|          LargeNumber_HashSet | 24.67  s | 274.7777 ms | 243.5832 ms |


(original)
|                       Method |             Mean |           Error |          StdDev |
|----------------------------- |-----------------:|----------------:|----------------:|
|             BinaryDictionary |         29.55 ns |       0.2493 ns |       0.2210 ns |
|                      HashSet |         42.46 ns |       0.3258 ns |       0.2888 ns |
| LargeNumber_BinaryDictionary |  5,221,884.60 ns | 103,472.1737 ns | 283,253.4057 ns |
|          LargeNumber_HashSet | 24,672,681.47 ns | 274,777.7234 ns | 243,583.2947 ns |
