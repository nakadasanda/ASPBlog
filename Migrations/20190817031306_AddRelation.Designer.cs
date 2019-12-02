﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Myblog1.Data;

namespace Myblog1.Migrations
{
    [DbContext(typeof(Myblog1Context))]
    [Migration("20190817031306_AddRelation")]
    partial class AddRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Myblog1.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("PostDate");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.Property<string>("URL");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Myblog1.Models.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PostId");

                    b.Property<int?>("TermId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TermId");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("Myblog1.Models.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("Myblog1.Models.Relation", b =>
                {
                    b.HasOne("Myblog1.Models.Post", "Post")
                        .WithMany("Relations")
                        .HasForeignKey("PostId");

                    b.HasOne("Myblog1.Models.Term", "Term")
                        .WithMany("Relations")
                        .HasForeignKey("TermId");
                });
#pragma warning restore 612, 618
        }
    }
}
