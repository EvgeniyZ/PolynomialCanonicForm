using System.Collections;
using System.Collections.Generic;
using Polynomial.WebApi.Entities;
using Xunit;

namespace Polynomial.UnitTests
{
    public class MonomTests
    {
        [Theory]
        [MemberData(nameof(MonomToStringCases))]
        public void ToString_ShouldBeAsExpected(Monom monom, string expected)
        {
            Assert.Equal(expected, monom.ToString());
        }

        public static IEnumerable<object[]> MonomToStringCases()
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
        }
    }
}