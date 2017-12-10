using System;

namespace CarFinanceManager.Persistence.Models.Core.Notifications
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public NotificationType Type { get; set; }
        public DateTime DueDate { get; set; }
        public ExpenseDetails ExpenseDetails { get; set; }
    }

}
