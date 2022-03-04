using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopList.Domain.Entities;

namespace ShopList.Infra.Mappings
{
    public class BoardMappings : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.ToTable("boards");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("uuid").HasColumnName("id").IsRequired();
            builder.Property(x => x.UserId).HasColumnType("varchar(100)").HasColumnName("user_id").IsRequired();
            builder.Property(x => x.Name).HasColumnType("varchar(100)").HasColumnName("name").IsRequired();
            builder.Property(x => x.Description).HasColumnType("varchar(300)").HasColumnName("description");

            builder.Property(x => x.CreatedAt).HasColumnType("timestamp with time zone").HasColumnName("created_at").IsRequired();
            builder.Property(x => x.DeletedAt).HasColumnType("timestamp with time zone").HasColumnName("deleted_at");

            builder.HasMany(x => x.BoardItems).WithOne(x => x.Board).HasForeignKey(x => x.BoardId);
        }
    }
}
