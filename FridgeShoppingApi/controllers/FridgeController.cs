using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FridgeShoppingApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeService _fridgeService;

        public FridgeController(IFridgeService fridgeService)
        {
            _fridgeService = fridgeService;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get() => _fridgeService.GetAllItems();

        [HttpGet("{id}")]
        public ActionResult<Item> GetById(string id)
        {
            var item = _fridgeService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            _fridgeService.AddItem(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Item updatedItem)
        {
            _fridgeService.UpdateItem(id, updatedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _fridgeService.DeleteItem(id);
            return NoContent();
        }
    }
}