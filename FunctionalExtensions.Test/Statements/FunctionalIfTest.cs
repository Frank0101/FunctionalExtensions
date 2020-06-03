using FluentAssertions;
using FunctionalExtensions.Nuget.Statements;
using Xunit;

namespace FunctionalExtensions.Test.Statements
{
    public class FunctionalIfTest
    {
        [Theory]
        [InlineData(1, "value1")]
        [InlineData(2, "value2")]
        [InlineData(3, "value3")]
        [InlineData(0, "default")]
        public void If_ShouldReturnBranchResult(int value, string expectedResult)
        {
            var result = Functional
                .If(
                    () => value == 1,
                    () => "value1")
                .ElseIf(
                    () => value == 2,
                    () => "value2")
                .ElseIf(
                    () => value == 3,
                    () => "value3")
                .Else(
                    () => "default");

            result.Should().Be(expectedResult);
        }
    }
}
