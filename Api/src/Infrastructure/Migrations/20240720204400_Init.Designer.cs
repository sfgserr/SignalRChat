﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240720204400_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Groups.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDate");

                    b.Property<string>("IconUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("Domain.Groups.GroupUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("JoinedDate");

                    b.Property<string>("RoleValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RoleValue");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Groups.GroupUserPermission", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Code");

                    b.ToTable("GroupUserPermissions", (string)null);

                    b.HasData(
                        new
                        {
                            Code = "CreateMessage"
                        },
                        new
                        {
                            Code = "ReadMessage"
                        },
                        new
                        {
                            Code = "EditMessage"
                        },
                        new
                        {
                            Code = "AddUser"
                        },
                        new
                        {
                            Code = "RemoveUser"
                        },
                        new
                        {
                            Code = "ChangeName"
                        },
                        new
                        {
                            Code = "GetGroup"
                        },
                        new
                        {
                            Code = "GetUserGroups"
                        },
                        new
                        {
                            Code = "ChangeIconUri"
                        },
                        new
                        {
                            Code = "GetMessages"
                        },
                        new
                        {
                            Code = "AcceptProposal"
                        },
                        new
                        {
                            Code = "Propose"
                        },
                        new
                        {
                            Code = "PlaceMark"
                        },
                        new
                        {
                            Code = "GetSession"
                        },
                        new
                        {
                            Code = "GetProposals"
                        });
                });

            modelBuilder.Entity("Domain.Groups.GroupUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("GroupUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Value = "Member"
                        });
                });

            modelBuilder.Entity("Domain.Groups.GroupUserRolePermission", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GroupUserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Code", "GroupUserRoleId");

                    b.HasIndex("GroupUserRoleId");

                    b.ToTable("GroupUserRolePermissions", (string)null);

                    b.HasData(
                        new
                        {
                            Code = "AddUser",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "RemoveUser",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "ChangeName",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "CreateMessage",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "EditMessage",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "ReadMessage",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "GetGroup",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "GetUserGroups",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "ChangeIconUri",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "GetMessages",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "AcceptProposal",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "Propose",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "PlaceMark",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "GetSession",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "GetProposals",
                            GroupUserRoleId = 1
                        },
                        new
                        {
                            Code = "AcceptProposal",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "Propose",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "PlaceMark",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "GetSession",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "GetProposals",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "CreateMessage",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "EditMessage",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "ReadMessage",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "GetMessages",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "GetGroup",
                            GroupUserRoleId = 2
                        },
                        new
                        {
                            Code = "GetUserGroups",
                            GroupUserRoleId = 2
                        });
                });

            modelBuilder.Entity("Domain.Messages.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationTime");

                    b.Property<bool>("IsEditted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SenderId");

                    b.Property<Guid>("ToGroupId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ToGroupId");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.SessionProposals.SessionProposal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AcceptedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProposedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ProposedDate");

                    b.Property<Guid>("ProposedUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProposedUserId");

                    b.Property<Guid>("ProposingUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProposingUserId");

                    b.HasKey("Id");

                    b.ToTable("SessionProposals", (string)null);
                });

            modelBuilder.Entity("Domain.Sessions.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CrossUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CrossUserId");

                    b.Property<bool>("IsCrossTurn")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnded")
                        .HasColumnType("bit");

                    b.Property<int>("LastPlacedMarkIndex")
                        .HasColumnType("int");

                    b.Property<string>("Marks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Marks");

                    b.Property<Guid>("NoughtUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NoughtUserId");

                    b.Property<Guid?>("WinnerUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Sessions", (string)null);
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IconUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("InternalCommands", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Message");

                    b.Property<DateTime>("OccuredOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("OccuredOn");

                    b.Property<DateTime?>("Proccessed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", (string)null);
                });

            modelBuilder.Entity("Domain.Groups.GroupUser", b =>
                {
                    b.HasOne("Domain.Groups.Group", null)
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Groups.GroupUserRolePermission", b =>
                {
                    b.HasOne("Domain.Groups.GroupUserPermission", null)
                        .WithMany()
                        .HasForeignKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Groups.GroupUserRole", null)
                        .WithMany()
                        .HasForeignKey("GroupUserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Groups.Group", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}