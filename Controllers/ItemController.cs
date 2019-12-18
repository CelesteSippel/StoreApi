
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;

namespace StoreApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class ItemController : ControllerBase
  {
    [HttpPost]
    public ActionResult CreateItem(Item item)
    {
      var db = new DatabaseContext();
      db.Items.Add(item);
      db.SaveChanges();
      return Ok(item);
    }

    [HttpGet]
    public ActionResult GetAllItems()
    {
      var db = new DatabaseContext();
      return Ok(db.Items.OrderByDescending(item => item.DateOrdered));

    }

    [HttpGet("{id}")]
    public ActionResult GetOneItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(it => it.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(item);
      }
    }

    [HttpGet("{sku}")]
    public ActionResult GetBySku(int sku)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(item => item.Sku == sku);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(sku);
      }
    }

    [HttpGet("items/out")]
    public ActionResult OutOfStockItem(int NumberInStock)
    {
      var db = new DatabaseContext();
      var item = db.Items.Where(item => item.NumberInStock == 0).OrderByDescending(item => item.DateOrdered);
      return Ok(item);
    }





    [HttpPut("{id}")]
    public ActionResult UpdateItem(int id, Item item)
    {
      var db = new DatabaseContext();
      var itemToUpdate = db.Items.FirstOrDefault(item => item.Id == id);
      if (itemToUpdate == null)
      {
        return NotFound();
      }
      else
      {
        itemToUpdate.Sku = item.Sku;
        itemToUpdate.Name = item.Name;
        itemToUpdate.Description = item.Description;
        itemToUpdate.NumberInStock = item.NumberInStock;
        itemToUpdate.Price = item.Price;
        itemToUpdate.DateOrdered = item.DateOrdered;
        db.SaveChanges();
        return Ok(itemToUpdate);
      }

    }

    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {
      var db = new DatabaseContext();
      var item = db.Items.FirstOrDefault(item => item.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      else
      {
        db.Items.Remove(item);
        db.SaveChanges();
        return Ok();
      }
    }
  }
}






