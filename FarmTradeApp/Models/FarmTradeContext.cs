using Microsoft.EntityFrameworkCore;

namespace FarmTradeApp.Models;

public class FarmTradeContext : DbContext
{
    public FarmTradeContext(DbContextOptions<FarmTradeContext> options) : base(options)
    {
        
    }
}