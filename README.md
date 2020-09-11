# FunctionalExtensions

![.NET Core](https://github.com/Frank0101/FunctionalExtensions/workflows/.NET%20Core/badge.svg?branch=master)
[![Nuget](https://img.shields.io/nuget/v/FunctionalExtensions.Nuget)](https://www.nuget.org/packages/FunctionalExtensions.Nuget)

This library extends C# to provide a set of functional programming features.

Unlike other libraries attempting the same, here the idea is to build a simple, light-weight
set of helpers and types to make functional programming easier and more idiomatic, but without
twisting too much the language and accepting the imperative nature of C#, as well as it's
inherent limitations.

Therefore, between a clear, intuitive C# syntax and a perfect functional implementation, the
choice will always fall on the first one.

If what you see reminds you Scala it's not a coincidence. Scala is what I'm using as reference
for it's hybrid nature that makes it a good example of what C# could aim to be.

- [Option](#option)
- [Try and Functional Try](#try-and-functional-try)
- [Functional If](#functional-if)

## Option

[Scala Reference](https://www.scala-lang.org/api/current/scala/Option.html)

Represent an optional value. Instances of `Option<T>` are either an instance of `Some<T>` or `None<T>`.

> The most idiomatic way to use an `Option<T>` instance is to treat it as a collection with 0 or 1 elements
> and use `Map`, `FlatMap`, `Filter` and `Foreach`

### Creating an Option

Explicit:
```c#
var option = Option.Some("value"); // Throw exception if null
var option = Option.None<string>();
```

From value:
```c#
var option = Option.From("value"); // Option is Some("value")
var option = Option.From((string)null); // Option is None
```

Implicit conversion:
```c#
Option<string> option = "value"; // Option is Some("value")
Option<string> option = (string)null; // Option is None
```

### Pattern Matching and Deconstruction

```c#
var result = myOption switch
{
    Some<string>(var value) => value,
    _ => "default"
};
```

### Option Members

|Member|Description|
|---|---|
|`T Value`|Return value, throw exception if empty|
|`bool IsDefined`|True if not empty|
|`bool IsEmpty`|True if empty|
|`bool NonEmpty`|True if not empty|
|`Option<T> OrElse(Option<T> defaultOption)`|Evaluate and return alternate optional value if empty|
|`Option<T> OrElse(Func<Option<T>> defaultFunction)`|Evaluate and return alternate optional value if empty (lazy)|
|`T GetOrElse(T defaultValue)`|Evaluate and return alternate value if empty|
|`T GetOrElse(Func<T> defaultFunction)`|Evaluate and return alternate value if empty (lazy)|
|`T Get()`|Return value, throw exception if empty|
|`T2 Fold<T2>(T2 defaultValue, Func<T, T2> mapFunction)`|Apply function on optional value, return default if empty|
|`T2 Fold<T2>(Func<T2> defaultFunction, Func<T, T2> mapFunction)`|Apply function on optional value, return default if empty (lazy)|
|`Option<T2> Map<T2>(Func<T, T2> mapFunction)`|Apply a function on the optional value|
|`Option<T2> FlatMap<T2>(Func<T, Option<T2>> mapFunction)`|Same as `Map` but function must return an optional value|
|`void Foreach(Action<T> action)`|Apply a procedure on option value|
|`Option<T2> Collect<T2>(Func<T, T2> mapFunction)`|Apply partial pattern match on optional value|
|`Option<T> Filter(Func<T, bool> predicate)`|An optional value satisfies predicate|
|`Option<T> FilterNot(Func<T, bool> predicate)`|An optional value doesn't satisfy predicate|
|`bool Exists(Func<T, bool> predicate)`|Apply predicate on optional value, or false if empty|
|`bool ForAll(Func<T, bool> predicate)`|Apply predicate on optional value, or true if empty|
|`bool Contains(T value)`|Checks if value equals optional value, or false if empty|
|`Option<(T, T2)> Zip<T2>(Option<T2> otherOption)`|Combine two optional values to make a paired optional value|
|`List<T> ToList()`|Unary list of optional value, otherwise the empty list|
|`(Option<T1>, Option<T2>) Unzip<T1, T2>(this Option<(T1, T2)> option)`|Split an optional pair to two optional values|
|`(Option<T1>, Option<T2>, Option<T3>) Unzip3<T1, T2, T3>(this Option<(T1, T2, T3)> option)`|Split an optional triple to three optional values|

## Try and Functional Try

[Scala Reference](https://www.scala-lang.org/api/current/scala/util/Try.html)

The `Try` type represents a computation that may either result in an exception, or return a successfully
computed value. It's similar to, but semantically different from the `Either` type.

Instances of `Try<T>`, are either an instance of `Success<T>` or `Failure<T>`.

> For example, `Try` can be used to evaluate non-pure functions, without the need to do explicit
> exception-handling in all of the places that an exception might occur.

### Creating a Try

Functional Try:
```c#
var tryObj = Try.Eval(() => "value".ToUpper()); // Try is Success("VALUE")
var tryObj = Try.Eval(() => ((string)null).ToUpper()); // Try is Failure(error)
```

Explicit:
```c#
var tryObj = Try.Success("value"); // Try is Success("value")
var tryObj = Try.Failure<string>(new Exception());  // Try is Failure(error)
```

From value:
```c#
var tryObj = Try.From("value"); // Try is Success("value")
var tryObj = Try.From<string>(new Exception());  // Try is Failure(error)
```

Implicit conversion:
```c#
Try<string> tryObj = "value"; // Try is Success("value")
Try<string> tryObj = new Exception();  // Try is Failure(error)
```

### Pattern Matching and Deconstruction

```c#
var result = tryObj switch
{
    Success<string>(var value) => value,
    Failure<string>(var error) => error.Message
};
```

### Try Members

|Member|Description|
|---|---|
|`T Value`|Return value, throw exception if failure|
|`Exception Error`|Return error, throw exception if success|
|`bool IsSuccess`|True if success|

## Functional If

### Usage

Exhaustive matching:
```c#
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
```

Partial matching:
> Return Some(value) if a predicate was satisfied, None otherwise
```c#
var option = If
    .Eval(
        () => value == 1,
        () => "value1")
    .ElseIf(
        () => value == 2,
        () => "value2")
    .ElseIf(
        () => value == 3,
        () => "value3")
    .ToOption();
```
