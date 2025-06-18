[![NuGet](https://img.shields.io/nuget/v/ShadowKit.svg)](https://www.nuget.org/packages/ShadowKit)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build](https://img.shields.io/github/actions/workflow/status/StefanStolz/ShadowKit/build.yml?branch=main)](https://github.com/StefanStolz/ShadowKit/actions)

# ShadowKit

**ShadowKit** is a set of tools designed to support different development scenarios, especially in testing and utility contexts. It consists of several specialized sub-packages, each focusing on a specific area of functionality.

## Packages

### [ShadowKit.IO](https://www.nuget.org/packages/ShadowKit.IO)

This package provides tools for working with the file system. It is particularly useful in test scenarios that require temporary file or directory structures.

**Included tools:**

- `TransientFileManager`  
  A utility for creating temporary files with predefined content. The files are automatically cleaned up after use.

- `TransientDirectoryManager`  
  A utility for managing temporary directories, useful for scenarios that require short-lived folder structures.

These tools are especially helpful in unit tests where temporary and isolated file system resources are needed.

### [ShadowKit.Text](https://www.nuget.org/packages/ShadowKit.Text)

This package provides tools for working with text.

**Included tools:**

- `DetectLineEnding`  
  Detects the type of line endings used in a given text (e.g., `\n`, `\r\n`, `\r`).

- `StringComparerBuilder`  
  Builds `EqualityComparer<string>` instances with extended comparison capabilities, especially useful for comparing multi-line strings. Features include:
    - Ignoring differences in line endings
    - Comparing multi-line text line by line using trimmed lines

These tools are particularly helpful in test scenarios where flexible and robust string comparison is required.

### [ShadowKit.Threading](https://www.nuget.org/packages/ShadowKit.Threading)

This package provides tools for simulating a `SynchronizationContext`, which can be useful in unit tests that need to test asynchronous code in a controlled threading environment.

---

## Getting Started

To install the full ShadowKit meta package:

```sh
dotnet add package ShadowKit
```

Or install individual packages as needed:

```sh
dotnet add package ShadowKit.IO
dotnet add package ShadowKit.Text
dotnet add package ShadowKit.Threading
```

## License
ShadowKit is released under the MIT License.
