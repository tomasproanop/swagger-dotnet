using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;

namespace FridgeShoppingApi
{
public class FridgeMongoService : IFridgeService
    {
        private readonly IMongoCollection<Item> _fridgeCollection;

        public FridgeMongoService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("swagger_project_vsys");
            _fridgeCollection = database.GetCollection<Item>("FoodInFridge");
        }

        
        public List<Item> GetAllItems() => _fridgeCollection.Find(item => true).ToList();

        public Item GetItemById(string id)
        {
            return _fridgeCollection.Find(item => item.Id == id).FirstOrDefault();
        }

        public void AddItem(Item item)
        {
            _fridgeCollection.InsertOne(item);
        }

        public void UpdateItem(string id, Item updatedItem)
        {
            _fridgeCollection.ReplaceOne(item => item.Id == id, updatedItem);
        }

        public void DeleteItem(string id)
        {
            if (ObjectId.TryParse(id, out var objectId))
            {
                // If the ID is a valid ObjectId
                _fridgeCollection.DeleteOne(item => item.Id == objectId.ToString());
            }
            else
            {
                // If the ID is a plain string
                _fridgeCollection.DeleteOne(item => item.Id == id);
            }
        }
    }
}