﻿
namespace Qydha.API.Controllers;

[ApiController]
[Route("notifications/")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [Authorization(AuthZUserType.Admin)]
    [HttpPost("send-to-user/")]
    public async Task<IActionResult> SendNotificationToUser([FromBody] NotificationSendToUserDto notification_request)
    {
        return (await _notificationService.SendToUser(new Notification()
        {
            Title = notification_request.Title!,
            Description = notification_request.Description!,
            ActionPath = notification_request.Action_Path!,
            ActionType = notification_request.Action_Type,
            CreatedAt = DateTime.UtcNow,
            UserId = notification_request.UserId
        }))
        .Handle<User, IActionResult>((user) =>
            Ok(new { message = $"Notification sent to the user with username = '{user.Username}'" })
        , BadRequest);

    }


    [Authorization(AuthZUserType.Admin)]
    [HttpPost("send-to-all-users/")]
    public async Task<IActionResult> SendNotificationToAllUsers([FromBody] NotificationSendDto dto)
    {
        return (await _notificationService.SendToAllUsers(new Notification()
        {
            Title = dto.Title!,
            Description = dto.Description!,
            ActionPath = dto.Action_Path!,
            ActionType = dto.Action_Type,
            CreatedAt = DateTime.UtcNow,
        }))
        .Handle<int, IActionResult>((effected) => Ok(new { Message = $"notification sent to : {effected} users " }), BadRequest);

    }

}
