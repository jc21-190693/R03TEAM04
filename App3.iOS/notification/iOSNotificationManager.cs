using Foundation;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using NavPageSample.notification;
using System;
using UserNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(App3.iOS.notification.iOSNotificationManager))]

namespace App3.iOS.notification
{
    public class iOSNotificationManager : INotificationManager
    {
        private const UNAuthorizationOptions types = UNAuthorizationOptions.Alert | 
            UNAuthorizationOptions.Badge;
        int messageId = 0;
        bool hasNotificationsPermission;
        public event EventHandler NotificationReceived;

        public void Initialize()
        {
            // request the permission to use local notifications
            UNUserNotificationCenter.Current.RequestAuthorization(types, (approved, err) =>
            {
                if (err != null)
                {
                    Analytics.TrackEvent("RequestAuthorization ERROR");
                    //                    (err.LocalizedFailureReason + System.Environment.NewLine + err.LocalizedDescription);
                }
                hasNotificationsPermission = approved;
                Analytics.TrackEvent("hasNotificationsPermission = " + approved);
            });
        }

        public void SendNotification(string title, string message, DateTime? notifyTime = null)
        {
            // EARLY OUT: app doesn't have permissions
            if (!hasNotificationsPermission)
            {
                return;
            }

            messageId++;

            var content = new UNMutableNotificationContent()
            {
                Title = title,
                Subtitle = "",
                Body = message,
                Badge = 1
            };

            UNNotificationTrigger trigger;
            if (notifyTime != null)
            {
                // Create a calendar-based trigger.
                trigger = UNCalendarNotificationTrigger.CreateTrigger(GetNSDateComponents(notifyTime.Value), false);
            }
            else
            {
                // Create a time-based trigger, interval is in seconds and must be greater than 0.
                trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(0.25, false);
            }

            var request = UNNotificationRequest.FromIdentifier(messageId.ToString(), content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            {
                if (err != null)
                {
                    throw new Exception($"Failed to schedule notification: {err}");
                }
            });
        }

        public void ReceiveNotification(string title, string message)
        {
            var args = new NotificationEventArgs()
            {
                Title = title,
                Message = message
            };
            NotificationReceived?.Invoke(null, args);
        }

        NSDateComponents GetNSDateComponents(DateTime dateTime)
        {
            return new NSDateComponents
            {
                Month = dateTime.Month,
                Day = dateTime.Day,
                Year = dateTime.Year,
                Hour = dateTime.Hour,
                Minute = dateTime.Minute,
                Second = dateTime.Second
            };
        }
    }

}