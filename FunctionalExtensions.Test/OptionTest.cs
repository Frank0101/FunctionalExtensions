using System;
using FluentAssertions;
using FunctionalExtensions.Nuget;
using Xunit;

namespace FunctionalExtensions.Test
{
    public class OptionTest
    {
        [Fact]
        public void Constructor_ShouldReturnNone()
        {
            var option = new Option<int>();
            option.IsDefined.Should().BeFalse();
        }

        [Fact]
        public void None_ShouldReturnEmptyOption()
        {
            var option = Option<int>.None;
            option.IsDefined.Should().BeFalse();
        }

        [Fact]
        public void None_ShouldReturnSameEmptyOption()
        {
            var option1 = Option<int>.None;
            var option2 = Option<int>.None;
            option1.Should().Be(option2);
        }

        [Fact]
        public void Some_GivenValue_ShouldReturnDefinedOption()
        {
            var option = Option<int>.Some(1);
            option.IsDefined.Should().BeTrue();
        }

        [Fact]
        public void Some_GivenNull_ShouldThrowException()
        {
            Action action = () => Option<string>.Some(null);
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
