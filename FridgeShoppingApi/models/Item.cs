/// <summary>
/// Represents an item
/// </summary>
/// 
namespace FridgeShoppingApi
{
    public class Item
    {
        public string Id { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}