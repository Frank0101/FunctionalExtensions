using System;
using System.Threading.Tasks;
using FluentAssertions;
using FunctionalExtensions.Extensions.ThreadingExtensions;
using Xunit;

namespace FunctionalExtensions.Test.Extensions.ThreadingExtensions
{
    public class ValueTaskExtensionsTest
    {
        [Fact]
        public async Task Map_GivenSyncFunction_ShouldMap()
        {
            var result = await TestFunction("value")
                .Map(value => value.ToUpper());

            result.Should().Be("VALUE");
        }

        [Fact]
        public async Task FlatMap_GivenAsyncFunction_ShouldMap()
        {
            var result = await TestFunction("value")
                .FlatMap(async value =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(0.5));
                    return value.ToUpper();
                });

            result.Should().Be("VALUE");
        }

        [Fact]
        public async Task Foreach_GivenAsyncAction_ShouldExecute()
        {
            var check = "default";
            await TestFunction("value")
                .Foreach(async value =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(0.5));
                    check = value;
                });

            check.Should().Be("value");
        }

        private static async ValueTask<string> TestFunction(string value)
        {
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            return value;
        }
    }
}
