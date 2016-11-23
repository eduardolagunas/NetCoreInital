using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetCoreInital.Entities;

namespace NetCoreInital.Migrations
{
    [DbContext(typeof(NetCoreInitialDbContext))]
    [Migration("20161122145152_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCoreInital.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cuisine");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });
        }
    }
}
