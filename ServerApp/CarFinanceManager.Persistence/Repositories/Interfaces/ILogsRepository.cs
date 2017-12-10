using System.Collections.Generic;
using CarFinanceManager.Persistence.Models.Logging;

namespace CarFinanceManager.Persistence.Repositories.Interfaces
{
    public interface ILogsRepository
    {
        void PersistLog(FullLog log);
        IEnumerable<FullLog> GetAll();
    }
}
