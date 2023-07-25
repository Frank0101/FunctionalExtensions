using System;
using FluentAssertions;
using FunctionalExtensions.DataTypes.TryDataTypes;
using FunctionalExtensions.Exceptions;
using Xunit;

namespace FunctionalExtensions.Tests.DataTypes
{
    public class TryDataTypesTest
    {
        [Fact]
        public void Eval_GivenSuccess_ShouldReturnSuccess()
        {
            var tryObj = Try.Eval(() => "value".ToUpper());
            tryObj.Should().BeOfType<Success<string>>().Which.Value.Should().Be("VALUE");
        }

        [Fact]
        public void Eval_GivenException_ShouldReturnFailure()
        {
            var tryObj = Try.Eval(() => ((string)null!).ToUpper());
            tryObj.Should().BeOfType<Failure<string>>()
                .Which.Error.Should().BeOfType<NullReferenceException>();
        }

        [Fact]
        public void Success_ShouldReturnSuccess()
        {
            var tryObj = Try.Success("value");
            tryObj.Should().BeOfType<Success<string>>().Which.Value.Should().Be("value");
        }

        [Fact]
        public void Failure_ShouldReturnFailure()
        {
            var error = new Exception();
            var tryObj = Try.Failure<string>(error);
            tryObj.Should().BeOfType<Failure<string>>().Which.Error.Should().Be(error);
        }

        [Fact]
        public void From_GivenValue_ShouldReturnSuccess()
        {
            var tryObj = Try.From("value");
            tryObj.Should().BeOfType<Success<string>>().Which.Value.Should().Be("value");
        }

        [Fact]
        public void From_GivenException_ShouldReturnFailure()
        {
            var error = new Exception();
            var tryObj = Try.From<string>(error);
            tryObj.Should().BeOfType<Failure<string>>().Which.Error.Should().Be(error);
        }

        [Fact]
        public void ImplicitConversion_GivenValue_ShouldReturnSuccess()
        {
            Try<string> tryObj = "value";
            tryObj.Should().BeOfType<Success<string>>().Which.Value.Should().Be("value");
        }

        [Fact]
        public void ImplicitConversion_GivenException_ShouldReturnFailure()
        {
            var error = new Exception();
            Try<string> tryObj = error;
            tryObj.Should().BeOfType<Failure<string>>().Which.Error.Should().Be(error);
        }

        [Fact]
        public void Value_GivenSuccess_ShouldReturnValue()
        {
            var tryObj = Try.Success("value");
            tryObj.Value.Should().Be("value");
        }

        [Fact]
        public void Value_GivenFailure_ShouldThrowException()
        {
            var error = new Exception();
            var tryObj = Try.Failure<string>(error);
            var check = new Func<string>(() => tryObj.Value);
            check.Should().Throw<TryIsFailureException>();
        }

        [Fact]
        public void Error_GivenSuccess_ShouldThrowException()
        {
            var tryObj = Try.Success("value");
            var check = new Func<Exception>(() => tryObj.Error);
            check.Should().Throw<TryIsSuccessException>();
        }

        [Fact]
        public void Error_GivenFailure_ShouldReturnError()
        {
            var error = new Exception();
            var tryObj = Try.Failure<string>(error);
            tryObj.Error.Should().Be(error);
        }

        [Fact]
        public void IsSuccess_GivenSuccess_ShouldBeTrue()
        {
            var tryObj = Try.Success("value");
            tryObj.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void IsSuccess_GivenFailure_ShouldBeFalse()
        {
            var error = new Exception();
            var tryObj = Try.Failure<string>(error);
            tryObj.IsSuccess.Should().BeFalse();
        }
    }
}
