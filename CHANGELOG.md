# Changelog

All notable changes to Pure.RelationalSchema.RichRelationalModel.EFCore.Models are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.0.1.0] — 2026-04-30

### Added

Entity Framework Core-friendly implementations of the rich relational model
abstractions, each exposing navigation collections/records alongside the
interface-required members:

- **`SchemaEFCoreModel`** — implements `ISchemaRichRelationalModel`, with
  `TablesNavigation` (`ICollection<TableEFCoreModel>`) and
  `ForeignKeysNavigation` (`IEnumerable<ForeignKeyEFCoreModel>`) backing the
  `Tables` and `ForeignKeys` members.
- **`TableEFCoreModel`** — implements `ITableRichRelationalModel`, with
  `ColumnsNavigation` and `IndexesNavigation` collections backing `Columns`
  and `Indexes`.
- **`ColumnEFCoreModel`** — implements `IColumnRichRelationalModel`, with a
  `TypeNavigation` (`ColumnTypeEFCoreModel`) backing `Type`.
- **`ColumnTypeEFCoreModel`** — implements `IColumnTypeRichRelationalModel`.
- **`IndexEFCoreModel`** — implements `IIndexRichRelationalModel`, with a
  `ColumnsNavigation` collection backing `Columns`.
- **`ForeignKeyEFCoreModel`** — implements `IForeignKeyRichRelationalModel`,
  with `ReferencingTableNavigation`/`ReferencedTableNavigation`
  (`TableEFCoreModel`) and `ReferencingColumnsNavigation`/
  `ReferencedColumnsNavigation` (`ICollection<ColumnEFCoreModel>`) backing
  the corresponding table and column members.

All models target `net7.0`, `net8.0`, `net9.0`, and `net10.0`, and depend on
`Pure.RelationalSchema.RichRelationalModel.Abstractions`.
