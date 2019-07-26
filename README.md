# BinaryDictionary
A fast dictionary only for "int"s

Insipired by "Programming Perls", the `Binary Dictionary` is a fast dictionary to add and find indexies.

# Usage

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

