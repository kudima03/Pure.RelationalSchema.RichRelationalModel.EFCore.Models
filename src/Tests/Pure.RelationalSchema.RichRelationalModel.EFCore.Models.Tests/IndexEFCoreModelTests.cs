using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Guid;
using Pure.RelationalSchema.RelationalModel.Abstractions;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;
using True = Pure.Primitives.Bool.True;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Tests;

public sealed record IndexEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();

        IIndexRelationalModel model = new IndexEFCoreModel(id, new Guid(), new True());

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsTableId()
    {
        IGuid tableId = new Guid();

        IIndexRelationalModel model = new IndexEFCoreModel(
            new Guid(),
            tableId,
            new True()
        );

        Assert.Equal(tableId.GuidValue, model.TableId.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsIsUnique()
    {
        IBool isUnique = new True();

        IIndexRelationalModel model = new IndexEFCoreModel(
            new Guid(),
            new Guid(),
            isUnique
        );

        Assert.Equal(isUnique.BoolValue, model.IsUnique.BoolValue);
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

        IIndexRichRelationalModel model = new IndexEFCoreModel(
            new Guid(),
            new Guid(),
            new True(),
            columns
        );

        Assert.Equal(columns, model.Columns);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IGuid tableId = new Guid();
        IBool isUnique = new True();
        ICollection<ColumnEFCoreModel> columns = [];

        IIndexRichRelationalModel a = new IndexEFCoreModel(
            id,
            tableId,
            isUnique,
            columns
        );
        IIndexRichRelationalModel b = new IndexEFCoreModel(
            id,
            tableId,
            isUnique,
            columns
        );

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IGuid tableId = new Guid();
        IBool isUnique = new True();
        ICollection<ColumnEFCoreModel> columns = [];

        IIndexRichRelationalModel a = new IndexEFCoreModel(
            new Guid(),
            tableId,
            isUnique,
            columns
        );
        IIndexRichRelationalModel b = new IndexEFCoreModel(
            new Guid(),
            tableId,
            isUnique,
            columns
        );

        Assert.NotEqual(a, b);
    }
}
