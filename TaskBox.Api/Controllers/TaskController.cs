using Microsoft.AspNetCore.Mvc;
using TaskBox.Api.Controllers.Base;
using TaskBox.Application.DTOs;
using TaskBox.Application.Interfaces;

namespace TaskBox.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : BaseController
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskAppService _taskAppService;

        public TaskController(ILogger<TaskController> logger, ITaskAppService taskAppService)
        {
            _logger = logger;
            _taskAppService = taskAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetAll()
        {
            try
            {
                var result = await _taskAppService.GetAllAsync();
                return ResponseGet(result);
            }
            catch (Exception ex)
            {
                return ResponseBadRequest();
            }
        }

        [HttpGet]
        [Route("list-task")]
        public async Task<ActionResult<List<ListTaskDto>>> GetAllListTask()
        {
            try
            {
                var result = await _taskAppService.GetAllListTaskAsync();
                return ResponseGet(result);
            }
            catch (Exception ex)
            {
                return ResponseBadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TaskDto>> GetById(Guid id)
        {
            try
            {
                var result = await _taskAppService.GetByIdAsync(id);
                return ResponseGet(result);
            }
            catch (Exception ex)
            {
                return ResponseBadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Remove([FromRoute] Guid id)
        {
            try
            {
                var result = await _taskAppService.RemoveAsync(id);
                return ResponseGet(true);
            }
            catch (Exception ex)
            {
                return ResponseBadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> Post([FromBody] RegisterTaskDto taskDto)
        {
            try
            {
                var result = await _taskAppService.CreateAsync(taskDto);

                return ResponsePost(result);
            }
            catch (Exception ex)
            {
                return ResponseBadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<RegisterTaskDto>> Put([FromRoute] Guid id, [FromBody] RegisterTaskDto registeredTask)
        {
            try
            {
                await _taskAppService.UpdateAsync(registeredTask, id);
                return ResponsePutPatch();
            }
            catch (Exception ex)
            {
                return ResponseBadRequest();
            }
        }
    }
}
