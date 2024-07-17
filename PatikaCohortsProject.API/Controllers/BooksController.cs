using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.DTOs.Book;
using PatikaCohortsProject.API.Model;
using PatikaCohortsProject.API.Services;

namespace PatikaCohortsProject.API.Controllers;

[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    public BooksController(IBookService bookService, IMapper mapper) 
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = _mapper.Map<List<GetAllBooksDto>>(await _bookService.GetAllAsync());

        if (users == null || !users.Any())
        {
            return NotFound("No books found.");
        }

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        var item = _mapper.Map<GetByIdBookDto>(await _bookService.GetByIdAsync(id));
        if (item == null)
        {
            var response = new ApiResponse<GetByIdBookDto>(404, "Book not found in system.");
            return NotFound(response);
        }

        var successResponse = new ApiResponse<GetByIdBookDto>(200, "Success", item);
        return Ok(successResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBookDto book)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        if (book == null)
        {
            return BadRequest(new ApiResponse<CreateBookDto>(400, "Invalid book data.", book));
        }

        await _bookService.CreateAsync(_mapper.Map<BookEntity>(book));
        return CreatedAtAction(nameof(Get), new ApiResponse<CreateBookDto>(201, "Book created successfully.", book));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateBookDto book)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        var item = await _bookService.GetByIdAsync(id);
        if (item == null)
        {
            var response = new ApiResponse<UpdateBookDto>(404, "Book not found in system.");
            return NotFound(response);
        }

        item.Price = book.Price;
        item.Stock = book.Stock;

        await _bookService.UpdateAsync(item);
        var successResponse = new ApiResponse<List<GetAllBooksDto>>(200, "Book updated successfully.");
        return Ok(successResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        var item = _bookService.GetByIdAsync(id).Result.Id;
        if (item == 0 && item == null)
        {
            var response = new ApiResponse<List<GetAllBooksDto>>(404, "Book not found in system.");
            return NotFound(response);
        }

        await _bookService.DeleteAsync(item);
        var successResponse = new ApiResponse<List<GetAllBooksDto>>(200, "Book deleted successfully.");
        return Ok(successResponse);
    }
}
