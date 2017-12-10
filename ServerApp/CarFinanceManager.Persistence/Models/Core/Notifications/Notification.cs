using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Persistence.Models.Core.Notifications
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public NotificationType Type { get; set; }
        public DateTime DueDate { get; set; }
        public ExpenseDetails ExpenseDetails { get; set; }
    }

}
