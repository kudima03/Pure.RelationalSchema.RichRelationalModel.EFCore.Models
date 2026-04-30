using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ColumnType;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models;

public sealed record ColumnEFCoreModel : IColumnRichRelationalModel
{
    public ColumnEFCoreModel(IGuid id, IGuid tableId, IString name, IGuid typeId)
        : this(id, tableId, name, typeId, null!) { }

    public ColumnEFCoreModel(
        IGuid id,
        IGuid tableId,
        IString name,
        IGuid typeId,
        ColumnTypeEFCoreModel typeNavigation
    )
    {
        Id = id;
        TableId = tableId;
        Name = name;
        TypeId = typeId;
        TypeNavigation = typeNavigation;
    }

    public IGuid Id { get; }

    public IGuid TableId { get; }

    public IString Name { get; }

    public IGuid TypeId { get; }

    public IColumnType Type => TypeNavigation;

    public ColumnTypeEFCoreModel TypeNavigation { get; }
}
