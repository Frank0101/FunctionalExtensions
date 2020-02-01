namespace FunctionalExtensions.Test.Statements
{
    public class FunctionalIfTest
    {
        /*
        [Fact]
        public void WhenThenBranchIsValid_ShouldEnterThatAndOnlyThat()
        {
            const int value = 1;
            var predicateCheck = 0;
            var resultFunctionCheck = 0;

            var result = Functional.If(() =>
                {
                    predicateCheck++;
                    return value == 1;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 1";
                })
                .ElseIf(() =>
                {
                    predicateCheck++;
                    return value == 2;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 2";
                })
                .ElseIf(() =>
                {
                    predicateCheck++;
                    return value == 3;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 3";
                })
                .Else(() =>
                {
                    resultFunctionCheck++;
                    return "branch N";
                });

            predicateCheck.Should().Be(1);
            resultFunctionCheck.Should().Be(1);
            result.Should().Be("branch 1");
        }

        [Fact]
        public void WhenElseIfBranchIsValid_ShouldEnterThatAndOnlyThat()
        {
            const int value = 2;
            var predicateCheck = 0;
            var resultFunctionCheck = 0;

            var result = Functional.If(() =>
                {
                    predicateCheck++;
                    return value == 1;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 1";
                })
                .ElseIf(() =>
                {
                    predicateCheck++;
                    return value == 2;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 2";
                })
                .ElseIf(() =>
                {
                    predicateCheck++;
                    return value == 3;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 3";
                })
                .Else(() =>
                {
                    resultFunctionCheck++;
                    return "branch N";
                });

            predicateCheck.Should().Be(2);
            resultFunctionCheck.Should().Be(1);
            result.Should().Be("branch 2");
        }

        [Fact]
        public void WhenElseBranchIsValid_ShouldEnterThatAndOnlyThat()
        {
            const int value = 0;
            var predicateCheck = 0;
            var resultFunctionCheck = 0;

            var result = Functional.If(() =>
                {
                    predicateCheck++;
                    return value == 1;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 1";
                })
                .ElseIf(() =>
                {
                    predicateCheck++;
                    return value == 2;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 2";
                })
                .ElseIf(() =>
                {
                    predicateCheck++;
                    return value == 3;
                }, () =>
                {
                    resultFunctionCheck++;
                    return "branch 3";
                })
                .Else(() =>
                {
                    resultFunctionCheck++;
                    return "branch N";
                });

            predicateCheck.Should().Be(3);
            resultFunctionCheck.Should().Be(1);
            result.Should().Be("branch N");
        }

        [Fact]
        public void ToOption_WhenValidBranchFound_ShouldReturnSome()
        {
            const int value = 2;

            var result = Functional.If(() => value == 1, () => "branch 1")
                .ElseIf(() => value == 2, () => "branch 2")
                .ToOption();

            result.Should().Be(Option.Some("branch 2"));
        }

        [Fact]
        public void ToOption_WhenValidBranchNotFound_ShouldReturnNone()
        {
            const int value = 0;

            var result = Functional.If(() => value == 1, () => "branch 1")
                .ElseIf(() => value == 2, () => "branch 2")
                .ToOption();

            result.Should().Be(Option.None<string>());
        }
    */
    }
}
