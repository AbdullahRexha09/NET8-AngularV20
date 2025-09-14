using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class JourneyController: ControllerBase
    {
        private readonly IJourneyService _service;
        public JourneyController(IJourneyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(JourneyRequestDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var journey = await _service.GetByIdAsync(id);
            return journey == null ? NotFound() : Ok(journey);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, JourneyRequestDto dto) => Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));
    }
}
