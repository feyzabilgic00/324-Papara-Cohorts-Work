using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.Model;
using PatikaCohortsProject.API.Repositories.Product;
using PatikaCohortsProject.API.Services;
using PatikaCohortsProject.API.Validators;
using System;
using System.Collections.Generic;

namespace PatikaCohortsProject.API.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.GetAllAsync();

        if (products == null || !products.Any())
        {
            return NotFound("No products found.");
        }

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _productService.GetByIdAsync(id);
        if (item == null)
        {
            var response = new ApiResponse<ProductEntity>(404, "Product not found in system.");
            return NotFound(response);
        }

        var successResponse = new ApiResponse<ProductEntity>(200, "Success", item);
        return Ok(successResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductEntity product)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        if (product == null)
        {
            return BadRequest(new ApiResponse<ProductEntity>(400, "Invalid product data.", product));
        }
        _productService.CreateAsync(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, new ApiResponse<ProductEntity>(201, "Product created successfully.", product));
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ProductEntity product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse<ProductEntity>(400, "Invalid product data.", product));
        }

        var item = await _productService.GetByIdAsync(id);
        if (item == null)
        {
            var response = new ApiResponse<ProductEntity>(404, "Product not found in system.");
            return NotFound(response);
        }

        item.Name = product.Name;
        item.Description = product.Description;
        item.Price = product.Price;
        item.Stock = product.Stock;

        await _productService.UpdateAsync(item);
        var successResponse = new ApiResponse<List<ProductEntity>>(200, "Product updated successfully.");
        return Ok(successResponse);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ProductEntity> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest(new ApiResponse<ProductEntity>(400, "Invalid patch document."));
        }

        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound(new ApiResponse<ProductEntity>(404, "Product not found in system."));
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

        var response = new ApiResponse<ProductEntity>(product);
        return Ok(response);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = _productService.GetByIdAsync(id).Result.Id;
        if (item == null)
        {
            var response = new ApiResponse<List<ProductEntity>>(404, "Product not found in system.");
            return NotFound(response);
        }

        _productService.DeleteAsync(item);
        var successResponse = new ApiResponse<List<ProductEntity>>(200, "Product deleted successfully.");
        return Ok(successResponse);
    }

    //name, price ve stock alanlarına göre artan ve azalan sıralama yapar
    //[HttpGet("list")]
    //public IActionResult List([FromQuery] string name, [FromQuery] string sortBy = "price", [FromQuery] string order = "asc")
    //{
    //    var products = _productList.AsQueryable();

    //    if (string.IsNullOrEmpty(name))
    //    {
    //        return BadRequest(new ApiResponse<string>(400, "The 'name' parameter cannot be empty."));
    //    }

    //    products = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

    //    if (!products.Any())
    //    {
    //        return NotFound(new ApiResponse<string>(404, "No products found with the specified name."));
    //    }

    //    if (order.ToLower() == "desc")
    //    {
    //        switch (sortBy.ToLower())
    //        {
    //            case "name":
    //                products = products.OrderByDescending(p => p.Name);
    //                break;
    //            case "price":
    //                products = products.OrderByDescending(p => p.Price);
    //                break;
    //            case "stock":
    //                products = products.OrderByDescending(p => p.Stock);
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    else
    //    {
    //        switch (sortBy.ToLower())
    //        {
    //            case "name":
    //                products = products.OrderBy(p => p.Name);
    //                break;
    //            case "price":
    //                products = products.OrderBy(p => p.Price);
    //                break;
    //            case "stock":
    //                products = products.OrderBy(p => p.Stock);
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    var response = new ApiResponse<List<ProductEntity>>(200, "Success", products.ToList());
    //    return Ok(response);
    //}
}


