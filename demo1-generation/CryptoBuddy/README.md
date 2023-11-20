# CryptoBuddy

CryptoBuddy is a C# library that provides utilities for cryptography. It includes a class called `SimmetricBuddy` that can be used to encrypt and decrypt streams using the Advanced Encryption Standard (AES).

## Usage

To use the `SimmetricBuddy` class, you need to create an instance of it and then call the `EncryptStream` or `DecryptStream` methods.

Here is an example:

```csharp
var buddy = new SimmetricBuddy();
var encryptedStream = buddy.EncryptStream(originalStream);
var decryptedStream = buddy.DecryptStream(encryptedStream);
```

In this example, `originalStream` is the stream that you want to encrypt. The `EncryptStream` method returns a new stream that contains the encrypted data. The `DecryptStream` method takes an encrypted stream and returns a new stream that contains the original data.

## Running the Tests

The project includes a set of unit tests that you can run to verify the functionality of the `SimmetricBuddy` class. The tests are located in the `CryptoBuddy.Tests` project.

To run the tests, you can use the `dotnet test` command:

```bash
dotnet test
```

This command will build the project, run the tests, and display the results in the console.

## GitHub Actions

The project includes a GitHub Actions workflow that automatically runs gitversion, executes the tests, creates a NuGet package, and pushes it to NuGet whenever you push changes to the repository.

You can view the results of the workflow in the "Actions" tab of the GitHub repository.

## Contributing

If you want to contribute to the project, feel free to submit a pull request. If you find a bug or have a suggestion for improvement, please open an issue.