using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService _notificationsRepository;
        public NotificationsController(INotificationsService notificationsRepository)
        {
            _notificationsRepository = notificationsRepository;
        }

        [HttpGet("GetNotifications")]
        public async Task<IActionResult> Get()
        {
            var result = await _notificationsRepository.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _notificationsRepository.GetById(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveNotifications")]
        public async Task<IActionResult> Post([FromBody] NotificationsSaveDto notifications)
        {
            var result = await _notificationsRepository.SaveAsync(notifications);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateNotifications")]
        public async Task<IActionResult> Put([FromBody] NotificationsUpdateDto notification)
        {
            var result = await _notificationsRepository.UpdateAsync(notification);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("RemoveNotifications")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _notificationsRepository.RemoveById(id);
            if (result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
