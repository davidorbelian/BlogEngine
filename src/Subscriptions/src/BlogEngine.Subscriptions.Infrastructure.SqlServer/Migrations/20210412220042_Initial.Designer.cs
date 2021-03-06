﻿// <auto-generated />
using System;
using BlogEngine.Subscriptions.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogEngine.Subscriptions.Infrastructure.SqlServer.Migrations
{
    [DbContext(typeof(SubscriptionsContext))]
    [Migration("20210412220042_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogEngine.Subscriptions.Domain.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("UpdateTime");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("BlogEngine.Subscriptions.Domain.Entities.Subscription", b =>
                {
                    b.OwnsMany("BlogEngine.Domain.Common.ValueObjects.HashTag", "HashTags", b1 =>
                        {
                            b1.Property<Guid>("SubscriptionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Id")
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("SubscriptionId", "Id");

                            b1.ToTable("HashTag");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionId");
                        });

                    b.Navigation("HashTags");
                });
#pragma warning restore 612, 618
        }
    }
}
