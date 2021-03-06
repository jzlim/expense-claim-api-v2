// <auto-generated />
using System;
using ExpenseClaimApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpenseClaimApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExpenseClaimApi.Models.ClaimItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GlCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ClaimItems");
                });

            modelBuilder.Entity("ExpenseClaimApi.Models.ExpenseClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BankAccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ClaimDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExpenseClaims");
                });

            modelBuilder.Entity("ExpenseClaimApi.Models.ExpenseClaimLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("ClaimItemId")
                        .HasColumnType("int");

                    b.Property<string>("CostCenter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ExchangeRate")
                        .HasColumnType("real");

                    b.Property<int>("ExpenseClaimId")
                        .HasColumnType("int");

                    b.Property<float>("Gst")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClaimItemId");

                    b.HasIndex("ExpenseClaimId");

                    b.ToTable("ExpenseClaimLines");
                });

            modelBuilder.Entity("ExpenseClaimApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BankAccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExpenseClaimApi.Models.ExpenseClaim", b =>
                {
                    b.HasOne("ExpenseClaimApi.Models.User", "User")
                        .WithMany("ExpenseClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExpenseClaimApi.Models.ExpenseClaimLine", b =>
                {
                    b.HasOne("ExpenseClaimApi.Models.ClaimItem", "ClaimItem")
                        .WithMany("ExpenseClaimLines")
                        .HasForeignKey("ClaimItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpenseClaimApi.Models.ExpenseClaim", "ExpenseClaim")
                        .WithMany("ExpenseClaimLines")
                        .HasForeignKey("ExpenseClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClaimItem");

                    b.Navigation("ExpenseClaim");
                });

            modelBuilder.Entity("ExpenseClaimApi.Models.ClaimItem", b =>
                {
                    b.Navigation("ExpenseClaimLines");
                });

            modelBuilder.Entity("ExpenseClaimApi.Models.ExpenseClaim", b =>
                {
                    b.Navigation("ExpenseClaimLines");
                });

            modelBuilder.Entity("ExpenseClaimApi.Models.User", b =>
                {
                    b.Navigation("ExpenseClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
