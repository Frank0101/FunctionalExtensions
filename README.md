# FunctionalExtensions

This library extends C# to provide a set of functional programming features.

Unlike other libraries attempting the same, here the idea is to build a simple, light-weight
set of helpers and types to make functional programming easier and more idiomatic, but without
twisting too much the language and accepting the imperative nature of C#, as well as it's
inherent limitations.

Therefore, between a clear, intuitive C# syntax and a perfect functional implementation, the
choice will always be for the first one.

If what you see reminds you Scala it's not a coincidence. Scala is what I'm using as reference
for it's hybrid nature that makes it a good example of what C# could aim to be.

- [Option](#option)
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
|`Option<T> OrElse(Func<Option<T>> defaultFunction)`|Evaluate and return alternate optional value if empty (Lazy)|
|`T GetOrElse(T defaultValue)`|Evaluate and return alternate value if empty|
|`T Get()`|Return value, throw exception if empty|
|`T2 Fold<T2>(T2 defaultValue, Func<T, T2> mapFunction)`|Apply function on optional value, return default if empty|
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
