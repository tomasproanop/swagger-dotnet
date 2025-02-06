using MongoDB.Driver;
using MongoDB.Bson;

namespace FridgeShoppingApi
{
public class ShoppingListMongoService : IShoppingListService
    {
        private readonly IMongoCollection<Item> _shoppingListCollection;

        public ShoppingListMongoService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("swagger_project_vsys");
            _shoppingListCollection = database.GetCollection<Item>("FoodToBuy");
        }

        public List<Item> GetAllItems() => _shoppingListCollection.Find(item => true).ToList();

        public Item GetItemById(string id)
        {
            return _shoppingListCollection.Find(item => item.Id == id).FirstOrDefault();
        }
        public void AddItem(Item item)
        {
            _shoppingListCollection.InsertOne(item);
        }

        public void UpdateItem(string id, Item updatedItem)
        {
            _shoppingListCollection.ReplaceOne(item => item.Id == id, updatedItem);
        }

        /// <summary>
        /// DeleteItem
        /// Here we had some problems:
        /// ObjectId.TryParse: Checks if the provided id is a valid ObjectId.
        /// If valid, the method converts it into an ObjectId and uses it for the deletion.
        /// Fallback to string:
        /// If the id is not a valid ObjectId, the method treats it as a string and attempts
        /// to delete the item based on that.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteItem(string id)
        {
            if (ObjectId.TryParse(id, out var objectId))
            {
                // If the ID is a valid ObjectId 
                _shoppingListCollection.DeleteOne(item => item.Id == objectId.ToString());
            }
            else
            {
                // If the ID is a plain string
                _shoppingListCollection.DeleteOne(item => item.Id == id);
            }
        }
    }
}