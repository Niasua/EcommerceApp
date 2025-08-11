using EcommerceApi.Models;
using EcommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _service;
    public SalesController(ISaleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetSales(int pageNumber = 1, int pageSize = 10)
    {
        var (sales, totalCount) = await _service.GetSalesPagedAsync(pageNumber, pageSize);
        Response.Headers.Add("X-Total-Count", totalCount.ToString());
        return Ok(sales);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSale(int id)
    {
        var sales = await _service.GetSaleByIdAsync(id);
        if (sales == null)
            return NotFound();
        return Ok(sales);
    }

    [HttpGet("{id}/details")]
    public async Task<IActionResult> GetSaleWithDetails(int id)
    {
        var sale = await _service.GetSaleByIdWithDetailsAsync(id);
        if (sale == null)
            return NotFound();

        return Ok(sale);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale(Sale sales)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.AddSaleAsync(sales);

        return CreatedAtAction(nameof(GetSales), new { id = sales.Id }, sales);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSale(int id, Sale sales)
    {
        if (id != sales.Id)
            return BadRequest("Id mismatch");

        try
        {
            await _service.UpdateSaleAsync(sales);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSale(int id)
    {
        try
        {
            await _service.DeleteSaleAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
