# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format && csharpier format .           # auto-fix code style
dotnet test --no-restore                      # run xunit tests
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

## Architecture

This is a **concrete implementation NuGet library** — six `sealed record` types, one per file, implementing the Rich Relational Model interfaces from `Pure.RelationalSchema.RichRelationalModel.Abstractions`.

**Dual-surface pattern:** every record exposes two property surfaces:
- The abstract interface contract (e.g. `IEnumerable<ITable> Tables`) — consumed by domain and application code.
- Typed EFCore navigation properties (e.g. `ICollection<TableEFCoreModel> TablesNavigation`) — consumed by EFCore's change tracker and query materialisation. The interface property delegates to the navigation property.

**Record hierarchy:**
- `SchemaEFCoreModel` — top-level; owns `TablesNavigation` and `ForeignKeysNavigation`
- `TableEFCoreModel` — child of schema; owns `ColumnsNavigation` and `IndexesNavigation`
- `ColumnEFCoreModel` — child of table; references `ColumnTypeEFCoreModel` via `TypeNavigation`
- `ForeignKeyEFCoreModel` — child of schema; references two `TableEFCoreModel` instances and their columns
- `IndexEFCoreModel` — child of table; references columns via `ColumnsNavigation`
- `ColumnTypeEFCoreModel` — leaf; no navigation properties

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All records must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 0.1.0-preview.0.1.0`. Adding or removing public members fails the build.

**Tests:** xunit project under `./src/Tests/`, targeting net10.0 only. CI enforces 100% line coverage and 100% mutation score (dotnet-stryker).

**Publishing:** triggered by pushing a semver tag. The tag value becomes `PackageVersion`. Packages are published to both GitHub Packages and NuGet.org.

## Code Style

Enforced via `.editorconfig` and `dotnet format --verify-no-changes` in CI:

- No `var` — always use explicit types, even when the type is apparent.
- No expression-bodied methods or constructors.
- Accessibility modifiers required on all members (`dotnet_style_require_accessibility_modifiers = always`).
- Fields must be `readonly` where possible.
- Private fields use `_camelCase` prefix.

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
