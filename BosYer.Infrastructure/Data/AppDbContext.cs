using BosYer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BosYer.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

        public DbSet<ParkingOwner> ParkingOwners { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<ParkingRecord> ParkingRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Bu kısımda Fluent API ile model konfigrasyonu yapabiliriz.

            modelBuilder.Entity<ParkingOwner>().ToTable("parking_owners");
            modelBuilder.Entity<ParkingLot>().ToTable("parking_lots");
            modelBuilder.Entity<Floor>().ToTable("floors");
            modelBuilder.Entity<ParkingRecord>().ToTable("parking_records");

            //İlişkileri burda belirtebiliriz

            modelBuilder.Entity<ParkingLot>()
                .HasOne(p => p.ParkingOwner)
                .WithMany(po => po.ParkingLots)
                .HasForeignKey(p => p.ParkingOwnerId);

            modelBuilder.Entity<Floor>()
                .HasOne(f => f.ParkingLot)
                .WithMany(p => p.Floors)
                .HasForeignKey(f => f.ParkingLotId);

            modelBuilder.Entity<ParkingRecord>()
                .HasOne(pr => pr.Floor)
                .WithMany(f => f.ParkingRecords)
                .HasForeignKey(pr => pr.FloorId);
        }
    }
}
