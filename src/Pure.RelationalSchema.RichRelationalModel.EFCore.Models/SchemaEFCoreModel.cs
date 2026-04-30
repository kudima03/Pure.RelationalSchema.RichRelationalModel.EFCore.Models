using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Pure.RelationalSchema.Abstractions.ForeignKey;
using Pure.RelationalSchema.Abstractions.Table;
using Pure.RelationalSchema.RichRelationalModel.Abstractions;

namespace Pure.RelationalSchema.RichRelationalModel.EFCore.Models;

public sealed record SchemaEFCoreModel : ISchemaRichRelationalModel
{
    public SchemaEFCoreModel(IGuid id, IString name)
        : this(id, name, null!, null!) { }

    public SchemaEFCoreModel(
        IGuid id,
        IString name,
        ICollection<TableEFCoreModel> tablesNavigation,
        IEnumerable<ForeignKeyEFCoreModel> foreignKeysNavigation
    )
    {
        Id = id;
        Name = name;
        TablesNavigation = tablesNavigation;
        ForeignKeysNavigation = foreignKeysNavigation;
    }

    public IGuid Id { get; }

    public IString Name { get; }

    public IEnumerable<ITable> Tables => TablesNavigation;

    public ICollection<TableEFCoreModel> TablesNavigation { get; }

    public IEnumerable<IForeignKey> ForeignKeys => ForeignKeysNavigation;

    public IEnumerable<ForeignKeyEFCoreModel> ForeignKeysNavigation { get; }
}
