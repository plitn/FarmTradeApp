using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmTradeApp.Models;

[Table("products")]
public class Products
{
    [Key]
    public int product_id { get; set; }
    public int user_id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string photo { get; set; }
    public int category { get; set; }
    public int weight { get; set; }
    public int price { get; set; }
    public bool is_active { get; set; }
    public int weight_category { get; set; }
}