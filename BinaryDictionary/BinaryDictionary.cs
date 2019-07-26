using System;

namespace BinaryDictionary
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
        
            if (index >= Size)
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

            if (index > Size)
            {
                return;
            }
        
            var valueOffset = index % 32;
            var orValue = 1 << valueOffset;
        
            var dictionaryIndex = index / 32;
            dictionaries[dictionaryIndex] ^= orValue;
        }

        public int Size => dictionaries.Length * 32;

        private void CheckDictionarySize(int index)
        {
            var necessarySize = index / 32;
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