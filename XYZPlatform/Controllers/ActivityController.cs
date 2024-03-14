using Microsoft.AspNetCore.Mvc;
using System.Net;
using XYZPlatform.BusinessLogic.Repository.IRepository;
using XYZPlatform.Models.DTO;
using XYZPlatform.Models.Models;

namespace XYZPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IWorkContainer _workContainer;
        private readonly APIResponseDTO _response;

        public ActivityController(IWorkContainer workContainer)
        {
            _workContainer = workContainer;
            _response = new();
        }

        [HttpGet("GetAllActivities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllActivities()
        {
            List<Activity> activities = await _workContainer.Activity.GetAllActivities();

            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Resultado = activities;
            return Ok(_response);

        }


        [HttpPost("AddActivity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddActivity(ActivityDTO activity)
        {
            bool result = await _workContainer.Activity.AddActivity(activity);

            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Resultado = result;
            return Ok(_response);
        }


        [HttpPost("AddActivityFromRepo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddActivityFromRepo(ActivityDTO activity)
        {
            int result = await _workContainer.Activity.AddActivityFromRepository(activity);
            await _workContainer.SaveAsync();

            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Resultado = result;
            return Ok(_response);
        }
    }
}
