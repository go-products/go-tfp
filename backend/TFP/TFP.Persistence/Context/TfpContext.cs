using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFP.Domain.Entities;

namespace TFP.Persistence.Context
{
    public class TfpContext : IdentityDbContext<User, Role, Guid>
    {
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumPhoto> AlbumPhoto { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<HairColor> HairColor { get; set; }
        public virtual DbSet<Individual> Individual { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroup { get; set; }
        public virtual DbSet<PermissionSet> PermissionSet { get; set; }
        public virtual DbSet<PermissionSetPermission> PermissionSetPermission { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Photographer> Photographer { get; set; }
        public virtual DbSet<PhotographerShootingGenre> PhotographerShootingGenre { get; set; }
        public virtual DbSet<Responded> Responded { get; set; }
        public virtual DbSet<ShootingGenre> ShootingGenre { get; set; }
        public virtual DbSet<Social> Social { get; set; }
        public virtual DbSet<SocialType> SocialType { get; set; }
        public virtual DbSet<Stylist> Stylist { get; set; }
        public virtual DbSet<StylistSpecialization> StylistSpecialization { get; set; }
        public virtual DbSet<TfpEvent> TfpEvent { get; set; }
        public virtual DbSet<TfpEventPhoto> TfpEventPhoto { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }

        public TfpContext(DbContextOptions<TfpContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=TFP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album", "Catalog");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Catalog].[AlbumId])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Individual)
                    .WithMany(p => p.AlbumIndividual)
                    .HasForeignKey(d => d.IndividualId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_Album_Membership_Individual");

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.AlbumModified)
                    .HasForeignKey(d => d.ModifiedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_Album_Membership_Individual1");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_Album_Catalog_Photo");
            });

            modelBuilder.Entity<AlbumPhoto>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.PhotoId });

                entity.ToTable("AlbumPhoto", "Catalog");

                entity.HasIndex(e => e.AlbumId)
                    .HasName("IX_Catalog_AlbumPhoto_AlbumId");

                entity.HasIndex(e => e.PhotoId)
                    .HasName("IX_Catalog_AlbumPhoto_PhotoId");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumPhoto)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_AlbumPhoto_Catalog_Album");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.AlbumPhoto)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_AlbumPhoto_Catalog_Photo");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "Lookup");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Lookup_Category_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("IX_Lookup_Category_Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City", "Lookup");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Lookup_City_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("IX_Lookup_City_Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment", "Workflow");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Workflow].[CommentId])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.CommentAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Comment_Membership_Individual");

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.CommentModified)
                    .HasForeignKey(d => d.ModifiedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Comment_Membership_Individual2");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.CommentRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Comment_Membership_Individual1");
            });

            modelBuilder.Entity<HairColor>(entity =>
            {
                entity.ToTable("HairColor", "Lookup");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Lookup_HairColor_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("IX_Lookup_HairColor_Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Individual>(entity =>
            {
                entity.ToTable("Individual", "Membership");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Membership_Social_IndividualId");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Membership].[IndividualId])");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Individual)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Individual_Lookup_Category");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Individual)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Individual_Lookup_City");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message", "Workflow");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Workflow].[MessageId])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.MessageAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Message_Membership_Individual");

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.MessageModified)
                    .HasForeignKey(d => d.ModifiedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Message_Membership_Individual2");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.MessageRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Message_Membership_Individual1");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Model", "Membership");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.HairColor)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.HairColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Model_Lookup_HairColor");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ModelIdNavigation)
                    .HasForeignKey<Model>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Model_Id_Membership_Individual");

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.ModelModified)
                    .HasForeignKey(d => d.ModifiedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Model_ModifiedId_Membership_Individual");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission", "Lookup");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Lookup_Permission_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("IX_Lookup_Permission_Order");

                entity.HasIndex(e => e.PermissionGroupId)
                    .HasName("IX_Lookup_Permission_PermissionGroupId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.PermissionGroup)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.PermissionGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lookup_Permission_Lookup_PermissionGroup");
            });

            modelBuilder.Entity<PermissionGroup>(entity =>
            {
                entity.ToTable("PermissionGroup", "Lookup");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Lookup_PermissionGroup_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("IX_Lookup_CourseStatus_Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<PermissionSet>(entity =>
            {
                entity.ToTable("PermissionSet", "Membership");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Membership_PermissionSet_Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<PermissionSetPermission>(entity =>
            {
                entity.HasKey(e => new { e.PermissionSetId, e.PermissionId });

                entity.ToTable("PermissionSetPermission", "Membership");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("IX_Membership_PermissionSetPermission_PermissionId");

                entity.HasIndex(e => e.PermissionSetId)
                    .HasName("IX_Membership_PermissionSetPermission_UserId");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionSetPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_PermissionSetPermission_Lookup_Permission");

                entity.HasOne(d => d.PermissionSet)
                    .WithMany(p => p.PermissionSetPermission)
                    .HasForeignKey(d => d.PermissionSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_PermissionSetPermission_Membership_PermissionSet");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("Photo", "Catalog");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Catalog].[PhotoId])");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.PhotoNavigation)
                    .HasForeignKey(d => d.ModifiedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catalog_Photo_Membership_Individual");
            });

            modelBuilder.Entity<Photographer>(entity =>
            {
                entity.ToTable("Photographer", "Membership");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PhotographerIdNavigation)
                    .HasForeignKey<Photographer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Photographer_Id_Membership_Individual");

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.PhotographerModified)
                    .HasForeignKey(d => d.ModifiedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Photographer_ModifiedId_Membership_Individual");
            });

            modelBuilder.Entity<PhotographerShootingGenre>(entity =>
            {
                entity.HasKey(e => new { e.PhotographerId, e.ShootingGenreId });

                entity.ToTable("PhotographerShootingGenre", "Membership");

                entity.HasIndex(e => e.PhotographerId)
                    .HasName("IX_Membership_PhotographerShootingGenre_PhotographerId");

                entity.HasIndex(e => e.ShootingGenreId)
                    .HasName("IX_Membership_PhotographerShootingGenre_ShootingGenreId");

                entity.HasOne(d => d.Photographer)
                    .WithMany(p => p.PhotographerShootingGenre)
                    .HasForeignKey(d => d.PhotographerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_PhotographerShootingGenre_Membership_Photographer");

                entity.HasOne(d => d.ShootingGenre)
                    .WithMany(p => p.PhotographerShootingGenre)
                    .HasForeignKey(d => d.ShootingGenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_PhotographerShootingGenre_Membership_ShootingGenre");
            });

            modelBuilder.Entity<Responded>(entity =>
            {
                entity.HasKey(e => new { e.TfpEventId, e.IndividualId });

                entity.ToTable("Responded", "Workflow");

                entity.HasIndex(e => e.IndividualId)
                    .HasName("IX_Workflow_Responded_IndividualId");

                entity.HasIndex(e => e.TfpEventId)
                    .HasName("IX_Workflow_Responded_TfpEventIdId");

                entity.HasOne(d => d.Individual)
                    .WithMany(p => p.Responded)
                    .HasForeignKey(d => d.IndividualId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Responded_Membership_Individual");

                entity.HasOne(d => d.TfpEvent)
                    .WithMany(p => p.Responded)
                    .HasForeignKey(d => d.TfpEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_Responded_Workflow_TfpEvent");
            });

            modelBuilder.Entity<ShootingGenre>(entity =>
            {
                entity.ToTable("ShootingGenre", "Lookup");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Lookup_ShootingGenre_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("IX_Lookup_ShootingGenre_Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Social>(entity =>
            {
                entity.HasKey(e => new { e.IndividualId, e.SocialTypeId });

                entity.ToTable("Social", "Membership");

                entity.HasOne(d => d.Individual)
                    .WithMany(p => p.Social)
                    .HasForeignKey(d => d.IndividualId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Social_Membership_Individual");

                entity.HasOne(d => d.SocialType)
                    .WithMany(p => p.Social)
                    .HasForeignKey(d => d.SocialTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Social_Membership_SocialType");
            });

            modelBuilder.Entity<SocialType>(entity =>
            {
                entity.ToTable("SocialType", "Lookup");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_Membership_Social_SocialTypeId");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Lookup_SocialType_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("IX_Lookup_SocialType_Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Stylist>(entity =>
            {
                entity.ToTable("Stylist", "Membership");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetime())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.StylistIdNavigation)
                    .HasForeignKey<Stylist>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Stylist_Id_Membership_Individual");

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.StylistModified)
                    .HasForeignKey(d => d.ModifiedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Stylist_ModifiedId_Membership_Individual");

                entity.HasOne(d => d.StylistSpecialization)
                    .WithMany(p => p.Stylist)
                    .HasForeignKey(d => d.StylistSpecializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Stylist_Lookup_StylistSpecialization");
            });

            modelBuilder.Entity<StylistSpecialization>(entity =>
            {
                entity.ToTable("StylistSpecialization", "Lookup");

                entity.HasIndex(e => e.Name)
                    .HasName("UK_Lookup_StylistSpecialization_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Order)
                    .HasName("IX_Lookup_StylistSpecialization_Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<TfpEvent>(entity =>
            {
                entity.ToTable("TfpEvent", "Workflow");

                entity.HasIndex(e => e.Title)
                    .HasName("UK_Workflow_TfpEvent_Name")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [Workflow].[TfpEventId])");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.HeldOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.TfpEventAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_TfpEvent_Membership_Individual");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TfpEvent)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_Individual_Lookup_City");

                entity.HasOne(d => d.Modified)
                    .WithMany(p => p.TfpEventModified)
                    .HasForeignKey(d => d.ModifiedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_TfpEvent_Membership_Individual1");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.TfpEvent)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK_Workflow_TfpEvent_Catalog_Photo");
            });

            modelBuilder.Entity<TfpEventPhoto>(entity =>
            {
                entity.HasKey(e => new { e.TfpEventId, e.PhotoId });

                entity.ToTable("TfpEventPhoto", "Workflow");

                entity.HasIndex(e => e.PhotoId)
                    .HasName("IX_Workflow_TfpEventPhoto_IndividualId");

                entity.HasIndex(e => e.TfpEventId)
                    .HasName("IX_Workflow_TfpEventPhoto_TfpEventId");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.TfpEventPhoto)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_TfpEventPhoto_Catalog_Photo");

                entity.HasOne(d => d.TfpEvent)
                    .WithMany(p => p.TfpEventPhoto)
                    .HasForeignKey(d => d.TfpEventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workflow_TfpEventPhoto_Workflow_TfpEvent");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Membership");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(512);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_User_Membership_Individual");

                entity.HasOne(d => d.InitialPermissionSet)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.InitialPermissionSetId)
                    .HasConstraintName("FK_Membership_User_Membership_PermissionSet");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId });

                entity.ToTable("UserPermission", "Membership");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("IX_Membership_UserPermission_PermissionId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_Membership_UserPermission_UserId");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_UserPermission_Membership_Permission");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermission)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Membership_UserPermission_Membership_User");
            });

            modelBuilder.HasSequence<int>("ApiKeyId").IncrementsBy(10);

            modelBuilder.HasSequence<int>("AlbumId").IncrementsBy(10);

            modelBuilder.HasSequence<int>("PhotoId").IncrementsBy(10);

            modelBuilder.HasSequence<int>("IndividualId").IncrementsBy(10);

            modelBuilder.HasSequence<int>("SocialId").IncrementsBy(10);

            modelBuilder.HasSequence<int>("CommentId").IncrementsBy(10);

            modelBuilder.HasSequence<int>("MessageId").IncrementsBy(10);

            modelBuilder.HasSequence<int>("TfpEventId").IncrementsBy(10);
        }
    }
}
