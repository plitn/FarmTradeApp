using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmTradeApp.Models;

[Table("weight_types")]
public class WeightType
{
    [Key]
    [Column("type_id")]
    public int Type_id { get; set; }
    [Column("type_name")]
    public string Type_name { get; set; }
}