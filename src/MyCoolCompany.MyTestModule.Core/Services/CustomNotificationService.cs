using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCoolCompany.MyTestModule.Core.Type;
using VirtoCommerce.NotificationsModule.Core.Extensions;
using VirtoCommerce.NotificationsModule.Core.Model;
using VirtoCommerce.NotificationsModule.Core.Services;


namespace MyCoolCompany.MyTestModule.Core.Services
{
    public class CustomNotificationService: ICustomNotificationService
    {
        private readonly INotificationSearchService _notificationSearchService;
        private readonly INotificationSender _notificationSender;

        public CustomNotificationService(INotificationSender notificationSender, INotificationSearchService notificationSearchService)
        {
            _notificationSender = notificationSender;
            _notificationSearchService = notificationSearchService;
        }

        public async Task<NotificationSendResult> SendNotification()
        {
            var notification = await _notificationSearchService.GetNotificationAsync<SampleEmailNotification>();
            if (notification != null)
            {
                notification.LanguageCode = "en-US";
                notification.SetFromToMembers("from@test.com", "cgenesoni@yahoo.com.ar");
                return  await _notificationSender.SendNotificationAsync(notification);
            }

            var result = new TaskCompletionSource<NotificationSendResult>();
            result.SetResult
            (
                 new NotificationSendResult
                 {
                     IsSuccess = false,
                     ErrorMessage = "Notification template does not exist"
                 }
            );

            return await result.Task;
        }
    }
}
