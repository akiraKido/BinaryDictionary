using System;

// ReSharper disable once CheckNamespace
namespace BinaryDictionaryNS
{
    public class BinaryDictionary
    {
        private int[] dictionaries;

        public BinaryDictionary()
        {
            dictionaries = new int[1];
        }

        public void Add(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("index must be positive");
            }
        
            CheckDictionarySize(index);

            var valueOffset = index % 32;
            var orValue = 1 << valueOffset;
        
            var dictionaryIndex = index / 32;
            dictionaries[dictionaryIndex] |= orValue;
        }

        public bool Contains(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("index must be positive");
            }
        
            if (index >= BufferSize)
            {
                return false;
            }
        
            var dictionaryIndex = index / 32;
            var valueOffset = index % 32;
            var checkOrValue = 1 << valueOffset;

            return (checkOrValue & dictionaries[dictionaryIndex]) != 0;
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("index must be positive");
            }

            if (index > BufferSize)
            {
                return;
            }
        
            var valueOffset = index % 32;
            var orValue = 1 << valueOffset;
        
            var dictionaryIndex = index / 32;
            dictionaries[dictionaryIndex] ^= orValue;
        }

        public int Count()
        {
            var result = 0;
            foreach (var item in dictionaries)
            {
                for (int i = 0; i < 32; i++)
                {
                    var check = 1 << i;
                    if ((item & check) != 0)
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }
        
        public int BufferSize => dictionaries.Length * 32;

        private void CheckDictionarySize(int index)
        {
            var necessarySize = index / 32 + 1;
            if (necessarySize < dictionaries.Length)
            {
                return;
            }

            var doubleSize = dictionaries.Length * 2;
            var newArray = necessarySize > doubleSize
                ? new int[necessarySize]
                : new int[doubleSize];

            Array.Copy(dictionaries, 0, newArray, 0, dictionaries.Length);
            dictionaries = newArray;
        }
    }
}