﻿namespace GestionMedicaAPP.Application.Dtos.System.Notifications
{
    public class NotificationsBaseDto
    {
        public int NotificationID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
