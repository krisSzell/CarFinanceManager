using CarFinanceManager.Persistence.Models.Accounts;

namespace CarFinanceManager.Persistence.Models.Core.Notifications
{
    public class UserNotification
    {
        public int UserNotificationId { get; set; }
        public Notification Notification { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsRead { get; set; }
    }
}