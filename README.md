# Pure.RelationalSchema.RichRelationalModel.EFCore.Models

Entity Framework Core models implementing the **Rich Relational Model** abstractions for database schema introspection within the Pure ecosystem.

[![Build & Test](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore.Models/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore.Models/actions/workflows/build-and-test.yml)
[![Publish NuGet](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore.Models/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.EFCore.Models/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema.RichRelationalModel.EFCore.Models)](https://www.nuget.org/packages/Pure.RelationalSchema.RichRelationalModel.EFCore.Models)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema.RichRelationalModel.EFCore.Models` provides concrete `sealed record` implementations of the Rich Relational Model interfaces defined in [`Pure.RelationalSchema.RichRelationalModel.Abstractions`](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.Abstractions). Each record exposes both the abstract contract properties required by the interface and typed EFCore navigation properties (`*Navigation`) for use with Entity Framework Core's change tracker and query materialisation.

## Models

| Type | Implements | Description |
|------|------------|-------------|
| `SchemaEFCoreModel` | `ISchemaRichRelationalModel` | A database schema containing tables and foreign keys. Navigation: `TablesNavigation`, `ForeignKeysNavigation`. |
| `TableEFCoreModel` | `ITableRichRelationalModel` | A table within a schema, containing columns and indexes. Navigation: `ColumnsNavigation`, `IndexesNavigation`. |
| `ColumnEFCoreModel` | `IColumnRichRelationalModel` | A column with a name, a foreign key to its parent table, and a type reference. Navigation: `TypeNavigation`. |
| `ForeignKeyEFCoreModel` | `IForeignKeyRichRelationalModel` | A foreign key relationship with referencing and referenced tables and their respective columns. Navigation: `ReferencingTableNavigation`, `ReferencedTableNavigation`, `ReferencingColumnsNavigation`, `ReferencedColumnsNavigation`. |
| `IndexEFCoreModel` | `IIndexRichRelationalModel` | A database index with a uniqueness flag and the columns it covers. Navigation: `ColumnsNavigation`. |
| `ColumnTypeEFCoreModel` | `IColumnTypeRichRelationalModel` | A column data type identified by an `IGuid` and named with an `IString`. |

All records are in the `Pure.RelationalSchema.RichRelationalModel.EFCore.Models` namespace.

## Design Principles

- **Dual surface** — each record satisfies the abstract interface contract (used by domain code) and exposes strongly-typed navigation properties (used by EFCore).
- **Immutable** — all properties are `init`-only; no setters are exposed.
- **AOT-compatible** — the library is marked `IsAotCompatible = true` and safe for NativeAOT and trimming scenarios.

## Dependencies

- [`Pure.RelationalSchema.RichRelationalModel.Abstractions`](https://github.com/kudima03/Pure.RelationalSchema.RichRelationalModel.Abstractions/tree/0.1.0-preview.0.1.0) — interfaces that every model in this package implements (`ISchemaRichRelationalModel`, `ITableRichRelationalModel`, `IColumnRichRelationalModel`, `IForeignKeyRichRelationalModel`, `IIndexRichRelationalModel`, `IColumnTypeRichRelationalModel`).

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```bash
dotnet add package Pure.RelationalSchema.RichRelationalModel.EFCore.Models
```

## Usage

```csharp
// Construct a column type and column, then wire them into a table inside a schema.
var columnType = new ColumnTypeEFCoreModel(id: someGuid, name: someName);

var column = new ColumnEFCoreModel(
    id: columnGuid,
    tableId: tableGuid,
    name: columnName,
    typeId: columnType.Id,
    typeNavigation: columnType);

var table = new TableEFCoreModel(
    id: tableGuid,
    schemaId: schemaGuid,
    name: tableName,
    columnsNavigation: [column],
    indexesNavigation: []);

var schema = new SchemaEFCoreModel(
    id: schemaGuid,
    name: schemaName,
    tablesNavigation: [table],
    foreignKeysNavigation: []);

// The abstract interface is available anywhere ISchemaRichRelationalModel is expected.
ISchemaRichRelationalModel richModel = schema;
```
