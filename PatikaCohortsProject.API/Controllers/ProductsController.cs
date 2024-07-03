using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.Model;
using System.Collections.Generic;

namespace PatikaCohortsProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private List<Product> _productList;
    public ProductsController()
    {
        _productList = new List<Product>();
        _productList.Add(new Product { Id = 1, Name = "NoteProduct", Description = "Dell Intel i7 Core", Price = 35, Stock = 10 });
        _productList.Add(new Product { Id = 2, Name = "Mouse", Description = "Logitech Bluetooth Mouse", Price = 5, Stock = 20 });
        _productList.Add(new Product { Id = 3, Name = "Keyboard", Description = "Logitech Bluetooth Keyboard", Price = 3, Stock = 30 });
    }
    [HttpGet]
    public IActionResult Get()
    {
        var response = new ApiResponse<List<Product>>(_productList);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var item = _productList?.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            var response = new ApiResponse<Product>("Product not found in system.");
            return NotFound(response);
        }

        var successResponse = new ApiResponse<Product>(item);
        return Ok(successResponse);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest(new ApiResponse<Product>("Invalid product data."));
        }
        _productList.Add(product);
        var createdResponse = new ApiResponse<List<Product>>(_productList);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, createdResponse);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Product product)
    {
        if (product == null)
        {
            var response = new ApiResponse<List<Product>>("Invalid product data.");
            return BadRequest(response);
        }

        var item = _productList.FirstOrDefault(x => x.Id == id);
        if (item is null)
        {
            var response = new ApiResponse<List<Product>>("Item not found in system.");
            return NotFound(response);
        }

        item.Name = product.Name;
        item.Description = product.Description;
        item.Price = product.Price;
        item.Stock = product.Stock;

        var successResponse = new ApiResponse<List<Product>>(_productList);
        return Ok(successResponse);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _productList.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            var response = new ApiResponse<List<Product>>("Product not found in system.");
            return NotFound(response);
        }

        _productList.Remove(item);
        var successResponse = new ApiResponse<List<Product>>(_productList);
        return Ok(successResponse);
    }
}


