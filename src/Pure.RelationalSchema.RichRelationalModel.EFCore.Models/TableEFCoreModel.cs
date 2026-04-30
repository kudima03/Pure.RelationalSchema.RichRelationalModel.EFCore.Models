using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.Column;
using Pure.RelationalSchema.Abstractions.Index;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models;

public sealed record TableEFCoreModel : ITableRichRelationalModel
{
    public TableEFCoreModel(IGuid id, IGuid schemaId, IString name)
        : this(id, schemaId, name, null!, null!) { }

    public TableEFCoreModel(
        IGuid id,
        IGuid schemaId,
        IString name,
        ICollection<ColumnEFCoreModel> columnsNavigation,
        ICollection<IndexEFCoreModel> indexesNavigation
    )
    {
        Id = id;
        SchemaId = schemaId;
        Name = name;
        ColumnsNavigation = columnsNavigation;
        IndexesNavigation = indexesNavigation;
    }

    public IGuid Id { get; }

    public IGuid SchemaId { get; }

    public IString Name { get; }

    public IEnumerable<IColumn> Columns => ColumnsNavigation;

    public IEnumerable<IIndex> Indexes => IndexesNavigation;

    public ICollection<ColumnEFCoreModel> ColumnsNavigation { get; }

    public ICollection<IndexEFCoreModel> IndexesNavigation { get; }
}
