# Soothsilver.Random
Classes, methods and extension methods dealing with randomness, shuffling, and auxiliary classes and methods

The static class "R" contains static methods "Next", "NextDouble" and "NextFloat" which use an internal static Random instance, and also contains extension methods "Shuffle" (which randomizes a list), "GetRandom" (which takes a random element from a list) and "GetRandomWithoutReplacement" (which takes a number of random unique elements from a list).

It's on NuGet: https://www.nuget.org/packages/Soothsilver.Random/1.1.0

To install with NuGet: Install-Package Soothsilver.Random -Version 1.1.0	
If you don't want to use NuGet, just put the file `R.cs` into your project.
