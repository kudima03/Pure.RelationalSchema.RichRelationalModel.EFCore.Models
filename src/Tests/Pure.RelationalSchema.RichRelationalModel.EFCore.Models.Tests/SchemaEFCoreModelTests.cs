using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.RelationalModel.Abstractions;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Tests;

public sealed record SchemaEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();

        ISchemaRelationalModel model = new SchemaEFCoreModel(
            id,
            new String("public")
        );

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsName()
    {
        IString name = new String("public");

        ISchemaRelationalModel model = new SchemaEFCoreModel(
            new Guid(),
            name
        );

        Assert.Equal(name.TextValue, model.Name.TextValue);
    }

    [Fact]
    public void TablesReturnsTablesNavigation()
    {
        ICollection<TableEFCoreModel> tables =
        [
            new TableEFCoreModel(
                new Guid(),
                new Guid(),
                new String("users"),
                [],
                []
            ),
        ];

        ISchemaRichRelationalModel model = new SchemaEFCoreModel(
            new Guid(),
            new String("public"),
            tables,
            []
        );

        Assert.Equal(tables, model.Tables);
    }

    [Fact]
    public void ForeignKeysReturnsForeignKeysNavigation()
    {
        IEnumerable<ForeignKeyEFCoreModel> foreignKeys =
        [
            new ForeignKeyEFCoreModel(
                new Guid(),
                new Guid(),
                new Guid(),
                new TableEFCoreModel(
                    new Guid(),
                    new Guid(),
                    new String("orders"),
                    [],
                    []
                ),
                [],
                new Guid(),
                new TableEFCoreModel(
                    new Guid(),
                    new Guid(),
                    new String("users"),
                    [],
                    []
                ),
                []
            ),
        ];

        ISchemaRichRelationalModel model = new SchemaEFCoreModel(
            new Guid(),
            new String("public"),
            [],
            foreignKeys
        );

        Assert.Equal(foreignKeys, model.ForeignKeys);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IString name = new String("public");
        ICollection<TableEFCoreModel> tables = [];
        IEnumerable<ForeignKeyEFCoreModel> foreignKeys = [];

        ISchemaRichRelationalModel a = new SchemaEFCoreModel(
            id,
            name,
            tables,
            foreignKeys
        );
        ISchemaRichRelationalModel b = new SchemaEFCoreModel(
            id,
            name,
            tables,
            foreignKeys
        );

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IString name = new String("public");
        ICollection<TableEFCoreModel> tables = [];
        IEnumerable<ForeignKeyEFCoreModel> foreignKeys = [];

        ISchemaRichRelationalModel a = new SchemaEFCoreModel(
            new Guid(),
            name,
            tables,
            foreignKeys
        );
        ISchemaRichRelationalModel b = new SchemaEFCoreModel(
            new Guid(),
            name,
            tables,
            foreignKeys
        );

        Assert.NotEqual(a, b);
    }
}
