using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Interfaces.Servicios;
using Servicios;
using static System.Reflection.Metadata.BlobBuilder;

namespace Evaluacion2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComprasController : ControllerBase
    {
        private IServicioCompras _service;

        public ComprasController(IServicioCompras service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>a list of Books</returns>
        [ProducesResponseType(typeof(IList<ComprasDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [HttpGet("[action]/{clienteId}")]
        public async Task<IActionResult> GetByClientId(uint clienteId)
        {
            IActionResult response;
            try
            {
                var result = await _service.GetByClientId(clienteId);
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
