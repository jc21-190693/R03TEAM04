using System;
using System.Collections.Generic;
using System.Text;

//https://docs.microsoft.com/ja-jp/xamarin/xamarin-forms/app-fundamentals/local-notifications

namespace NavPageSample.notification
{
    public interface INotificationManager
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotification(string title, string message, DateTime? notifyTime = null);
        void ReceiveNotification(string title, string message);
    }
}
