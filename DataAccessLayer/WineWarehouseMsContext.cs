using System;
using System.Collections.Generic;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public partial class WineWarehouseMsContext : DbContext
{
    public WineWarehouseMsContext()
    {
    }

    public WineWarehouseMsContext(DbContextOptions<WineWarehouseMsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<BrewingRoom> BrewingRooms { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CheckingRequest> CheckingRequests { get; set; }

    public virtual DbSet<Export> Exports { get; set; }

    public virtual DbSet<ExportDetail> ExportDetails { get; set; }

    public virtual DbSet<Import> Imports { get; set; }

    public virtual DbSet<ImportDetail> ImportDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductLine> ProductLines { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Shelf> Shelves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-BF8E3QB\\SQLEXPRESS;database=WineWarehouseMS;uid=sa;pwd=12345;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA58667C3BD02");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.AccountName).HasMaxLength(50);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BrewingRoom>(entity =>
        {
            entity.HasKey(e => e.BrewingRoomId).HasName("PK__BrewingR__61F5FD42E8195AB5");

            entity.ToTable("BrewingRoom");

            entity.Property(e => e.BrewingRoomId).HasColumnName("BrewingRoomID");
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.RoomName).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B8409F681");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<CheckingRequest>(entity =>
        {
            entity.HasKey(e => e.CheckingRequestId).HasName("PK__Checking__F1BC9810ECABA137");

            entity.ToTable("CheckingRequest");

            entity.Property(e => e.CheckingRequestId).HasColumnName("CheckingRequestID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CheckDateRequest).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Account).WithMany(p => p.CheckingRequests)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__CheckingR__Accou__66603565");

            entity.HasOne(d => d.Product).WithMany(p => p.CheckingRequests)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__CheckingR__Produ__6754599E");
        });

        modelBuilder.Entity<Export>(entity =>
        {
            entity.HasKey(e => e.ExportId).HasName("PK__Export__E5C997A43AED36E5");

            entity.ToTable("Export");

            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");

            entity.HasOne(d => d.Account).WithMany(p => p.Exports)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Export__AccountI__5FB337D6");
        });

        modelBuilder.Entity<ExportDetail>(entity =>
        {
            entity.HasKey(e => e.ExportDetailId).HasName("PK__ExportDe__07C90359E9D4DA32");

            entity.ToTable("ExportDetail");

            entity.Property(e => e.ExportDetailId).HasColumnName("ExportDetailID");
            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.ProductLineId).HasColumnName("ProductLineID");

            entity.HasOne(d => d.Export).WithMany(p => p.ExportDetails)
                .HasForeignKey(d => d.ExportId)
                .HasConstraintName("FK__ExportDet__Expor__628FA481");

            entity.HasOne(d => d.ProductLine).WithMany(p => p.ExportDetails)
                .HasForeignKey(d => d.ProductLineId)
                .HasConstraintName("FK__ExportDet__Produ__6383C8BA");
        });

        modelBuilder.Entity<Import>(entity =>
        {
            entity.HasKey(e => e.ImportId).HasName("PK__Import__8697678A21582647");

            entity.ToTable("Import");

            entity.Property(e => e.ImportId).HasColumnName("ImportID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");

            entity.HasOne(d => d.Account).WithMany(p => p.Imports)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Import__AccountI__59063A47");
        });

        modelBuilder.Entity<ImportDetail>(entity =>
        {
            entity.HasKey(e => e.ImportDetailId).HasName("PK__ImportDe__CDFBBA5140BAC50C");

            entity.ToTable("ImportDetail");

            entity.Property(e => e.ImportDetailId).HasColumnName("ImportDetailID");
            entity.Property(e => e.ImportId).HasColumnName("ImportID");
            entity.Property(e => e.ProductLineId).HasColumnName("ProductLineID");

            entity.HasOne(d => d.Import).WithMany(p => p.ImportDetails)
                .HasForeignKey(d => d.ImportId)
                .HasConstraintName("FK__ImportDet__Impor__5BE2A6F2");

            entity.HasOne(d => d.ProductLine).WithMany(p => p.ImportDetails)
                .HasForeignKey(d => d.ProductLineId)
                .HasConstraintName("FK__ImportDet__Produ__5CD6CB2B");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDFD976499");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Origin)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__52593CB8");
        });

        modelBuilder.Entity<ProductLine>(entity =>
        {
            entity.HasKey(e => e.ProductLineId).HasName("PK__ProductL__404A74091C44EC0B");

            entity.ToTable("ProductLine");

            entity.Property(e => e.ProductLineId).HasColumnName("ProductLineID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ShelfId).HasColumnName("ShelfID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductLines)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductLi__Produ__5535A963");

            entity.HasOne(d => d.Shelf).WithMany(p => p.ProductLines)
                .HasForeignKey(d => d.ShelfId)
                .HasConstraintName("FK__ProductLi__Shelf__5629CD9C");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__D5BD48E545E14D98");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.ProductLineId).HasColumnName("ProductLineID");

            entity.HasOne(d => d.Account).WithMany(p => p.Reports)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Report__AccountI__6B24EA82");

            entity.HasOne(d => d.ProductLine).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ProductLineId)
                .HasConstraintName("FK__Report__ProductL__6A30C649");
        });

        modelBuilder.Entity<Shelf>(entity =>
        {
            entity.HasKey(e => e.ShelfId).HasName("PK__Shelf__DBD04F27D004C2DD");

            entity.ToTable("Shelf");

            entity.Property(e => e.ShelfId).HasColumnName("ShelfID");
            entity.Property(e => e.BrewingRoomId).HasColumnName("BrewingRoomID");
            entity.Property(e => e.ShelfName).HasMaxLength(50);

            entity.HasOne(d => d.BrewingRoom).WithMany(p => p.Shelves)
                .HasForeignKey(d => d.BrewingRoomId)
                .HasConstraintName("FK__Shelf__BrewingRo__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
