using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Facebook.Web;
using SubRefactor.Domain;
using SubRefactor.IRepository;
using SubRefactor.IRepository.Infrastructure;
using SubRefactor.Models.Account;

namespace SubRefactor.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUnitOfWork unitOfWork, IUserRepository userRepository)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public ActionResult RegisterLogOn(RegisterLogOnViewModel viewModel, string returnUrl)
        {
            if (FacebookWebContext.Current.IsAuthenticated())
            {
                var client = new FacebookWebClient();
                dynamic me = client.Get("me");

                if (!_userRepository.UserExist(me.username))
                {
                    var user = new User(AuthenticationType.Facebook) { Username = me.username };

                    _userRepository.Add(user);
                    _unitOfWork.Commit();
                }

                FormsAuthentication.SetAuthCookie((string)me.username, false);

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }    

            return View("RegisterLogOn", viewModel);
        }

        [HttpPost]
        public ActionResult LogOn(RegisterLogOnViewModel viewModel, string returnUrl)
        {
            ValidateModel(viewModel.LogOnViewModel);

            var user = Mapper.Map<LogOnViewModel, User>(viewModel.LogOnViewModel);

            if (ModelState.IsValid)
            {
                if (_userRepository.ValidateUser(user))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.LogOnViewModel.UserName, viewModel.LogOnViewModel.RememberMe);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        return Redirect(returnUrl);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return View("RegisterLogOn", viewModel);
        }

        [HttpPost]
        public ActionResult Register(RegisterLogOnViewModel viewModel)
        {
            ValidateModel(viewModel.RegisterViewModel);

            if (ModelState.IsValid)
            {
                var user = new User(AuthenticationType.Custom);
                Mapper.Map(viewModel.RegisterViewModel, user);
                
                _userRepository.Add(user);
                _unitOfWork.Commit();

                //TODO: Send confirmation e-mail
            }

            return View("RegisterLogOn", viewModel);
        }
    }
}
