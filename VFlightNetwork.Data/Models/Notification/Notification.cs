using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Enums.Notification;

namespace VFlightNetwork.Data.Models.Notification
{
    public class AlertNotification
    {
        public string Text { get; set; }
        public string Type { get; set; }

        public AlertNotification()
        {

        }

        public AlertNotification(NotificationType type, string textToShow)
        {
            Text = textToShow;
            Type = GetNotificationClass(type);
        }

        public void SetNotification(NotificationType type, string textToShow)
        {
            Text = textToShow;
            Type = GetNotificationClass(type);
        }

        private string GetNotificationClass(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Error:
                    return "notification-fail";
                case NotificationType.Success:
                    return "notification-success";
                case NotificationType.Warning:
                    return "notification-warning";
                case NotificationType.Info:
                    return "notification-info";
                case NotificationType.Default:
                    return "";
                default:
                    return "";
            }
        }
    }
}
