using Pure.Primitives.Abstractions.Guid;
using Pure.RelationalSchema.RelationalModel.Abstractions;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Tests;

public sealed record ForeignKeyEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();

        IForeignKeyRelationalModel model = new ForeignKeyEFCoreModel(
            id,
            new Guid(),
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("orders"), [], []),
            [],
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("users"), [], []),
            []
        );

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsSchemaId()
    {
        IGuid schemaId = new Guid();

        IForeignKeyRelationalModel model = new ForeignKeyEFCoreModel(
            new Guid(),
            schemaId,
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("orders"), [], []),
            [],
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("users"), [], []),
            []
        );

        Assert.Equal(schemaId.GuidValue, model.SchemaId.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsReferencingTableId()
    {
        IGuid referencingTableId = new Guid();

        IForeignKeyRelationalModel model = new ForeignKeyEFCoreModel(
            new Guid(),
            new Guid(),
            referencingTableId,
            new TableEFCoreModel(new Guid(), new Guid(), new String("orders"), [], []),
            [],
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("users"), [], []),
            []
        );

        Assert.Equal(referencingTableId.GuidValue, model.ReferencingTableId.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsReferencedTableId()
    {
        IGuid referencedTableId = new Guid();

        IForeignKeyRelationalModel model = new ForeignKeyEFCoreModel(
            new Guid(),
            new Guid(),
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("orders"), [], []),
            [],
            referencedTableId,
            new TableEFCoreModel(new Guid(), new Guid(), new String("users"), [], []),
            []
        );

        Assert.Equal(referencedTableId.GuidValue, model.ReferencedTableId.GuidValue);
    }

    [Fact]
    public void ReferencingTableReturnsReferencingTableNavigation()
    {
        TableEFCoreModel referencingTable = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            new String("orders"),
            [],
            []
        );

        IForeignKeyRichRelationalModel model = new ForeignKeyEFCoreModel(
            new Guid(),
            new Guid(),
            new Guid(),
            referencingTable,
            [],
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("users"), [], []),
            []
        );

        Assert.Equal(referencingTable, model.ReferencingTable);
    }

    [Fact]
    public void ReferencedTableReturnsReferencedTableNavigation()
    {
        TableEFCoreModel referencedTable = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            new String("users"),
            [],
            []
        );

        IForeignKeyRichRelationalModel model = new ForeignKeyEFCoreModel(
            new Guid(),
            new Guid(),
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("orders"), [], []),
            [],
            new Guid(),
            referencedTable,
            []
        );

        Assert.Equal(referencedTable, model.ReferencedTable);
    }

    [Fact]
    public void ReferencingColumnsReturnsReferencingColumnsNavigation()
    {
        ICollection<ColumnEFCoreModel> referencingColumns =
        [
            new ColumnEFCoreModel(
                new Guid(),
                new Guid(),
                new String("user_id"),
                new Guid(),
                new ColumnTypeEFCoreModel(new Guid(), new String("int"))
            ),
        ];

        IForeignKeyRichRelationalModel model = new ForeignKeyEFCoreModel(
            new Guid(),
            new Guid(),
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("orders"), [], []),
            referencingColumns,
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("users"), [], []),
            []
        );

        Assert.Equal(referencingColumns, model.ReferencingColumns);
    }

    [Fact]
    public void ReferencedColumnsReturnsReferencedColumnsNavigation()
    {
        ICollection<ColumnEFCoreModel> referencedColumns =
        [
            new ColumnEFCoreModel(
                new Guid(),
                new Guid(),
                new String("id"),
                new Guid(),
                new ColumnTypeEFCoreModel(new Guid(), new String("int"))
            ),
        ];

        IForeignKeyRichRelationalModel model = new ForeignKeyEFCoreModel(
            new Guid(),
            new Guid(),
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("orders"), [], []),
            [],
            new Guid(),
            new TableEFCoreModel(new Guid(), new Guid(), new String("users"), [], []),
            referencedColumns
        );

        Assert.Equal(referencedColumns, model.ReferencedColumns);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IGuid schemaId = new Guid();
        IGuid referencingTableId = new Guid();
        TableEFCoreModel referencingTable = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            new String("orders"),
            [],
            []
        );
        ICollection<ColumnEFCoreModel> referencingColumns = [];
        IGuid referencedTableId = new Guid();
        TableEFCoreModel referencedTable = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            new String("users"),
            [],
            []
        );
        ICollection<ColumnEFCoreModel> referencedColumns = [];

        IForeignKeyRichRelationalModel a = new ForeignKeyEFCoreModel(
            id,
            schemaId,
            referencingTableId,
            referencingTable,
            referencingColumns,
            referencedTableId,
            referencedTable,
            referencedColumns
        );
        IForeignKeyRichRelationalModel b = new ForeignKeyEFCoreModel(
            id,
            schemaId,
            referencingTableId,
            referencingTable,
            referencingColumns,
            referencedTableId,
            referencedTable,
            referencedColumns
        );

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IGuid schemaId = new Guid();
        IGuid referencingTableId = new Guid();
        TableEFCoreModel referencingTable = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            new String("orders"),
            [],
            []
        );
        ICollection<ColumnEFCoreModel> referencingColumns = [];
        IGuid referencedTableId = new Guid();
        TableEFCoreModel referencedTable = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            new String("users"),
            [],
            []
        );
        ICollection<ColumnEFCoreModel> referencedColumns = [];

        IForeignKeyRichRelationalModel a = new ForeignKeyEFCoreModel(
            new Guid(),
            schemaId,
            referencingTableId,
            referencingTable,
            referencingColumns,
            referencedTableId,
            referencedTable,
            referencedColumns
        );
        IForeignKeyRichRelationalModel b = new ForeignKeyEFCoreModel(
            new Guid(),
            schemaId,
            referencingTableId,
            referencingTable,
            referencingColumns,
            referencedTableId,
            referencedTable,
            referencedColumns
        );

        Assert.NotEqual(a, b);
    }
}
