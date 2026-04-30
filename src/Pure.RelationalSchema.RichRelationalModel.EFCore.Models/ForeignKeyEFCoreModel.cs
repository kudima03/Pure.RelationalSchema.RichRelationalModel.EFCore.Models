using Pure.Primitives.Abstractions.Guid;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models;

public sealed record ForeignKeyEFCoreModel : IForeignKeyRichRelationalModel
{
    public ForeignKeyEFCoreModel(
        IGuid id,
        IGuid schemaId,
        IGuid referencingTableId,
        IGuid referencedTableId
    )
        : this(
            id,
            schemaId,
            referencingTableId,
            null!,
            null!,
            referencedTableId,
            null!,
            null!
        )
    { }

    public ForeignKeyEFCoreModel(
        IGuid id,
        IGuid schemaId,
        IGuid referencingTableId,
        TableEFCoreModel referencingTableNavigation,
        ICollection<ColumnEFCoreModel> referencingColumnsNavigation,
        IGuid referencedTableId,
        TableEFCoreModel referencedTableNavigation,
        ICollection<ColumnEFCoreModel> referencedColumnsNavigation
    )
    {
        Id = id;
        SchemaId = schemaId;
        ReferencingTableId = referencingTableId;
        ReferencingTableNavigation = referencingTableNavigation;
        ReferencingColumnsNavigation = referencingColumnsNavigation;
        ReferencedTableId = referencedTableId;
        ReferencedTableNavigation = referencedTableNavigation;
        ReferencedColumnsNavigation = referencedColumnsNavigation;
    }

    public IGuid Id { get; }

    public IGuid SchemaId { get; }

    public IGuid ReferencingTableId { get; }

    public ITable ReferencingTable => ReferencingTableNavigation;

    public TableEFCoreModel ReferencingTableNavigation { get; }

    public IEnumerable<IColumn> ReferencingColumns => ReferencingColumnsNavigation;

    public ICollection<ColumnEFCoreModel> ReferencingColumnsNavigation { get; }

    public IGuid ReferencedTableId { get; }

    public ITable ReferencedTable => ReferencedTableNavigation;

    public TableEFCoreModel ReferencedTableNavigation { get; }

    public IEnumerable<IColumn> ReferencedColumns => ReferencedColumnsNavigation;

    public ICollection<ColumnEFCoreModel> ReferencedColumnsNavigation { get; }
}
