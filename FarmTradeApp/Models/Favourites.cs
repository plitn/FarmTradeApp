using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FarmTradeApp.Models;

[Table("favourites")]
public class Favourites
{
    [Key]
    public int fav_id { get; set; }
    public int user_id { get; set; }
    public int product_id { get; set; }
}