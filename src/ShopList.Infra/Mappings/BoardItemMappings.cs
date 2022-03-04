using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopList.Domain.Entities;

namespace ShopList.Infra.Mappings
{
    public class BoardItemMappings : IEntityTypeConfiguration<BoardItem>
    {
        public void Configure(EntityTypeBuilder<BoardItem> builder)
        {
            builder.ToTable("board_item");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("uuid").HasColumnName("id").IsRequired();
            builder.Property(x => x.BoardId).HasColumnType("uuid").HasColumnName("board_id").IsRequired();
            builder.Property(x => x.Finished).HasColumnType("bool").HasColumnName("finished").IsRequired();
            builder.Property(x => x.Name).HasColumnType("varchar(100)").HasColumnName("name").IsRequired();
            builder.Property(x => x.Amount).HasColumnType("int").HasColumnName("amount").IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("decimal").HasColumnName("unit_price");

            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasColumnName("created_at").IsRequired();
            builder.Property(x => x.DeletedAt).HasColumnType("timestamp with time zone").HasColumnName("deleted_at");

            builder.HasOne(x => x.Board);
        }
    }
}
