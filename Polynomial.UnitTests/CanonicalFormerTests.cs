using Polynomial.WebApi.Services;
using Xunit;

namespace Polynomial.UnitTests
{
    public class CanonicalFormerTests
    {
        [Theory]
        [InlineData("3+1+2", "6")]
        [InlineData("-4", "-4")]
        [InlineData("-103+1+2", "-100")]
        [InlineData("x+3+1+2", "x+6")]
        [InlineData("x-4-3+2", "x-5")]
        [InlineData("-x-4-3+2", "-x-5")]
        [InlineData("x+xy+y^2", "x+xy+y^2")]
        [InlineData("x+xy+y^2+abc-xy", "x+y^2+abc")]
        [InlineData("-10x^5+144y^4-z^3+102", "-10x^5+144y^4-z^3+102")]
        [InlineData("10+y^4-y^4", "10")]
        [InlineData("10+y^4+(y^4+44)", "54+2y^4")]
        [InlineData("10+y^4-(y^4+44)", "-34")]
        public void ToCanonical_ShouldBeInCanonicalForm(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            string result = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1", "1")]
        [InlineData("1345", "1345")]
        [InlineData("-1", "-1")]
        [InlineData("-102", "-102")]
        public void ToCanonical_ConstCases_ShouldBeConst(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            string result = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, result);
        }
    }
}