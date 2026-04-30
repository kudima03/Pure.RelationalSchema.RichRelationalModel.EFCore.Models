using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Guid;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models;

public sealed record IndexEFCoreModel : IIndexRichRelationalModel
{
    public IndexEFCoreModel(IGuid id, IGuid tableId, IBool isUnique)
        : this(id, tableId, isUnique, null!) { }

    public IndexEFCoreModel(
        IGuid id,
        IGuid tableId,
        IBool isUnique,
        ICollection<ColumnEFCoreModel> columnsNavigation
    )
    {
        Id = id;
        TableId = tableId;
        IsUnique = isUnique;
        ColumnsNavigation = columnsNavigation;
    }

    public IGuid Id { get; }

    public IGuid TableId { get; }

    public IBool IsUnique { get; }

    public IEnumerable<IColumn> Columns => ColumnsNavigation;

    public ICollection<ColumnEFCoreModel> ColumnsNavigation { get; }
}
