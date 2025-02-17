﻿using Microsoft.EntityFrameworkCore;
using PatikaCohortsProject.API.Model;

namespace PatikaCohortsProject.API.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<BookEntity> Books { get; set; }
}
