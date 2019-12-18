using System;
using System.ComponentModel.DataAnnotations;


namespace StoreApi.Models

{
  public class Item
  {
    public int Id { get; set; }
    public int Sku { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberInStock { get; set; }
    public double Price { get; set; }
    public DateTime DateOrdered { get; set; } = DateTime.Now;

  }
}