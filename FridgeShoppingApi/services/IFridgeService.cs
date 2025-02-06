using System.Collections.Generic;

namespace FridgeShoppingApi
{
public interface IFridgeService
    {
        List<Item> GetAllItems();
        Item GetItemById(string id);        
        void AddItem(Item item);
        void UpdateItem(string id, Item updatedItem);
        void DeleteItem(string id);
    }
}