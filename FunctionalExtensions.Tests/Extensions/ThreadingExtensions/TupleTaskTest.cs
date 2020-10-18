using System;
using System.Threading.Tasks;
using FluentAssertions;
using FunctionalExtensions.Extensions.ThreadingExtensions;
using Xunit;

namespace FunctionalExtensions.Tests.Extensions.ThreadingExtensions
{
    public class TupleTaskTest
    {
        [Fact]
        public async Task WhenAll2_GivenTasks_ShouldWaitThem()
        {
            var (value1, value2) = await TupleTask.WhenAll2(TestFunction("value1"), TestFunction("value2"));
            value1.Should().Be("value1");
            value2.Should().Be("value2");
        }

        [Fact]
        public async Task WhenAll3_GivenTasks_ShouldWaitThem()
        {
            var (value1, value2, value3) = await TupleTask.WhenAll3(TestFunction("value1"), TestFunction("value2"), TestFunction("value3"));
            value1.Should().Be("value1");
            value2.Should().Be("value2");
            value3.Should().Be("value3");
        }

        private static async Task<string> TestFunction(string value)
        {
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            return value;
        }
    }
}
