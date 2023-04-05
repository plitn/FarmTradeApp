using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmTradeApp.Models;

[Table("categories")]
public class Category
{
    [Key]
    [Column("category_id")]
    public int Category_id { get; set; }
    [Column("category_name")]
    public string Category_name { get; set; }
}