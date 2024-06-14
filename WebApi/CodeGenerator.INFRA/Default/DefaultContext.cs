using CodeGenerator.DOMAIN.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.INFRA.Default
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sys");

            modelBuilder.Entity<Table>()
                .ToTable("objects");

            modelBuilder.Entity<Column>()
                .ToTable("columns");

            modelBuilder.Entity<ColumnType>()
               .ToTable("types");

            modelBuilder.Entity<Relation>()
               .ToTable("foreign_key_columns");

            modelBuilder.Entity<Indexes>()
               .ToTable("indexes");

            modelBuilder.Entity<IndexColumns>()
               .ToTable("index_columns");

            modelBuilder.Entity<IndexColumns>()
                .HasKey(t => t.index_column_id);

            modelBuilder.Entity<Indexes>()
                .HasKey(t => t.index_id);

            modelBuilder.Entity<Table>()
                .HasKey(t => t.object_id);

            modelBuilder.Entity<Column>()
               .HasKey(t => t.column_id);

            modelBuilder.Entity<ColumnType>()
               .HasKey(t => t.user_type_id);

            modelBuilder.Entity<Relation>()
               .HasKey(t => t.constraint_object_id);

            modelBuilder.Entity<Table>()
                .HasMany(t => t.Columns)
                .WithOne(t => t.Table)
                .HasForeignKey(t => t.object_id);

            modelBuilder.Entity<Column>()
               .HasOne(t => t.Table)
               .WithMany(c => c.Columns)
               .HasForeignKey(c => c.object_id);

            modelBuilder.Entity<Column>()
                .HasOne(c => c.ColumnType)
                .WithMany(ct => ct.Column)
                .HasForeignKey(ct => ct.system_type_id);

            modelBuilder.Entity<ColumnType>()
              .HasMany(t => t.Column)
              .WithOne(t => t.ColumnType)
              .HasForeignKey(c => c.system_type_id);

            modelBuilder.Entity<Relation>()
              .HasOne(t => t.ParentTable)
              .WithMany(t => t.ParentRelations)
              .HasForeignKey(c => c.parent_object_id);

            modelBuilder.Entity<Relation>()
              .HasOne(t => t.RelatedTable)
              .WithMany(t => t.RelatedRelations)
              .HasForeignKey(c => c.referenced_object_id);

            modelBuilder.Entity<Relation>()
              .HasOne(t => t.ParentColumn)
              .WithMany(t => t.ParentRelations)
              .HasForeignKey(fk => new { fk.parent_object_id, fk.parent_column_id })
              .HasPrincipalKey(c2 => new { c2.object_id, c2.column_id });

            modelBuilder.Entity<Relation>()
              .HasOne(t => t.RelatedColumn)
              .WithMany(t => t.RelatedRelations)
              .HasForeignKey(fk => new { fk.referenced_object_id, fk.referenced_column_id })
              .HasPrincipalKey(c2 => new { c2.object_id, c2.column_id });

            modelBuilder.Entity<Indexes>()
                .HasMany(x => x.IndexColumns)
                .WithOne(x => x.Indexes)
                .HasForeignKey(fk => new { fk.index_id, fk.object_id })
                .HasPrincipalKey(c2 => new { c2.index_id, c2.object_id });

            modelBuilder.Entity<IndexColumns>()
                .HasOne(x => x.Column)
                .WithMany(x => x.IndexColumns)
                .HasForeignKey(fk => new { fk.object_id, fk.column_id })
                .HasPrincipalKey(c2 => new { c2.object_id, c2.column_id });

            modelBuilder.Entity<IndexColumns>()
                .HasOne(x => x.Indexes)
                .WithMany(x => x.IndexColumns)
                .HasForeignKey(fk => new { fk.object_id, fk.index_id })
                .HasPrincipalKey(c2 => new { c2.object_id, c2.index_id });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);

        public DbSet<Table> Tables { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<ColumnType> ColumnTypes { get; set; }
        public DbSet<Relation> Relations { get; set; }
    }
}
