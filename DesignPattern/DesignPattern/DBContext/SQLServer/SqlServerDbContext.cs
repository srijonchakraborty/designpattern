using System;
using System.Collections.Generic;
using DesignPattern.DBContext.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.DBContext.SQLServer;

public partial class SqlServerDbContext : DbContext
{
    public SqlServerDbContext()
    {
    }

    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SystemNotification> SystemNotifications { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SystemNotification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__SystemNo__20CF2E1284E96F6A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
