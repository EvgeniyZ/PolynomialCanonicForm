using Polynomial.WebApi.Services;
using Xunit;

namespace Polynomial.UnitTests
{
    public class CanonicalFormerTests
    {
        [Theory]
        [InlineData("12=")]
        [InlineData("123+222=123+")]
        [InlineData("123+222-123+")]
        [InlineData("123+222-123+=")]
        [InlineData("123=21+")]
        [InlineData("(")]
        [InlineData("+")]
        [InlineData("-")]
        [InlineData("*")]
        [InlineData("@")]
        [InlineData("123+456=123+(")]
        public void ToCanonical_InvalidExpression_ShouldReturnErrorMessage(string expression)
        {
            var canonicalFormer = new CanonicalFormer();

            (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

            Assert.NotEmpty(errorMessage);
        }

        [Theory]
        [InlineData("12=44", "-32")]
        [InlineData("x^2+3.5xy+y=y^2-xy+y", "x^2-y^2+4.5xy=0")]
        [InlineData("-(22+44x^2)+(11+44y^2)-(123)=55-asd+a^2", "-44x^2+44y^2-a^2+asd-189=0")]
        public void ToCanonical_EqualityExpression_ShouldBeInCanonicalForm(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, canonical);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("                     ")]
        public void ToCanonical_EmptyExpression_ShouldBeErrorMessage(string expression)
        {
            var canonicalFormer = new CanonicalFormer();

            (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

            Assert.NotEmpty(errorMessage);
        }

        [Theory]
        [InlineData("       10    +      y^4        +(y^4+    44         )", "2y^4+54")]
        [InlineData("10+y^      4-(       y^4        +      44)", "-34")]
        public void ToCanonical_ExpressionsWithWhitespaces_ShouldBeInCanonicalForm(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, canonical);
        }

        [Theory]
        [InlineData("10+y^4+(y^4+44)", "2y^4+54")]
        [InlineData("10+y^4-(y^4+44)", "-34")]
        [InlineData("-(10+y^4+(y^4+44))", "-2y^4-54")]
        [InlineData("10+(y^4-(y^4+44))", "-34")]
        [InlineData("-(22+44x^2)+(11+44y^2)-(123)", "-44x^2+44y^2-134")]
        [InlineData("10+y^4+(y^4+44) = 12", "2y^4+42=0")]
        public void ToCanonical_ExpressionWithBrackets_ShouldBeInCanonicalForm(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, canonical);
        }

        [Theory]
        [InlineData("x+3+1+2", "x+6")]
        [InlineData("x-4-3+2", "x-5")]
        [InlineData("-x-4-3+2", "-x-5")]
        [InlineData("x+xy+y^2", "y^2+xy+x")]
        [InlineData("x+xy+y^2+abc-xy", "y^2+abc+x")]
        [InlineData("-10x^5+144y^4-z^3+102", "-10x^5+144y^4-z^3+102")]
        [InlineData("10+y^4-y^4", "10")]
        public void ToCanonical_ShouldBeInCanonicalForm(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, canonical);
        }

        [Theory]
        [InlineData("3+1+2", "6")]
        [InlineData("-103+1+2", "-100")]
        [InlineData("99.66+123+4", "226.66")]
        [InlineData("+99.66+123+4", "226.66")]
        [InlineData("-99.66+176+33.11", "109.45")]
        public void ToCanonical_ConstantAddSub_ShouldBeConst(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, canonical);
        }

        [Theory]
        [InlineData("1", "1")]
        [InlineData("1345", "1345")]
        [InlineData("-1", "-1")]
        [InlineData("-102", "-102")]
        [InlineData("-4", "-4")]
        public void ToCanonical_ConstCases_ShouldBeConst(string expression, string expected)
        {
            var canonicalFormer = new CanonicalFormer();

            (string canonical, string errorMessage) = canonicalFormer.ToCanonical(expression);

            Assert.Equal(expected, canonical);
        }
    }
}