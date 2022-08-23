﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sister;

namespace Sister.Migrations
{
    [DbContext(typeof(DepositoryContext))]
    [Migration("20220819115649_add_ConsumableRecord")]
    partial class add_ConsumableRecord
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sister.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Sister.ConsumableInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ConsumableName")
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<double>("Money")
                        .HasColumnType("float");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("WarningNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ConsumableInfos");
                });

            modelBuilder.Entity("Sister.ConsumableRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ConsumableId")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ConsumableRecords");
                });

            modelBuilder.Entity("Sister.DepartmentInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LeaderId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("DepartmentInfos");
                });

            modelBuilder.Entity("Sister.FileInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Length")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewFileName")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("OldFileName")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("RelationId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("FileInfos");
                });

            modelBuilder.Entity("Sister.MenuInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Href")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("Target")
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("MenuInfos");
                });

            modelBuilder.Entity("Sister.R_RoleInfo_MenuInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MenuId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("R_RoleInfo_MenuInfos");
                });

            modelBuilder.Entity("Sister.R_UserInfo_RoleInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("R_UserInfo_RoleInfos");
                });

            modelBuilder.Entity("Sister.RoleInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("RoleInfos");
                });

            modelBuilder.Entity("Sister.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Account")
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("varchar(16)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("UserInfos");
                });
#pragma warning restore 612, 618
        }
    }
}