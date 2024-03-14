using Microsoft.AspNetCore.Mvc;
using System.Net;
using XYZPlatform.BusinessLogic.Repository.IRepository;
using XYZPlatform.Models.DTO;
using XYZPlatform.Models.Models;

namespace XYZPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly IWorkContainer _workContainer;
        private readonly APIResponseDTO _response;

        public TimeController(IWorkContainer workContainer)
        {
            _workContainer = workContainer;
            _response = new();
        }

        [HttpGet("{idActivity:int}", Name = "GetAllTimesByIdActivity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTimesByIdActivity(int idActivity)
        {
            List<Time> times = await _workContainer.Time.GetTimesByActivity(idActivity);

            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Resultado = times;
            return Ok(_response);

        }


        [HttpPost("AddData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddData(ActivityDTO data)
        {
            bool result = await _workContainer.Time.AddData(data);

            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Resultado = result;
            return Ok(_response);

        }

        [HttpPost("AddTime")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddTime(TimeDTO time)
        {
            string result = await _workContainer.Time.AddTime(time);

            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Resultado = result;
            return Ok(_response);

        }
    }
}
