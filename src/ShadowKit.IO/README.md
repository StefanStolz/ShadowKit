# ShadowKit.IO

**ShadowKit.IO** is a utility package that provides tools for working with the file system in temporary and test-driven scenarios.

## Features

- `TransientFileManager`  
  A utility class for creating temporary files with predefined content. Useful for test cases where temporary files are needed.

- `TransientDirectoryManager`  
  A utility class for creating and managing temporary directories. Automatically handles cleanup and is ideal for testing file-based workflows.

## Installation

```sh
dotnet add package ShadowKit.IO
```