using System.ComponentModel.DataAnnotations;

namespace FarmTradeApp.Models;

public class Products
{
    [Key]
    public int user_id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string category { get; set; }
    public int weight { get; set; }
    public int price { get; set; }
    public bool is_active { get; set; }
    public string weight_category { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}