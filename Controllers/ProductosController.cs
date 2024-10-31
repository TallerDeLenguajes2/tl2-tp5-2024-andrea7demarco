using EspacioPrograma;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp5_2024_andrea7demarco.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosContoller: ControllerBase
{
    private readonly ProductosRepository repoProd;
    public ProductosContoller()
    {
        repoProd = new ProductosRepository();
    }
    [HttpPost("POST/api/Producto")]
    public IActionResult crearProducto([FromBody] Producto producto)
    {
        try
        {
            repoProd.CrearProducto(producto);
            return Ok();
        } catch(Exception)
        {
            return StatusCode(500, "No se pudo crear un producto nuevo");
        }
    }

    [HttpGet("GET/api/Producto")]
    public IActionResult obtenerProductos()

}
