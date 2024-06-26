﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transactions.Persistance;

#nullable disable

namespace Transactions.Persistance.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240403151949_SecondUpdateTransactions")]
    partial class SecondUpdateTransactions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Transactions.Core.Entities.CardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthenticityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PaymentNetwrok")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Validity")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Transactions.Core.Entities.CurrencyAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("CurrencyAccounts");
                });

            modelBuilder.Entity("Transactions.Core.Entities.TransactionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConsumerCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyConsumer")
                        .HasColumnType("int");

                    b.Property<int>("CurrencySender")
                        .HasColumnType("int");

                    b.Property<decimal>("ReceiveAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SendAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SenderCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeOfCreate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerCardId");

                    b.HasIndex("SenderCardId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Transactions.Core.Entities.CurrencyAccount", b =>
                {
                    b.HasOne("Transactions.Core.Entities.CardEntity", "Card")
                        .WithMany("CurrencyAccounts")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Transactions.Core.Entities.TransactionEntity", b =>
                {
                    b.HasOne("Transactions.Core.Entities.CardEntity", "ConsumerCard")
                        .WithMany("ReceivedTransactions")
                        .HasForeignKey("ConsumerCardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Transactions.Core.Entities.CardEntity", "SenderCard")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SenderCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumerCard");

                    b.Navigation("SenderCard");
                });

            modelBuilder.Entity("Transactions.Core.Entities.CardEntity", b =>
                {
                    b.Navigation("CurrencyAccounts");

                    b.Navigation("ReceivedTransactions");

                    b.Navigation("SentTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
