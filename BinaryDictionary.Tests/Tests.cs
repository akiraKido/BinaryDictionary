using System;
using Xunit;
using FluentAssertions;

namespace BinaryDictionaryNS.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, false)]
        [InlineData(31, 31, true)]
        [InlineData(29, 31, false)]
        [InlineData(32, 32, true)]
        [InlineData(64, 64, true)]
        [InlineData(1000000, 1000000, true)]
        public void TestRegisterAndContains(int input, int check, bool expected)
        {
            var binaryDictionary = new BinaryDictionary();
            binaryDictionary.Add(input);

            binaryDictionary.Contains(check).Should().Be(expected);
        }

        [Fact]
        public void TestMultipleRegister()
        {
            var binaryDictionary = new BinaryDictionary();

            binaryDictionary.Add(1);
            binaryDictionary.Add(31);
            binaryDictionary.Add(32);

            binaryDictionary.Contains(1).Should().Be(true);
            binaryDictionary.Contains(31).Should().Be(true);
            binaryDictionary.Contains(32).Should().Be(true);

            binaryDictionary.BufferSize.Should().Be(64);
            
            for (int i = 0; i < binaryDictionary.BufferSize; i++)
            {
                switch (i)
                {
                    case 1:
                        binaryDictionary.Contains(1).Should().Be(true);
                        continue;
                    case 31:
                        binaryDictionary.Contains(31).Should().Be(true);
                        continue;
                    case 32:
                        binaryDictionary.Contains(32).Should().Be(true);
                        continue;
                    default:
                        binaryDictionary.Contains(i).Should().Be(false);
                        break;
                }
            }
        }

        [Theory]
        [InlineData(1, 1, false)]
        public void TestRemove(int input, int remove, bool expected)
        {
            var binaryDictionary = new BinaryDictionary();
            binaryDictionary.Add(input);
            binaryDictionary.Remove(remove);

            binaryDictionary.Contains(remove).Should().Be(expected);
        }

        [Fact]
        public void TestRemoveGreaterThanSize()
        {
            var binaryDictionary = new BinaryDictionary();
            binaryDictionary.Invoking(b => b.Remove(100))
                .Should().NotThrow();
        }
        [Fact]
        public void TestContainsGreaterThanSize()
        {
            var binaryDictionary = new BinaryDictionary();
            binaryDictionary.Contains(100).Should().Be(false);
        }

        [Fact]
        public void TestRegisterThrow()
        {
            var binaryDictionary = new BinaryDictionary();
            binaryDictionary.Invoking(b => b.Add(-1))
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestContainsThrow()
        {
            var binaryDictionary = new BinaryDictionary();
            binaryDictionary.Invoking(b => b.Contains(-1))
                .Should().Throw<ArgumentException>();
        }
        [Fact]
        public void TestRemoveThrow()
        {
            var binaryDictionary = new BinaryDictionary();
            binaryDictionary.Invoking(b => b.Remove(-1))
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestCount()
        {
            var binaryDictionary = new BinaryDictionary();
            for (int i = 0; i < 10; i++)
            {
                binaryDictionary.Add(i);
            }

            binaryDictionary.Count().Should().Be(10);
        }
    }
}