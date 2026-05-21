using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.RelationalModel.Abstractions;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;
using True = Pure.Primitives.Bool.True;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Tests;

public sealed record TableEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();

        ITableRelationalModel model = new TableEFCoreModel(
            id,
            new Guid(),
            new String("users")
        );

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsSchemaId()
    {
        IGuid schemaId = new Guid();

        ITableRelationalModel model = new TableEFCoreModel(
            new Guid(),
            schemaId,
            new String("users")
        );

        Assert.Equal(schemaId.GuidValue, model.SchemaId.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsName()
    {
        IString name = new String("users");

        ITableRelationalModel model = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            name
        );

        Assert.Equal(name.TextValue, model.Name.TextValue);
    }

    [Fact]
    public void ColumnsReturnsColumnsNavigation()
    {
        ICollection<ColumnEFCoreModel> columns =
        [
            new ColumnEFCoreModel(
                new Guid(),
                new Guid(),
                new String("id"),
                new Guid(),
                new ColumnTypeEFCoreModel(new Guid(), new String("int"))
            ),
        ];

        ITableRichRelationalModel model = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            new String("users"),
            columns,
            []
        );

        Assert.Equal(columns, model.Columns);
    }

    [Fact]
    public void IndexesReturnsIndexesNavigation()
    {
        ICollection<IndexEFCoreModel> indexes =
        [
            new IndexEFCoreModel(new Guid(), new Guid(), new True(), []),
        ];

        ITableRichRelationalModel model = new TableEFCoreModel(
            new Guid(),
            new Guid(),
            new String("users"),
            [],
            indexes
        );

        Assert.Equal(indexes, model.Indexes);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IGuid schemaId = new Guid();
        IString name = new String("users");
        ICollection<ColumnEFCoreModel> columns = [];
        ICollection<IndexEFCoreModel> indexes = [];

        ITableRichRelationalModel a = new TableEFCoreModel(
            id,
            schemaId,
            name,
            columns,
            indexes
        );
        ITableRichRelationalModel b = new TableEFCoreModel(
            id,
            schemaId,
            name,
            columns,
            indexes
        );

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IGuid schemaId = new Guid();
        IString name = new String("users");
        ICollection<ColumnEFCoreModel> columns = [];
        ICollection<IndexEFCoreModel> indexes = [];

        ITableRichRelationalModel a = new TableEFCoreModel(
            new Guid(),
            schemaId,
            name,
            columns,
            indexes
        );
        ITableRichRelationalModel b = new TableEFCoreModel(
            new Guid(),
            schemaId,
            name,
            columns,
            indexes
        );

        Assert.NotEqual(a, b);
    }
}
