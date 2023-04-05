using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FarmTradeApp.Models;

[Table("users")]
public class Users
{
    [Key]
    public int user_id { get; set; }
    public string first_name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string address { get; set; }
    public string profile_picture { get; set; }
   }