using System.Collections.Generic;
using Polynomial.WebApi.Domain.Entities;
using Xunit;

namespace Polynomial.UnitTests
{
    public class MonomTests
    {
        [Theory]
        [MemberData(nameof(MonomToHeadlinerStringCases))]
        public void ToHeadlinerString_ShouldBeAsExpected(Monom monom, string expected)
        {
            Assert.Equal(expected, monom.ToHeadlinerString());
        }

        [Theory]
        [MemberData(nameof(MonomToStringCases))]
        public void ToString_ShouldBeAsExpected(Monom monom, string expected)
        {
            Assert.Equal(expected, monom.ToString());
        }

        public static IEnumerable<object[]> MonomToHeadlinerStringCases()
        {
            yield return new object[]
            {
                new Monom {Coefficient = 7}, "7"
            };
            yield return new object[]
            {
                new Monom {Coefficient = -15}, "-15"
            };
            yield return new object[]
            {
                new Monom {Coefficient = -15, Variable = "y", Power = 0}, "-15"
            };
            yield return new object[]
            {
                new Monom {Coefficient = 2, Power = 2, Variable = "x"}, "2x^2"
            };
            yield return new object[]
            {
                new Monom {Coefficient = -1, Power = 1, Variable = "x"}, "-x"
            };
            yield return new object[]
            {
                new Monom {Coefficient = 1, Power = 0, Variable = null}, "1"
            };
            yield return new object[]
            {
                new Monom {Coefficient = -1, Power = 0, Variable = null}, "-1"
            };
        }

        public static IEnumerable<object[]> MonomToStringCases()
        {
            yield return new object[]
            {
                new Monom {Coefficient = 7}, "+7"
            };
            yield return new object[]
            {
                new Monom {Coefficient = -15}, "-15"
            };
            yield return new object[]
            {
                new Monom {Coefficient = -15, Variable = "y", Power = 0}, "-15"
            };
            yield return new object[]
            {
                new Monom {Coefficient = 2, Power = 2, Variable = "x"}, "+2x^2"
            };
            yield return new object[]
            {
                new Monom {Coefficient = -1, Power = 1, Variable = "x"}, "-x"
            };
            yield return new object[]
            {
                new Monom {Coefficient = 1, Power = 1, Variable = "xy"}, "+xy"
            };
            yield return new object[]
            {
                new Monom {Coefficient = 1, Power = 0, Variable = null}, "+1"
            };
            yield return new object[]
            {
                new Monom {Coefficient = -1, Power = 0, Variable = null}, "-1"
            };
        }
    }
}