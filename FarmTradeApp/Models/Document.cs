using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmTradeApp.Models;

[Table("documents")]
public class Document
{
    [Key]
    public int document_id { get; set; }
    public int user_id { get; set; }
    public string title { get; set; }
    public string file_path { get; set; }

}