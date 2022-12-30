using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HotelManagementSystem.WebUI.Models {
      public partial class HotelManagementContext : DbContext {
            public HotelManagementContext()
                : base("name=HotelManagementContext") {
            }

            public virtual DbSet<About> Abouts { get; set; }
            public virtual DbSet<Amenity> Amenities { get; set; }
            public virtual DbSet<AmenityByRoom> AmenityByRooms { get; set; }
            public virtual DbSet<Category> Categories { get; set; }
            public virtual DbSet<Comment> Comments { get; set; }
            public virtual DbSet<ContactMessage> ContactMessages { get; set; }
            public virtual DbSet<Contact> Contacts { get; set; }
            public virtual DbSet<FAQ> FAQs { get; set; }
            public virtual DbSet<Image> Images { get; set; }
            public virtual DbSet<Price> Prices { get; set; }
            public virtual DbSet<Reservation> Reservations { get; set; }
            public virtual DbSet<RoomByCategory> RoomByCategories { get; set; }
            public virtual DbSet<RoomDetail> RoomDetails { get; set; }
            public virtual DbSet<Room> Rooms { get; set; }
            public virtual DbSet<ServiceByRoom> ServiceByRooms { get; set; }
            public virtual DbSet<Service> Services { get; set; }
            public virtual DbSet<User> Users { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                  modelBuilder.Entity<About>()
                      .Property(e => e.Title)
                      .IsUnicode(false);

                  modelBuilder.Entity<About>()
                      .Property(e => e.Description)
                      .IsUnicode(false);

                  modelBuilder.Entity<About>()
                      .Property(e => e.ImageURL)
                      .IsUnicode(false);

                  modelBuilder.Entity<Amenity>()
                      .Property(e => e.Name)
                      .IsUnicode(false);

                  modelBuilder.Entity<Amenity>()
                      .Property(e => e.ImageURL)
                      .IsUnicode(false);

                  modelBuilder.Entity<Amenity>()
                      .HasMany(e => e.AmenityByRooms)
                      .WithRequired(e => e.Amenity)
                      .WillCascadeOnDelete(false);

                  modelBuilder.Entity<Category>()
                      .Property(e => e.Name)
                      .IsUnicode(false);

                  modelBuilder.Entity<Comment>()
                      .Property(e => e.FullName)
                      .IsUnicode(false);

                  modelBuilder.Entity<Comment>()
                      .Property(e => e.Email)
                      .IsUnicode(false);

                  modelBuilder.Entity<Comment>()
                      .Property(e => e.PhoneNumber)
                      .IsFixedLength()
                      .IsUnicode(false);

                  modelBuilder.Entity<Comment>()
                      .Property(e => e.Message)
                      .IsUnicode(false);

                  modelBuilder.Entity<ContactMessage>()
                      .Property(e => e.FullName)
                      .IsUnicode(false);

                  modelBuilder.Entity<ContactMessage>()
                      .Property(e => e.Phone)
                      .IsFixedLength()
                      .IsUnicode(false);

                  modelBuilder.Entity<ContactMessage>()
                      .Property(e => e.Email)
                      .IsUnicode(false);

                  modelBuilder.Entity<ContactMessage>()
                      .Property(e => e.Subject)
                      .IsUnicode(false);

                  modelBuilder.Entity<ContactMessage>()
                      .Property(e => e.Message)
                      .IsUnicode(false);

                  modelBuilder.Entity<Contact>()
                      .Property(e => e.PhoneNumber)
                      .IsFixedLength()
                      .IsUnicode(false);

                  modelBuilder.Entity<Contact>()
                      .Property(e => e.Email)
                      .IsUnicode(false);

                  modelBuilder.Entity<Contact>()
                      .Property(e => e.Address)
                      .IsUnicode(false);

                  modelBuilder.Entity<Contact>()
                      .Property(e => e.ZipCode)
                      .IsFixedLength()
                      .IsUnicode(false);

                  modelBuilder.Entity<Contact>()
                      .Property(e => e.Map)
                      .IsUnicode(false);

                  modelBuilder.Entity<Contact>()
                      .Property(e => e.Title)
                      .IsUnicode(false);

                  modelBuilder.Entity<Contact>()
                      .Property(e => e.Description)
                      .IsUnicode(false);

                  modelBuilder.Entity<Contact>()
                      .Property(e => e.ImageURL)
                      .IsUnicode(false);

                  modelBuilder.Entity<FAQ>()
                      .Property(e => e.Question)
                      .IsUnicode(false);

                  modelBuilder.Entity<FAQ>()
                      .Property(e => e.Answer)
                      .IsUnicode(false);

                  modelBuilder.Entity<Image>()
                      .Property(e => e.ImageURL)
                      .IsUnicode(false);

                  modelBuilder.Entity<Reservation>()
                      .Property(e => e.FullName)
                      .IsUnicode(false);

                  modelBuilder.Entity<Reservation>()
                      .Property(e => e.Email)
                      .IsUnicode(false);

                  modelBuilder.Entity<Reservation>()
                      .Property(e => e.PhoneNumber)
                      .IsFixedLength()
                      .IsUnicode(false);

                  modelBuilder.Entity<Reservation>()
                      .Property(e => e.Address)
                      .IsUnicode(false);

                  modelBuilder.Entity<RoomDetail>()
                      .Property(e => e.Description)
                      .IsUnicode(false);

                  modelBuilder.Entity<RoomDetail>()
                      .Property(e => e.Rules)
                      .IsUnicode(false);

                  modelBuilder.Entity<RoomDetail>()
                      .HasMany(e => e.Reservations)
                      .WithRequired(e => e.RoomDetail)
                      .WillCascadeOnDelete(false);

                  modelBuilder.Entity<Room>()
                      .Property(e => e.ImageURL)
                      .IsUnicode(false);

                  modelBuilder.Entity<Room>()
                      .Property(e => e.Title)
                      .IsUnicode(false);

                  modelBuilder.Entity<Room>()
                      .Property(e => e.Code)
                      .IsUnicode(false);

                  modelBuilder.Entity<Room>()
                      .Property(e => e.BriefDescription)
                      .IsUnicode(false);

                  modelBuilder.Entity<Room>()
                      .Property(e => e.Characteristic)
                      .IsUnicode(false);

                  modelBuilder.Entity<Room>()
                      .HasMany(e => e.AmenityByRooms)
                      .WithRequired(e => e.Room)
                      .WillCascadeOnDelete(false);

                  modelBuilder.Entity<Room>()
                      .HasMany(e => e.Comments)
                      .WithRequired(e => e.Room)
                      .WillCascadeOnDelete(false);

                  modelBuilder.Entity<Room>()
                      .HasOptional(e => e.RoomDetail)
                      .WithRequired(e => e.Room);

                  modelBuilder.Entity<Room>()
                      .HasMany(e => e.ServiceByRooms)
                      .WithRequired(e => e.Room)
                      .WillCascadeOnDelete(false);

                  modelBuilder.Entity<Service>()
                      .Property(e => e.Name)
                      .IsUnicode(false);

                  modelBuilder.Entity<Service>()
                      .Property(e => e.ImageURL)
                      .IsUnicode(false);

                  modelBuilder.Entity<Service>()
                      .HasMany(e => e.ServiceByRooms)
                      .WithRequired(e => e.Service)
                      .WillCascadeOnDelete(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.FullName)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.Email)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.Password)
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.PhoneNumber)
                      .IsFixedLength()
                      .IsUnicode(false);

                  modelBuilder.Entity<User>()
                      .Property(e => e.Address)
                      .IsUnicode(false);
            }
      }
}
