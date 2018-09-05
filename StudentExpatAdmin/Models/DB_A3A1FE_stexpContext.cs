using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace studentexpat.com.Models
{
    public partial class DB_A3A1FE_stexpContext : DbContext
    {
        public virtual DbSet<Agreements> Agreements { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Enrollments> Enrollments { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<ProgramCategories> ProgramCategories { get; set; }
        public virtual DbSet<Programs> Programs { get; set; }
        public virtual DbSet<ProgramTypes> ProgramTypes { get; set; }
        public virtual DbSet<Schools> Schools { get; set; }
        public virtual DbSet<SchoolType> SchoolType { get; set; }
        public virtual DbSet<Students> Students { get; set; }
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
            modelBuilder.Entity<Agreements>(entity =>
            {
                entity.ToTable("agreements");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Agreement)
                    .HasColumnName("agreement")
                    .HasMaxLength(500);

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasMaxLength(150);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500);

                entity.Property(e => e.FollowUp)
                    .HasColumnName("followUp")
                    .HasColumnType("date");

                entity.Property(e => e.SchoolId).HasColumnName("schoolId");

                entity.Property(e => e.SignedOn)
                    .HasColumnName("signedOn")
                    .HasColumnType("date");

                entity.Property(e => e.Warnings)
                    .HasColumnName("warnings")
                    .HasMaxLength(500);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Agreements)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_agreements_schools");
            });

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

            modelBuilder.Entity<Enrollments>(entity =>
            {
                entity.ToTable("enrollments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Agent)
                    .HasColumnName("agent")
                    .HasMaxLength(50);

                entity.Property(e => e.Comission)
                    .HasColumnName("comission")
                    .HasColumnType("money");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DatePaid)
                    .HasColumnName("datePaid")
                    .HasColumnType("date");

                entity.Property(e => e.Followup)
                    .HasColumnName("followup")
                    .HasColumnType("date");

                entity.Property(e => e.ProgramId).HasColumnName("programId");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.Tuition)
                    .HasColumnName("tuition")
                    .HasColumnType("money");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_enrollments_programs");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_enrollments_student");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Language1)
                    .HasColumnName("language")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("nationality");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nationality1)
                    .HasColumnName("nationality")
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

            modelBuilder.Entity<Students>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CurrentStudent).HasColumnName("currentStudent");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150);

                entity.Property(e => e.FollowUp)
                    .HasColumnName("followUp")
                    .HasColumnType("date");

                entity.Property(e => e.LastEnrollment)
                    .HasColumnName("lastEnrollment")
                    .HasMaxLength(150);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Nationality).HasColumnName("nationality");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.TotalCommision)
                    .HasColumnName("totalCommision")
                    .HasColumnType("money");

                entity.Property(e => e.TotalTuition)
                    .HasColumnName("totalTuition")
                    .HasColumnType("money");
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
