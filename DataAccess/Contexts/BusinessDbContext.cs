using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts;

public class BusinessDbContext:DbContext
{
	public BusinessDbContext()
	{
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //todo: Add Configuration transfer with projects
        //var connectionString = Configuration.GetValue<string>("ConnectionStrings:Production");
        optionsBuilder.UseSqlServer("Server=localhost;Database=BusinessSimple;User Id=SA;TrustServerCertificate=true;Password=reallyStrongPwd123;");
    }
    public DbSet<User> Users { get; set; }
}

