using System.ComponentModel.DataAnnotations;

namespace FarmTradeApp.Models;

public class Favourites
{
    [Key]
    public int product_id { get; set; }
    public int user_id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}