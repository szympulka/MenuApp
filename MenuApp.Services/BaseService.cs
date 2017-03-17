using MenuApp.Core.Entities;
namespace MenuApp.Services
{
    public abstract class BaseService

    {
        protected IDataContext _dataContext;
        public BaseService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
    } 
}
