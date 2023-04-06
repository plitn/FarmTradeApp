using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmTradeApp.Models;

[Table("favourites")]
public class Favourites
{
    [Key]
    public int user_id { get; set; }
    public int product_id { get; set; }
}