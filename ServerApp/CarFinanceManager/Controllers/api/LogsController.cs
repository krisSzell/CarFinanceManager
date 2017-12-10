using System.Web.Http;
using CarFinanceManager.Persistence.Repositories;

namespace CarWash.Controllers.api
{
    [RoutePrefix("api/logs")]
    public class LogsController : ApiController
    {
        private readonly ILogsRepository _logsRepository;

        public LogsController(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllLogs()
        {
            return Ok(_logsRepository.GetAll());
        }
    }
}
