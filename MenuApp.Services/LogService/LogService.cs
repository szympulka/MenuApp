using MenuApp.Core.Entities;
using MenuWeb.Core.Entities;

namespace MenuApp.Services.LogService
{
    public class LogService :BaseService, ILogService
    {
        public LogService(IDataContext dataContext) : base(dataContext)
        {
        }
        public void addLog(Log log)
        {

            _dataContext.Add<Log>(log);
            _dataContext.SaveChanges();
        }


    }
}