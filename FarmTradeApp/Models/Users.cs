using System.ComponentModel.DataAnnotations;

namespace FarmTradeApp.Models;

public class Users
{
    [Key]
    public int user_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string address { get; set; }
    public string profile_picture { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}