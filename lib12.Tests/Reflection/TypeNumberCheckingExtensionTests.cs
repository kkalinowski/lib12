using System;
using System.Collections;
using System.Collections.Generic;
using lib12.Reflection;
using Shouldly;
using Xunit;

namespace lib12.Tests.Reflection
{
    public class TypeNumberCheckingExtensionTests
    {
        private class FloatingPointNumberData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[]{"abc", false},
                new object[]{ 'a', false},
                new object[]{ true, false},
                new object[]{ DateTime.Now, false},
                new object[]{ new object(), false},
                new object[]{ byte.MaxValue, false},
                new object[]{ sbyte.MaxValue, false},
                new object[]{ short.MaxValue, false},
                new object[]{ ushort.MaxValue, false},
                new object[]{ 12, false},
                new object[]{ 12U, false},
                new object[]{ 120L, false},
                new object[]{ 120UL, false},
                new object[]{ 12.5, true},
                new object[]{ 12.5f, true},
                new object[]{ 12.5m, true},
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class IntegralNumberData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[]{"abc", false},
                new object[]{ 'a', false},
                new object[]{ true, false},
                new object[]{ DateTime.Now, false},
                new object[]{ new object(), false},
                new object[]{ byte.MaxValue, true},
                new object[]{ sbyte.MaxValue, true},
                new object[]{ short.MaxValue, true},
                new object[]{ ushort.MaxValue, true},
                new object[]{ 12, true},
                new object[]{ 12U, true},
                new object[]{ 120L, true},
                new object[]{ 120UL, true},
                new object[]{ 12.5, false},
                new object[]{ 12.5f, false},
                new object[]{ 12.5m, false},
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class NumberData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[]{"abc", false},
                new object[]{ 'a', false},
                new object[]{ true, false},
                new object[]{ DateTime.Now, false},
                new object[]{ new object(), false},
                new object[]{ byte.MaxValue, true},
                new object[]{ sbyte.MaxValue, true},
                new object[]{ short.MaxValue, true},
                new object[]{ ushort.MaxValue, true},
                new object[]{ 12, true},
                new object[]{ 12U, true},
                new object[]{ 120L, true},
                new object[]{ 120UL, true},
                new object[]{ 12.5, true},
                new object[]{ 12.5f, true},
                new object[]{ 12.5m, true},
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class NumberOrNullableNumberData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[]{typeof(string), false},
                new object[]{ typeof(char), false},
                new object[]{ typeof(bool), false},
                new object[]{ typeof(bool?), false},
                new object[]{ typeof(object), false},
                new object[]{ typeof(int), true},
                new object[]{ typeof(int?), true},
                new object[]{ typeof(double), true},
                new object[]{ typeof(double?), true},

            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(FloatingPointNumberData))]
        public void IsFloatingPointNumber_is_correct(object value, bool expectedResult)
        {
            value.GetType().IsFloatingPointNumber().ShouldBe(expectedResult);
        }

        [Theory]
        [ClassData(typeof(IntegralNumberData))]
        public void IsIntegralPointNumber_is_correct(object value, bool expectedResult)
        {
            value.GetType().IsIntegralNumber().ShouldBe(expectedResult);
        }

        [Theory]
        [ClassData(typeof(NumberData))]
        public void IsNumber_is_correct(object value, bool expectedResult)
        {
            value.GetType().IsNumber().ShouldBe(expectedResult);
        }

        [Theory]
        [ClassData(typeof(NumberOrNullableNumberData))]
        public void IsNumberOrNullableNumber_is_correct(Type value, bool expectedResult)
        {
            value.IsNumberOrNullableNumber().ShouldBe(expectedResult);
        }
    }
}