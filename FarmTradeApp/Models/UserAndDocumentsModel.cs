namespace FarmTradeApp.Models;

public class UserAndDocumentsModel
{
    public Users user { get; set; }
    public IEnumerable<Document> Documents { get; set; }
}