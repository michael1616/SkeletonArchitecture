using Microsoft.EntityFrameworkCore;
using XYZPlatform.Models.Models;

namespace XYZPlatform.DataAccess.Conection;

public partial class DBXYZ : DbContext
{
    public DBXYZ()
    {
    }

    public DBXYZ(DbContextOptions<DBXYZ> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activiti__3214EC07C46475AC");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Times__3214EC07AC01B4DE");

            entity.Property(e => e.DateActivity).HasColumnType("date");

            entity.HasOne(d => d.IdActivityNavigation).WithMany(p => p.Times)
                .HasForeignKey(d => d.IdActivity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Times__IdActivit__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
