# C# Unit Testing Project

This project is a review of Unit Testing in C# based on the [YouTube tutorial by Teddy Smith](https://www.youtube.com/playlist?list=PL82C6-O4XrHeyeJcI5xrywgpfbrqdkQd4). The project contains UnitTesting for variouse objects like strings, numbers, dataes and collections. In addtion, a review about Unit Testing of <VC web controllers and testing Web Api controllers

## Frameworks

- .NET Core 7
- xUnit
- FluentAssertions
- FakeItEasy

## Things to Note for Writing Unit Tests

### 1. Naming Convention

When naming your tests, follow the correct naming convention: `ClassName_MethodName_ExpectedResult`.

### 2. Swallow the Catch

When catching exceptions in your tests, do not throw them. It's best to log them to the console or write them in a log file.

### 3. Follow the Triple A Rule

When writing unit tests, follow the 3A rule:

- **Arrange:** Get the variables, classes, methods, and any objects needed for this function to work.
- **Act:** Execute the function.
- **Assert:** Confirm by checking whether what you are testing returns what you expected.

### 4. Using SUTs [System Under Test]

Make the object you are testing available globally.

## Tests Involve

1. Testing for strings, datetimes, collections, numbers etc
2. Unit testing Web API Controllers
3. Unit Testing MVC Controllers

## Getting Started

1. Clone the repository.
2. Open the project in your preferred C# development environment (e.g., Visual Studio, Visual Studio Code).
3. Build and run the tests.

## Contributing

Feel free to contribute by opening issues or submitting pull requests. Follow the guidelines in the [CONTRIBUTING.md](CONTRIBUTING.md) file.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
