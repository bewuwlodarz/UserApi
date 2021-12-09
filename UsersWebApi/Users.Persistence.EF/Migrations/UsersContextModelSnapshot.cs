﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Users.Persistence.EF;

namespace Users.Persistence.EF.Migrations
{
    [DbContext(typeof(UsersContext))]
    partial class UsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Users.Domain.Entities.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "Wroclaw",
                            Country = "Poland",
                            PostCode = "50-008",
                            Street = "Kosciuszki"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "Kielce",
                            Country = "Poland",
                            PostCode = "25-351",
                            Street = "Kosciuszki"
                        });
                });

            modelBuilder.Entity("Users.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("UserAddressId")
                        .HasColumnType("int");

                    b.Property<int>("UserProfileSettingId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserAddressId");

                    b.HasIndex("UserProfileSettingId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "bartek.wlodarz@gmail.com",
                            Name = "Bartek",
                            Surname = "Wlodarz",
                            UserAddressId = 1,
                            UserProfileSettingId = 1
                        },
                        new
                        {
                            UserId = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "dawid.wlodarz@gmail.com",
                            Name = "Dawid",
                            Surname = "Wlodarz",
                            UserAddressId = 2,
                            UserProfileSettingId = 2
                        });
                });

            modelBuilder.Entity("Users.Domain.Entities.UserProfileSetting", b =>
                {
                    b.Property<int>("UserProfileSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FavouriteFrontendFramework")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExtraUser")
                        .HasColumnType("bit");

                    b.HasKey("UserProfileSettingId");

                    b.ToTable("UserProfileSettings");

                    b.HasData(
                        new
                        {
                            UserProfileSettingId = 1,
                            DateOfBirth = new DateTime(1996, 12, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            FavouriteFrontendFramework = "React",
                            IsAdmin = true,
                            IsExtraUser = false
                        },
                        new
                        {
                            UserProfileSettingId = 2,
                            DateOfBirth = new DateTime(2001, 12, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            FavouriteFrontendFramework = "Vue.JS",
                            IsAdmin = false,
                            IsExtraUser = true
                        });
                });

            modelBuilder.Entity("Users.Domain.Entities.User", b =>
                {
                    b.HasOne("Users.Domain.Entities.Address", "UserAddress")
                        .WithMany()
                        .HasForeignKey("UserAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Users.Domain.Entities.UserProfileSetting", "UserProfileSetting")
                        .WithMany()
                        .HasForeignKey("UserProfileSettingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAddress");

                    b.Navigation("UserProfileSetting");
                });
#pragma warning restore 612, 618
        }
    }
}
