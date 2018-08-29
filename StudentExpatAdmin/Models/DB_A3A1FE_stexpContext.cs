using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace studentexpat.com.Models
{
    public partial class DB_A3A1FE_stexpContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<ProgramCategories> ProgramCategories { get; set; }
        public virtual DbSet<Programs> Programs { get; set; }
        public virtual DbSet<ProgramTypes> ProgramTypes { get; set; }
        public virtual DbSet<Schools> Schools { get; set; }
        public virtual DbSet<SchoolType> SchoolType { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }
        public DB_A3A1FE_stexpContext(DbContextOptions<DB_A3A1FE_stexpContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=SQL6001.site4now.net;Initial Catalog=DB_A3A1FE_stexp;User Id=DB_A3A1FE_stexp_admin;Password=BHm_@jDF9g7XG!XF;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category1)
                    .HasColumnName("category")
                    .HasMaxLength(100);

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Languageid).HasColumnName("languageid");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.Languageid)
                    .HasConstraintName("FK_category_language");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Language1)
                    .HasColumnName("language")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProgramCategories>(entity =>
            {
                entity.ToTable("programCategories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.ProgramId).HasColumnName("programId");

                entity.Property(e => e.SubcatId).HasColumnName("subcatId");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.ProgramCategories)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_programCategories_category");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.ProgramCategories)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_programCategories_programs");

                entity.HasOne(d => d.Subcat)
                    .WithMany(p => p.ProgramCategories)
                    .HasForeignKey(d => d.SubcatId)
                    .HasConstraintName("FK_programCategories_subcategory");
            });

            modelBuilder.Entity<Programs>(entity =>
            {
                entity.ToTable("programs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FullDesc).HasColumnName("fullDesc");

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.Property(e => e.ProgramTypeId).HasColumnName("programTypeId");

                entity.Property(e => e.Schoolid).HasColumnName("schoolid");

                entity.Property(e => e.ShortDesc)
                    .HasColumnName("shortDesc")
                    .HasMaxLength(250);

                entity.Property(e => e.Tuition)
                    .HasColumnName("tuition")
                    .HasColumnType("money");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_programs_language");

                entity.HasOne(d => d.ProgramType)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.ProgramTypeId)
                    .HasConstraintName("FK_programs_programTypes");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.Schoolid)
                    .HasConstraintName("FK_programs_schools");
            });

            modelBuilder.Entity<ProgramTypes>(entity =>
            {
                entity.ToTable("programTypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProgramType)
                    .HasColumnName("programType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Schools>(entity =>
            {
                entity.ToTable("schools");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<SchoolType>(entity =>
            {
                entity.ToTable("schoolType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LanguageId).HasColumnName("languageId");

                entity.Property(e => e.SchoolType1)
                    .HasColumnName("SchoolType")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.SchoolType)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_schoolType_language");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("subcategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Languageid).HasColumnName("languageid");

                entity.Property(e => e.SubCategoryId).HasColumnName("subCategoryId");

                entity.Property(e => e.Subcategory1)
                    .HasColumnName("subcategory")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_subcategory_category");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.Languageid)
                    .HasConstraintName("FK_subcategory_language");
            });
        }
    }
}
