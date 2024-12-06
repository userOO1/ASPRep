using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPParser.Core.DB_connection;

public class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrderTest> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderTest>(entity =>
        {
            entity.HasKey(e => e.ItemsNumber).HasName("Orders_pkey");
        });
    }
    // Асинхронный метод для получения всех заказов
    public async Task<List<OrderTest>> GetOrdersAsync()
    {
        return await Orders.ToListAsync();
    }

    // Асинхронный метод для добавления нового заказа
    public async Task<int> AddOrderAsync()
    {
        
        return await SaveChangesAsync();
    }


}
