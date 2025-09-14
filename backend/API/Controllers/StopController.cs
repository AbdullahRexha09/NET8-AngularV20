using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StopController : ControllerBase
    {
        private readonly IStopService _service;

        public StopController(IStopService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stop = await _service.GetByIdAsync(id);
            return stop == null ? NotFound() : Ok(stop);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StopRequestDto dto)
        {
            var createdStop = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdStop.Id }, createdStop);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StopRequestDto dto) => Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));
    }
}
