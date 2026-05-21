using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.RelationalModel.Abstractions;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models.Tests;

public sealed record ColumnTypeEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();
        IString name = new String("varchar");

        IColumnTypeRelationalModel model = new ColumnTypeEFCoreModel(id, name);

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsName()
    {
        IGuid id = new Guid();
        IString name = new String("varchar");

        IColumnTypeRelationalModel model = new ColumnTypeEFCoreModel(id, name);

        Assert.Equal(name.TextValue, model.Name.TextValue);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IString name = new String("varchar");

        IColumnTypeRelationalModel a = new ColumnTypeEFCoreModel(id, name);
        IColumnTypeRelationalModel b = new ColumnTypeEFCoreModel(id, name);

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IString name = new String("varchar");

        IColumnTypeRelationalModel a = new ColumnTypeEFCoreModel(new Guid(), name);
        IColumnTypeRelationalModel b = new ColumnTypeEFCoreModel(new Guid(), name);

        Assert.NotEqual(a, b);
    }
}
