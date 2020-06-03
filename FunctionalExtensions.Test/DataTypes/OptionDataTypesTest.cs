using System;
using FluentAssertions;
using FunctionalExtensions.Nuget.DataTypes.OptionDataTypes;
using FunctionalExtensions.Nuget.Exceptions;
using Xunit;

namespace FunctionalExtensions.Test.DataTypes
{
    public class OptionDataTypesTest
    {
        [Fact]
        public void Some_GivenValue_ShouldReturnSome()
        {
            var option = Option.Some("value");
            option.Should().BeOfType<Some<string>>().Which.Value.Should().Be("value");
        }

        [Fact]
        public void Some_GivenNull_ShouldThrowException()
        {
            var check = new Action(() => Option.Some((string)null));
            check.Should().Throw<OptionValueNullException>();
        }

        [Fact]
        public void None_ShouldReturnNone()
        {
            var option = Option.None<string>();
            option.Should().BeOfType<None<string>>();
        }

        [Fact]
        public void From_GivenValue_ShouldReturnSome()
        {
            var option = Option.From("value");
            option.Should().BeOfType<Some<string>>().Which.Value.Should().Be("value");
        }

        [Fact]
        public void From_GivenNull_ShouldReturnNone()
        {
            var option = Option.From((string)null);
            option.Should().BeOfType<None<string>>();
        }

        [Fact]
        public void ImplicitConversion_GivenValue_ShouldReturnSome()
        {
            Option<string> option = "value";
            option.Should().BeOfType<Some<string>>().Which.Value.Should().Be("value");
        }

        [Fact]
        public void ImplicitConversion_GivenNull_ShouldReturnNone()
        {
            Option<string> option = (string)null;
            option.Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Value_GivenSome_ShouldReturnValue()
        {
            var option = Option.Some("value");
            option.Value.Should().Be("value");
        }

        [Fact]
        public void Value_GivenNone_ShouldThrowException()
        {
            var option = Option.None<string>();
            var check = new Func<string>(() => option.Value);
            check.Should().Throw<OptionValueNullException>();
        }

        [Fact]
        public void IsDefined_GivenSome_ShouldBeTrue()
        {
            var option = Option.Some("value");
            option.IsDefined.Should().BeTrue();
        }

        [Fact]
        public void IsDefined_GivenNone_ShouldBeFalse()
        {
            var option = Option.None<string>();
            option.IsDefined.Should().BeFalse();
        }

        [Fact]
        public void IsEmpty_GivenSome_ShouldBeFalse()
        {
            var option = Option.Some("value");
            option.IsEmpty.Should().BeFalse();
        }

        [Fact]
        public void IsEmpty_GivenNone_ShouldBeTrue()
        {
            var option = Option.None<string>();
            option.IsEmpty.Should().BeTrue();
        }

        [Fact]
        public void NonEmpty_GivenSome_ShouldBeTrue()
        {
            var option = Option.Some("value");
            option.NonEmpty.Should().BeTrue();
        }

        [Fact]
        public void NonEmpty_GivenNone_ShouldBeFalse()
        {
            var option = Option.None<string>();
            option.NonEmpty.Should().BeFalse();
        }

        [Fact]
        public void OrElse_GivenSome_ShouldReturnSelf()
        {
            var option = Option.Some("value");
            var defaultOption = Option.Some("default");
            option.OrElse(defaultOption).Should().Be(option);
        }

        [Fact]
        public void OrElse_GivenSome_WhenLazy_ShouldReturnSelf()
        {
            var option = Option.Some("value");
            var defaultOption = Option.Some("default");
            option.OrElse(() => defaultOption).Should().Be(option);
        }

        [Fact]
        public void OrElse_GivenNone_ShouldReturnDefault()
        {
            var option = Option.None<string>();
            var defaultOption = Option.Some("default");
            option.OrElse(defaultOption).Should().Be(defaultOption);
        }

        [Fact]
        public void OrElse_GivenNone_WhenLazy_ShouldReturnDefault()
        {
            var option = Option.None<string>();
            var defaultOption = Option.Some("default");
            option.OrElse(() => defaultOption).Should().Be(defaultOption);
        }

        [Fact]
        public void GetOrElse_GivenSome_ShouldReturnValue()
        {
            var option = Option.Some("value");
            const string defaultValue = "default";
            option.GetOrElse(defaultValue).Should().Be("value");
        }

        [Fact]
        public void GetOrElse_GivenNone_ShouldReturnDefault()
        {
            var option = Option.None<string>();
            const string defaultValue = "default";
            option.GetOrElse(defaultValue).Should().Be("default");
        }

        [Fact]
        public void Get_GivenSome_ShouldReturnValue()
        {
            var option = Option.Some("value");
            option.Get().Should().Be("value");
        }

        [Fact]
        public void Get_GivenNone_ShouldThrowException()
        {
            var option = Option.None<string>();
            var check = new Action(() => option.Get());
            check.Should().Throw<OptionValueNullException>();
        }

        [Fact]
        public void Fold_GivenSome_ShouldReturnMappedValue()
        {
            var option = Option.Some("value");
            const string defaultValue = "[default]";
            option.Fold(defaultValue, value => $"[{value}]").Should().Be("[value]");
        }

        [Fact]
        public void Fold_GivenNone_ShouldReturnDefault()
        {
            var option = Option.None<string>();
            const string defaultValue = "[default]";
            option.Fold(defaultValue, value => $"[{value}]").Should().Be("[default]");
        }

        [Fact]
        public void Map_GivenSome_ShouldReturnMappedOption()
        {
            var option = Option.Some("value");
            option.Map(value => $"[{value}]").Should().BeOfType<Some<string>>()
                .Which.Value.Should().Be("[value]");
        }

        [Fact]
        public void Map_GivenNone_ShouldReturnNone()
        {
            var option = Option.None<string>();
            option.Map(value => $"[{value}]").Should().BeOfType<None<string>>();
        }

        [Fact]
        public void FlatMap_GivenSome_ShouldReturnMappedOption()
        {
            var option = Option.Some("value");
            option.FlatMap(value => Option.Some($"[{value}]")).Should().BeOfType<Some<string>>()
                .Which.Value.Should().Be("[value]");
        }

        [Fact]
        public void FlatMap_GivenNone_ShouldReturnNone()
        {
            var option = Option.None<string>();
            option.FlatMap(value => Option.Some($"[{value}]")).Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Foreach_GivenSome_ShouldExecuteAction()
        {
            var option = Option.Some("value");
            var check = "default";
            option.Foreach(value => check = value);
            check.Should().Be("value");
        }

        [Fact]
        public void Foreach_GivenNone_ShouldIgnoreAction()
        {
            var option = Option.None<string>();
            var check = "default";
            option.Foreach(value => check = value);
            check.Should().Be("default");
        }

        [Fact]
        public void Collect_GivenSome_WhenMappingReturnsValue_ShouldReturnMappedOption()
        {
            var option = Option.Some("value");
            option.Collect(value => $"[{value}]").Should().BeOfType<Some<string>>()
                .Which.Value.Should().Be("[value]");
        }

        [Fact]
        public void Collect_GivenSome_WhenMappingReturnsNull_ShouldReturnNone()
        {
            var option = Option.Some("value");
            option.Collect(value => (string)null).Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Collect_GivenNone_ShouldReturnNone()
        {
            var option = Option.None<string>();
            option.Collect(value => $"[{value}]").Should().BeOfType<None<string>>();
            option.Collect(value => (string)null).Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Filter_GivenSome_WhenPredicateReturnsTrue_ShouldReturnSelf()
        {
            var option = Option.Some("value");
            option.Filter(value => true).Should().Be(option);
        }

        [Fact]
        public void Filter_GivenSome_WhenPredicateReturnsFalse_ShouldReturnNone()
        {
            var option = Option.Some("value");
            option.Filter(value => false).Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Filter_GivenNone_ShouldReturnSelf()
        {
            var option = Option.None<string>();
            option.Filter(value => true).Should().Be(option);
            option.Filter(value => false).Should().Be(option);
        }

        [Fact]
        public void FilterNot_GivenSome_WhenPredicateReturnsTrue_ShouldReturnNone()
        {
            var option = Option.Some("value");
            option.FilterNot(value => true).Should().BeOfType<None<string>>();
        }

        [Fact]
        public void FilterNot_GivenSome_WhenPredicateReturnsFalse_ShouldReturnSelf()
        {
            var option = Option.Some("value");
            option.FilterNot(value => false).Should().Be(option);
        }

        [Fact]
        public void FilterNot_GivenNone_ShouldReturnSelf()
        {
            var option = Option.None<string>();
            option.FilterNot(value => true).Should().Be(option);
            option.FilterNot(value => false).Should().Be(option);
        }

        [Fact]
        public void Exists_GivenSome_WhenPredicateReturnsTrue_ShouldReturnTrue()
        {
            var option = Option.Some("value");
            option.Exists(value => true).Should().BeTrue();
        }

        [Fact]
        public void Exists_GivenSome_WhenPredicateReturnsFalse_ShouldReturnFalse()
        {
            var option = Option.Some("value");
            option.Exists(value => false).Should().BeFalse();
        }

        [Fact]
        public void Exists_GivenNone_ShouldReturnFalse()
        {
            var option = Option.None<string>();
            option.Exists(value => true).Should().BeFalse();
            option.Exists(value => false).Should().BeFalse();
        }

        [Fact]
        public void ForAll_GivenSome_WhenPredicateReturnsTrue_ShouldReturnTrue()
        {
            var option = Option.Some("value");
            option.ForAll(value => true).Should().BeTrue();
        }

        [Fact]
        public void ForAll_GivenSome_WhenPredicateReturnsFalse_ShouldReturnFalse()
        {
            var option = Option.Some("value");
            option.ForAll(value => false).Should().BeFalse();
        }

        [Fact]
        public void ForAll_GivenNone_ShouldReturnTrue()
        {
            var option = Option.None<string>();
            option.ForAll(value => true).Should().BeTrue();
            option.ForAll(value => false).Should().BeTrue();
        }

        [Fact]
        public void Contains_GivenSome_WhenContainsValue_ShouldReturnTrue()
        {
            var option = Option.Some("value");
            option.Contains("value").Should().BeTrue();
        }

        [Fact]
        public void Contains_GivenSome_WhenDoesNotContainValue_ShouldReturnFalse()
        {
            var option = Option.Some("value");
            option.Contains("other").Should().BeFalse();
        }

        [Fact]
        public void Contains_GivenNone_ShouldReturnFalse()
        {
            var option = Option.None<string>();
            option.Contains("value").Should().BeFalse();
        }

        [Fact]
        public void Zip_GivenSome_WhenOtherOptionIsSome_ShouldReturnSome()
        {
            var option = Option.Some("value");
            option.Zip(Option.Some("other")).Should().BeOfType<Some<(string, string)>>()
                .Which.Value.Should().Be(("value", "other"));
        }

        [Fact]
        public void Zip_GivenSome_WhenOtherOptionIsNone_ShouldReturnNone()
        {
            var option = Option.Some("value");
            option.Zip(Option.None<string>()).Should().BeOfType<None<(string, string)>>();
        }

        [Fact]
        public void Zip_GivenNone_ShouldReturnNone()
        {
            var option = Option.None<string>();
            option.Zip(Option.Some("other")).Should().BeOfType<None<(string, string)>>();
            option.Zip(Option.None<string>()).Should().BeOfType<None<(string, string)>>();
        }

        [Fact]
        public void ToList_GivenSome_ShouldReturnListWithValue()
        {
            var option = Option.Some("value");
            option.ToList().Should().Contain("value");
        }

        [Fact]
        public void ToList_GivenNone_ShouldReturnEmptyList()
        {
            var option = Option.None<string>();
            option.ToList().Should().BeEmpty();
        }

        [Fact]
        public void Unzip_GivenSome_ShouldReturnOptions()
        {
            var option = Option.Some(("value", (string)null));
            var (result1, result2) = option.Unzip();
            result1.Should().BeOfType<Some<string>>().Which.Value.Should().Be("value");
            result2.Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Unzip_GivenNone_ShouldReturnEmptyOptions()
        {
            var option = Option.None<(string, string)>();
            var (result1, result2) = option.Unzip();
            result1.Should().BeOfType<None<string>>();
            result2.Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Unzip3_GivenSome_ShouldReturnOptions()
        {
            var option = Option.Some(("value1", "value2", (string)null));
            var (result1, result2, result3) = option.Unzip3();
            result1.Should().BeOfType<Some<string>>().Which.Value.Should().Be("value1");
            result2.Should().BeOfType<Some<string>>().Which.Value.Should().Be("value2");
            result3.Should().BeOfType<None<string>>();
        }

        [Fact]
        public void Unzip3_GivenNone_ShouldReturnEmptyOptions()
        {
            var option = Option.None<(string, string, string)>();
            var (result1, result2, result3) = option.Unzip3();
            result1.Should().BeOfType<None<string>>();
            result2.Should().BeOfType<None<string>>();
            result3.Should().BeOfType<None<string>>();
        }
    }
}
