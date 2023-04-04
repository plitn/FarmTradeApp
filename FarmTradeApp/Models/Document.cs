using System.ComponentModel.DataAnnotations;

namespace FarmTradeApp.Models;

public class Document
{
    [Key]
    public int document_id { get; set; }
    public int user_id { get; set; }
    public string title { get; set; }
    public string file_path { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    
}