using System.Web.Mvc;
using SubRefactor.IRepository.Infrastructure;

namespace SubRefactor.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}