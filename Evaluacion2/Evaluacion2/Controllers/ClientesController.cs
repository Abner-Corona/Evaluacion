using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Interfaces.Servicios;
using Servicios;
using static System.Reflection.Metadata.BlobBuilder;

namespace Evaluacion2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController  : ControllerBase
    {
        private IServicioClientes _service;

        public ClientesController(IServicioClientes service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>a list of Books</returns>
        [ProducesResponseType(typeof(IList<ClientesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            IActionResult response;
            try
            {
                var result = await _service.GetAllAsync();
                response = Ok(result);
            }
            catch (Exception ex)
            {
                response = Conflict(ex);
            }
            return response;
        }
    }
}
