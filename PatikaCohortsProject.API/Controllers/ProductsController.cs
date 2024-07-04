using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.Model;
using PatikaCohortsProject.API.Validators;
using System;
using System.Collections.Generic;

namespace PatikaCohortsProject.API.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private List<Product> _productList;
    public ProductsController()
    {
        _productList = new List<Product>();
        _productList.Add(new Product { Id = 1, Name = "NoteProduct", Description = "Dell Intel i7 Core", Price = 35, Stock = 10 });
        _productList.Add(new Product { Id = 2, Name = "Mouse", Description = "Logitech Bluetooth Mouse", Price = 5, Stock = 20 });
        _productList.Add(new Product { Id = 3, Name = "Mouse", Description = "Logitech Bluetooth Mouse", Price = 15, Stock = 20 });
        _productList.Add(new Product { Id = 4, Name = "Mouse", Description = "Logitech Bluetooth Mouse", Price = 25, Stock = 20 });
        _productList.Add(new Product { Id = 5, Name = "Keyboard", Description = "Logitech Bluetooth Keyboard", Price = 3, Stock = 30 });
    }
    [HttpGet]
    public IActionResult Get()
    {
        var response = new ApiResponse<List<Product>>(200, "Success", _productList);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var item = _productList?.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            var response = new ApiResponse<Product>(404, "Product not found in system.");
            return NotFound(response);
        }

        var successResponse = new ApiResponse<Product>(200, "Success", item);
        return Ok(successResponse);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        if (product == null)
        {
            return BadRequest(new ApiResponse<Product>(400, "Invalid product data.", product));
        }
        _productList.Add(product);
        var createdResponse = new ApiResponse<List<Product>>(_productList);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, new ApiResponse<Product>(201, "Product created successfully.", product));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse<Product>(400, "Invalid product data.", product));
        }

        var item = _productList.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            var response = new ApiResponse<Product>(404, "Product not found in system.");
            return NotFound(response);
        }

        item.Name = product.Name;
        item.Description = product.Description;
        item.Price = product.Price;
        item.Stock = product.Stock;

        var successResponse = new ApiResponse<List<Product>>(200, "Product updated successfully.", _productList);
        return Ok(successResponse);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest(new ApiResponse<Product>(400, "Invalid patch document."));
        }

        var product = _productList.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound(new ApiResponse<Product>(404, "Product not found in system."));
        }
        var validator = new ProductPatchValidator();

        patchDoc.ApplyTo(product, ModelState);

        var validationResult = validator.Validate(product);
        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = new ApiResponse<Product>(product);
        return Ok(response);
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _productList.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            var response = new ApiResponse<List<Product>>(404, "Product not found in system.");
            return NotFound(response);
        }

        _productList.Remove(item);
        var successResponse = new ApiResponse<List<Product>>(200, "Product deleted successfully.", _productList);
        return Ok(successResponse);
    }

    //name, price ve stock alanlarına göre artan ve azalan sıralama yapar
    [HttpGet("list")]
    public IActionResult List([FromQuery] string name, [FromQuery] string sortBy = "price", [FromQuery] string order = "asc")
    {
        var products = _productList.AsQueryable();

        if (string.IsNullOrEmpty(name))
        {
            return BadRequest(new ApiResponse<string>(400, "The 'name' parameter cannot be empty."));
        }

        products = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        if (!products.Any())
        {
            return NotFound(new ApiResponse<string>(404, "No products found with the specified name."));
        }

        if (order.ToLower() == "desc")
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "stock":
                    products = products.OrderByDescending(p => p.Stock);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "stock":
                    products = products.OrderBy(p => p.Stock);
                    break;
                default:
                    break;
            }
        }

        var response = new ApiResponse<List<Product>>(200, "Success", products.ToList());
        return Ok(response);
    }
}


