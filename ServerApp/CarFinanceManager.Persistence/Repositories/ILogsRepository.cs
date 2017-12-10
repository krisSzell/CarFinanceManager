using System.Collections.Generic;
using CarFinanceManager.Persistence.Models.Logging;

namespace CarFinanceManager.Persistence.Repositories
{
    public interface ILogsRepository
    {
        void PersistLog(FullLog log);
        IEnumerable<FullLog> GetAll();
    }
}
