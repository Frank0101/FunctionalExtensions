using FluentAssertions;
using FunctionalExtensions.Nuget.DataTypes.OptionDataTypes;
using FunctionalExtensions.Nuget.Statements;
using Xunit;

namespace FunctionalExtensions.Test.DataTypes
{
    public class IfDataTypesTest
    {
        [Fact]
        public void ToOption_WhenBranchFound_ShouldReturnSome()
        {
            var option = Functional
                .If(
                    () => true,
                    () => "branch")
                .ToOption();

            option.Should().BeOfType<Some<string>>().Which.Value.Should().Be("branch");
        }

        [Fact]
        public void ToOption_WhenBranchNotFound_ShouldReturnNone()
        {
            var option = Functional
                .If(
                    () => false,
                    () => "branch")
                .ToOption();

            option.Should().BeOfType<None<string>>();
        }
    }
}
