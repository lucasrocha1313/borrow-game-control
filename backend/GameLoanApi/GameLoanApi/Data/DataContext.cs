﻿using GameLoanApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLoanApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<FriendUser> FriendUser { get; set; }
        public DbSet<GameUser> Game { get; set; }
        public DbSet<GameLoan> GameLoan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(u => u.FriendsUser)
                .WithOne(f => f.User);

            modelBuilder.Entity<FriendUser>()
                .HasOne(f => f.User)
                .WithMany(u => u.FriendsUser)
                .HasForeignKey(f => f.IdUser);

            modelBuilder.Entity<GameUser>()
                .HasOne(g => g.UserOwner)
                .WithMany(u => u.Games);

            modelBuilder.Entity<GameLoan>()
                .HasMany(gl => gl.GamesLoan)
                .WithOne(g => g.Loaned);

            modelBuilder.Entity<GameLoan>()
                .HasOne(gl => gl.FriendWithGame)
                .WithMany(f => f.GamesBorrowed);
        }
    }
}
