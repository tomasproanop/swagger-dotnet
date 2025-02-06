
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FridgeShoppingApi
{
   [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get() => _shoppingListService.GetAllItems();

        [HttpGet("{id}")]
        public ActionResult<Item> GetById(string id)
        {
            var item = _shoppingListService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            _shoppingListService.AddItem(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Item updatedItem)
        {
            _shoppingListService.UpdateItem(id, updatedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _shoppingListService.DeleteItem(id);
            return NoContent();
        }
    }
}