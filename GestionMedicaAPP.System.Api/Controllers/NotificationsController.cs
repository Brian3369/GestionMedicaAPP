using GestionMedicaAPP.Domain.Entities.System;
using GestionMedicaAPP.Persistance.Interfaces.System;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.System.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsRepository _notificationsRepository;
        public NotificationsController(INotificationsRepository notificationsRepository)
        {
            _notificationsRepository = notificationsRepository;
        }

        [HttpGet("GetNotifications")]
        public async Task<IActionResult> Get()
        {
            var result = await _notificationsRepository.GetAll();
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _notificationsRepository.GetEntityBy(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveNotifications")]
        public async Task<IActionResult> Post([FromBody] Notifications notifications)
        {
            var result = await _notificationsRepository.Save(notifications);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateNotifications")]
        public async Task<IActionResult> Put(int id, [FromBody] Notifications notifications)
        {
            var result = await _notificationsRepository.Update(notifications);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("RemoveNotifications")]
        public async Task<IActionResult> Remove(Notifications notifications)
        {
            var result = await _notificationsRepository.Remove(notifications);
            if (result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
