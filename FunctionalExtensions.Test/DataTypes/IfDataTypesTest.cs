using FluentAssertions;
using FunctionalExtensions.Nuget.DataTypes.IfDataTypes;
using FunctionalExtensions.Nuget.DataTypes.OptionDataTypes;
using Xunit;

namespace FunctionalExtensions.Test.DataTypes
{
    public class IfDataTypesTest
    {
        [Theory]
        [InlineData(1, "value1")]
        [InlineData(2, "value2")]
        [InlineData(3, "value3")]
        [InlineData(0, "default")]
        public void Eval_ShouldReturnBranchResult(int value, string expectedResult)
        {
            var result = If
                .Eval(
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

        [Fact]
        public void ToOption_WhenBranchFound_ShouldReturnSome()
        {
            var option = If
                .Eval(
                    () => true,
                    () => "value")
                .ToOption();

            option.Should().BeOfType<Some<string>>().Which.Value.Should().Be("value");
        }

        [Fact]
        public void ToOption_WhenBranchNotFound_ShouldReturnNone()
        {
            var option = If
                .Eval(
                    () => false,
                    () => "value")
                .ToOption();

            option.Should().BeOfType<None<string>>();
        }
    }
}
