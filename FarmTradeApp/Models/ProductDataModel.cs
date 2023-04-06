namespace FarmTradeApp.Models;

public class ProductDataModel
{
    public Products Product { get; set; }
    public Users Seller { get; set; }
    public WeightType WeightType { get; set; }
    
    public bool IsFavourited { get; set; }

    public ProductDataModel(Products p, Users s)
    {
        Product = p;
        Seller = s;
    }
}