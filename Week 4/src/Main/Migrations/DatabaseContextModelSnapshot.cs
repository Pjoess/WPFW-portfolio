﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Main.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Main.Attractie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Attracties");
                });

            modelBuilder.Entity("Main.GastInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ForeignKey")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LaaststBezochteURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("ForeignKey")
                        .IsUnique();

                    b.ToTable("GastInfo");
                });

            modelBuilder.Entity("Main.Gebruiker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Gebruiker", (string)null);
                });

            modelBuilder.Entity("Main.Onderhoud", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attractieid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Probleem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Attractieid");

                    b.ToTable("Onderhoud");
                });

            modelBuilder.Entity("Main.Reservering", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attractieid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("gastid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Attractieid");

                    b.HasIndex("gastid");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("MedewerkerOnderhoud", b =>
                {
                    b.Property<int>("doetOnderhoudid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("onderhoudGedaanid")
                        .HasColumnType("INTEGER");

                    b.HasKey("doetOnderhoudid", "onderhoudGedaanid");

                    b.HasIndex("onderhoudGedaanid");

                    b.ToTable("MedewerkerOnderhoud");
                });

            modelBuilder.Entity("MedewerkerOnderhoud1", b =>
                {
                    b.Property<int>("coordinatieGedaanid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("doetCoordinatieid")
                        .HasColumnType("INTEGER");

                    b.HasKey("coordinatieGedaanid", "doetCoordinatieid");

                    b.HasIndex("doetCoordinatieid");

                    b.ToTable("MedewerkerOnderhoud1");
                });

            modelBuilder.Entity("Main.Gast", b =>
                {
                    b.HasBaseType("Main.Gebruiker");

                    b.Property<int?>("Begeleidtid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EersteBezoek")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Favorietid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GastInfoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("TEXT");

                    b.HasIndex("Begeleidtid");

                    b.HasIndex("Favorietid");

                    b.ToTable("Gast", (string)null);
                });

            modelBuilder.Entity("Main.Medewerker", b =>
                {
                    b.HasBaseType("Main.Gebruiker");

                    b.ToTable("Medewerker", (string)null);
                });

            modelBuilder.Entity("Main.GastInfo", b =>
                {
                    b.HasOne("Main.Gast", "Gast")
                        .WithOne("GastInfo")
                        .HasForeignKey("Main.GastInfo", "ForeignKey");

                    b.OwnsOne("Main.Coordinate", "coordinaat", b1 =>
                        {
                            b1.Property<int>("GastInfoid")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("X")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Y")
                                .HasColumnType("INTEGER");

                            b1.HasKey("GastInfoid");

                            b1.ToTable("GastInfo");

                            b1.WithOwner()
                                .HasForeignKey("GastInfoid");
                        });

                    b.Navigation("Gast");

                    b.Navigation("coordinaat")
                        .IsRequired();
                });

            modelBuilder.Entity("Main.Onderhoud", b =>
                {
                    b.HasOne("Main.Attractie", "Attractie")
                        .WithMany("Onderhouds")
                        .HasForeignKey("Attractieid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Main.DateTimeBereik", "DateTimeBereik", b1 =>
                        {
                            b1.Property<int>("Onderhoudid")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Eind")
                                .HasColumnType("TEXT");

                            b1.HasKey("Onderhoudid");

                            b1.ToTable("Onderhoud");

                            b1.WithOwner()
                                .HasForeignKey("Onderhoudid");
                        });

                    b.Navigation("Attractie");

                    b.Navigation("DateTimeBereik")
                        .IsRequired();
                });

            modelBuilder.Entity("Main.Reservering", b =>
                {
                    b.HasOne("Main.Attractie", "Attractie")
                        .WithMany("Reserveringen")
                        .HasForeignKey("Attractieid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Main.Gast", "gast")
                        .WithMany("Reserveringen")
                        .HasForeignKey("gastid");

                    b.OwnsOne("Main.DateTimeBereik", "DateTimeBereik", b1 =>
                        {
                            b1.Property<int>("Reserveringid")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Eind")
                                .HasColumnType("TEXT");

                            b1.HasKey("Reserveringid");

                            b1.ToTable("Reserveringen");

                            b1.WithOwner()
                                .HasForeignKey("Reserveringid");
                        });

                    b.Navigation("Attractie");

                    b.Navigation("DateTimeBereik")
                        .IsRequired();

                    b.Navigation("gast");
                });

            modelBuilder.Entity("MedewerkerOnderhoud", b =>
                {
                    b.HasOne("Main.Onderhoud", null)
                        .WithMany()
                        .HasForeignKey("doetOnderhoudid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Main.Medewerker", null)
                        .WithMany()
                        .HasForeignKey("onderhoudGedaanid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedewerkerOnderhoud1", b =>
                {
                    b.HasOne("Main.Medewerker", null)
                        .WithMany()
                        .HasForeignKey("coordinatieGedaanid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Main.Onderhoud", null)
                        .WithMany()
                        .HasForeignKey("doetCoordinatieid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Main.Gast", b =>
                {
                    b.HasOne("Main.Gast", "Begeleidt")
                        .WithMany()
                        .HasForeignKey("Begeleidtid");

                    b.HasOne("Main.Attractie", "Favoriet")
                        .WithMany("FavorieteGasten")
                        .HasForeignKey("Favorietid");

                    b.HasOne("Main.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("Main.Gast", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Begeleidt");

                    b.Navigation("Favoriet");
                });

            modelBuilder.Entity("Main.Medewerker", b =>
                {
                    b.HasOne("Main.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("Main.Medewerker", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Main.Attractie", b =>
                {
                    b.Navigation("FavorieteGasten");

                    b.Navigation("Onderhouds");

                    b.Navigation("Reserveringen");
                });

            modelBuilder.Entity("Main.Gast", b =>
                {
                    b.Navigation("GastInfo")
                        .IsRequired();

                    b.Navigation("Reserveringen");
                });
#pragma warning restore 612, 618
        }
    }
}
