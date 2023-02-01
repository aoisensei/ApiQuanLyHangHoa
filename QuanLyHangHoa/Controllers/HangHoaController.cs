using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyHangHoa.Models;
using QuanLyHangHoa.Services.HangHoaService;

namespace QuanLyHangHoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {


        public IHangHoaService _hangHoaService;

        public HangHoaController(IHangHoaService hangHoaService)
        {
            _hangHoaService = hangHoaService;
        }

        [HttpGet]
        public async Task<ActionResult<HangHoaModel>> GetAllHangHoa(string? name = null, int? page = null)
        {
            var result = await _hangHoaService.GetAllHangHoa(name, page);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<HangHoaModel>> AddHangHoa(HangHoaModel hh)
        {
            var result = await _hangHoaService.AddHangHoa(hh);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HangHoaModel>?> UpdateHangHoa(HangHoaModel request, int id)
        {
            var result = await _hangHoaService.UpdateHangHoa(request, id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HangHoaModel>?> DeleteHangHoa(int id)
        {
            var result = await _hangHoaService.DeleteHangHoa(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HangHoaModel>?> GetSingleHangHoa(int id)
        {
            var result = await _hangHoaService.GetSingleHangHoa(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
