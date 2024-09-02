using AutoMapper;
using boutique_zyx_api.DTOs;
using boutique_zyx_api.Entidades;
using boutique_zyx_api.Repositorio.Contratos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace boutique_zyx_api.Repositorio.Implementaciones
{
    public class ProductoRepository:IProductoRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductoRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<EstructuraJsonEntity> ActualizarCantidadProducto(string sku,ProductoCreacionDTO productoCreacionDTO) 
        {
            var productoBD = await context.Productos.FirstOrDefaultAsync(x => x.SKU == sku);
            if (productoBD == null)
            {
                return new EstructuraJsonEntity { code = 400, message = "No se ha encontrado el producto" };
            }
            
            productoBD = mapper.Map(productoCreacionDTO, productoBD);

            await context.SaveChangesAsync();
            return new EstructuraJsonEntity { code = 202, message = "" };
        }
        public async Task<ProductoDTO> ObtenerProductoPorSKU(string sku) 
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x => x.SKU == sku);
            if (producto == null)
            {
                return null;
            }
            return mapper.Map<ProductoDTO>(producto);
        }
        public async Task<List<ProductoDTO>> ObtenerProducto()
        {
            var producto = await context.Productos.AsQueryable().ToListAsync() ;
  
            return mapper.Map<List<ProductoDTO>>(producto);
        }
        public async Task<ProductoDTO> CrearProducto(ProductoCreacionDTO creacionProductoDTO)
        {
            var nombreExiste = await context.Productos.FirstOrDefaultAsync(x => x.Nombre == creacionProductoDTO.Nombre);
            if (nombreExiste != null)
            {
                return null;
            }
            var uniqueId = GenerateUniqueId(6);
            var sku = GenerateSKU(creacionProductoDTO.Nombre, creacionProductoDTO.Tipo, creacionProductoDTO.UnidadMedida, uniqueId);
            
            var producto = mapper.Map<Producto>(creacionProductoDTO);
            producto.SKU = sku;
            context.Add(producto);
            await context.SaveChangesAsync();

            var productoDTO = mapper.Map<ProductoDTO>(producto);
            return productoDTO;
            
        }
        // Método para generar un SKU
        public static string GenerateSKU(string nombre, string tipo, string unidadmedida, string uniqueId)
        {
            return $"{nombre[0]}-{tipo[0]}-{unidadmedida[0]}-{uniqueId}";
        }

        // Método para generar un identificador único sin los dígitos 0 y 1
        public static string GenerateUniqueId(int length)
        {
            Random random = new Random();
            string allowedDigits = "23456789"; // Digitos permitidos (excluyendo 0 y 1)
            StringBuilder uniqueId = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                // Selecciona un dígito aleatorio de los permitidos
                char digit = allowedDigits[random.Next(allowedDigits.Length)];
                uniqueId.Append(digit);
            }

            return uniqueId.ToString();
        }
    }
}
