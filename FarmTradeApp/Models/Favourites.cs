using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FarmTradeApp.Models;

[Table("favourites")]
[Keyless]
public class Favourites
{
    public int user_id { get; set; }
    public int product_id { get; set; }
}