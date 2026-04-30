using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models;

public sealed record ColumnTypeEFCoreModel : IColumnTypeRichRelationalModel
{
    public ColumnTypeEFCoreModel(IGuid id, IString name)
    {
        Id = id;
        Name = name;
    }

    public IGuid Id { get; }

    public IString Name { get; }
}
