using HereosBank.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HereosBank.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public DashBoardController()
        {

        }
        //public DashBoardController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}


        //#region Constructeurs de Gestionnaires
        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}
        //#endregion

        // GET: DashBoard

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {


            if (!ModelState.IsValid)
            {

                return View(model);
            }
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            Userman user = userManager.Find(model.Email, model.Password);

            if (user != null)
            {

                ///Créer une méthode pour l'identification 
                ///la nommer et la remplacer par ce code ci-dessous pour alléger la compréhension du code
                ///

                var ident = userManager.CreateIdentity(user,
                DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, ident);

                return RedirectToLocal(returnUrl);

            }
            else
            {
                ModelState.AddModelError("", "Erreur de connexion");
                return View(model);
            }

            // Ceci ne comptabilise pas les échecs de connexion pour le verrouillage du compte
            // Pour que les échecs de mot de passe déclenchent le verrouillage du compte, utilisez shouldLockout: true
            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            //if(result== SignInStatus.Success)
            //{
            //    return RedirectToLocal(returnUrl);
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Tentative de connexion non valide.");
            //    return View(model);
            //}
        }


        #region Créer un compte
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)

        {

            if (ModelState.IsValid)
            {
                var user = new Userman { UserName = model.Email, Email = model.Email };
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;
                try
                {
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                        authManager.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, ident);
                        //return Redirect(returnUrl ?? Url.Action("Index", "Dashboard"));
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                catch (Exception ew)
                {
                    Console.WriteLine(ew.Message);
                    ModelState.AddModelError("", ew.Message);

                }
            }
            #region Ancien code à revoir

            //if (ModelState.IsValid)
            //{
            //    var user = new Userman { UserName = model.Email, Email = model.Email };
            //    try
            //    {
            //        var result = await UserManager.CreateAsync(user, model.Password);
            //        if (result.Succeeded)
            //        {
            //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            //            // Pour plus d'informations sur l'activation de la confirmation de compte et de la réinitialisation de mot de passe, visitez https://go.microsoft.com/fwlink/?LinkID=320771
            //            // Envoyer un message électronique avec ce lien
            //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            //            // await UserManager.SendEmailAsync(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=\"" + callbackUrl + "\">ici</a>");

            //            return RedirectToAction("Index", "Dashboard");
            //        }
            //        AddErrors(result);

            //    }
            //    catch (Exception ex)
            //    {

            //        Console.WriteLine(ex.Message);
            //        Console.WriteLine(user.Email + "\n" + user.PasswordHash);
            //        string exx = ex.Message + " \n" + user.Email + "\n" + user.PasswordHash;
            //        ModelState.AddModelError("", exx);
            //    }
            //}

            #endregion

            // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            return View(model);
        }
        #endregion

        #region Déconnexion
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Dashboard");
        }

        #endregion

        #region Méthodes locales
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion

        public ActionResult ManageUser ()
        {
            return View();
        }
    }



   
}