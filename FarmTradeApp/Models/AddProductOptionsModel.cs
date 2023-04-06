namespace FarmTradeApp.Models;

public class AddProductOptionsModel
{
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<WeightType> WeightTypes { get; set; }
} 