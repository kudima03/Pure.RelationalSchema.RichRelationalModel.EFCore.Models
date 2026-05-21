using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.RelationalModel.Abstractions;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Tests;

public sealed record ColumnEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();

        IColumnRelationalModel model = new ColumnEFCoreModel(
            id,
            new Guid(),
            new String("column_name"),
            new Guid()
        );

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsTableId()
    {
        IGuid tableId = new Guid();

        IColumnRelationalModel model = new ColumnEFCoreModel(
            new Guid(),
            tableId,
            new String("column_name"),
            new Guid()
        );

        Assert.Equal(tableId.GuidValue, model.TableId.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsName()
    {
        IString name = new String("column_name");

        IColumnRelationalModel model = new ColumnEFCoreModel(
            new Guid(),
            new Guid(),
            name,
            new Guid()
        );

        Assert.Equal(name.TextValue, model.Name.TextValue);
    }

    [Fact]
    public void ConstructorAssignsTypeId()
    {
        IGuid typeId = new Guid();

        IColumnRelationalModel model = new ColumnEFCoreModel(
            new Guid(),
            new Guid(),
            new String("column_name"),
            typeId
        );

        Assert.Equal(typeId.GuidValue, model.TypeId.GuidValue);
    }

    [Fact]
    public void TypeReturnsTypeNavigation()
    {
        ColumnTypeEFCoreModel typeNavigation = new ColumnTypeEFCoreModel(
            new Guid(),
            new String("int")
        );

        IColumnRichRelationalModel model = new ColumnEFCoreModel(
            new Guid(),
            new Guid(),
            new String("column_name"),
            new Guid(),
            typeNavigation
        );

        Assert.Equal(typeNavigation, model.Type);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IGuid tableId = new Guid();
        IString name = new String("column_name");
        IGuid typeId = new Guid();
        ColumnTypeEFCoreModel typeNavigation = new ColumnTypeEFCoreModel(
            new Guid(),
            new String("varchar")
        );

        IColumnRichRelationalModel a = new ColumnEFCoreModel(
            id,
            tableId,
            name,
            typeId,
            typeNavigation
        );
        IColumnRichRelationalModel b = new ColumnEFCoreModel(
            id,
            tableId,
            name,
            typeId,
            typeNavigation
        );

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IGuid tableId = new Guid();
        IString name = new String("column_name");
        IGuid typeId = new Guid();
        ColumnTypeEFCoreModel typeNavigation = new ColumnTypeEFCoreModel(
            new Guid(),
            new String("varchar")
        );

        IColumnRichRelationalModel a = new ColumnEFCoreModel(
            new Guid(),
            tableId,
            name,
            typeId,
            typeNavigation
        );
        IColumnRichRelationalModel b = new ColumnEFCoreModel(
            new Guid(),
            tableId,
            name,
            typeId,
            typeNavigation
        );

        Assert.NotEqual(a, b);
    }
}
