using Microsoft.EntityFrameworkCore;

namespace FarmTradeApp.Models;

public class FarmTradeContext : DbContext
{
    public FarmTradeContext(DbContextOptions<FarmTradeContext> options) : base(options)
    {
        
    }
    
    public DbSet<Users> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Favourites> Favourites { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<WeightType> WeightTypes { get; set; }

}