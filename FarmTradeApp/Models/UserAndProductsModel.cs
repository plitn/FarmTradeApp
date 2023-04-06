using FarmTradeApp.Models;

namespace FarmTradeApp.Controllers;

public class UserAndProductsModel
{
    public IEnumerable<Products> Products { get; set; }
    public Users user { get; set; }
}