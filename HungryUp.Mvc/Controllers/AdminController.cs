using HungryUp.Domain.Contracts.Services;
using HungryUp.Mvc.ViewModel;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Simple_Authenticate.Controllers
{
    public class AdminController : Controller
    {
        IUserService _service;

        public AdminController(IUserService service)
        {
            this._service = service;
        }

        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    HungryUp.Domain.Model.User user = _service.Authenticate(model.Email, model.Password);

                    FormsAuthentication.SetAuthCookie(user.Email, model.RememberMe);

                    if (this.Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}