using FinApp.Application.IServices;
using FinApp.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationServices _operationServices;

        public OperationController(IOperationServices operationServices)
        {
            _operationServices = operationServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetOperationAsync()
        {
            try
            {
                var Operations = await _operationServices.GetOperationsAsync();
                if (Operations == null) return NoContent();

                return Ok(Operations);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Operation Error: {ex.Message}");
            }
        }

        [HttpGet("OperationsBydescription/{description}")]
        public async Task<IActionResult> GetOperationsByDescriptionAsync(string description)
        {
            try
            {
                var operation = await _operationServices.GetOperationsByDescriptionAsync(description);
                if (operation == null) return NoContent();

                return Ok(operation);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Operation Error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperationsByIdAsync(int id)
        {
            try
            {
                var operation = await _operationServices.GetOperationsByIdAsync(id);
                if (operation == null) return NoContent();

                return Ok(operation);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Operation Error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(OperationModel model)
        {
            try
            {
                var operation = await _operationServices.AddOperation(model);
                if (operation == null) return NoContent();

                return Ok(operation);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Operation Error: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OperationModel model)
        {
            try
            {
                var operation = await _operationServices.UpdateOperation(id, model);
                if (operation == null) return NoContent();

                return Ok(operation);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Operation Error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var operation = await _operationServices.GetOperationsByIdAsync(id);
                if (operation == null) return NoContent();

                if (await _operationServices.DeleteOperation(id))
                {
                   
                    return Ok(new { message = "the operation has been deleted" });
                }
                else
                {
                    throw new Exception("error deleting operation, contact administrator");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Operation Error: {ex.Message}");
            }
        }
    }
}
