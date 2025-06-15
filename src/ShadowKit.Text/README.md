# ShadowKit.Text

**ShadowKit.Text** provides tools for analyzing and comparing text, with a focus on testing and utility scenarios involving multi-line strings.

## Features

- `DetectLineEnding`  
  Detects the type of line endings in a given text. Supports detection of `\n`, `\r\n`, and `\r`.

- `StringComparerBuilder`  
  A builder for creating customized `EqualityComparer<string>` instances with extended comparison options:
  - Ignores differences in line endings
  - Performs line-by-line comparison using trimmed lines

These tools are ideal for unit tests that assert string output, especially when consistent formatting cannot be guaranteed.

## Installation

```sh
dotnet add package ShadowKit.Text
```
