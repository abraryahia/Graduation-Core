using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Graduation_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Core.Controllers
{

    public class ManageController : Controller
    {
        private readonly IConfiguration _config;
        private readonly DMSContext _context = new DMSContext();
        [BindProperty(Name = "ReturnUrl")]
        private string ReturnUrl { get; set; }
        public ManageController(IConfiguration config)
        {
            _config = config;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            var rd = ReturnUrl ?? "~/home/index";

            var usr = _context.UsersDetails.SingleOrDefault(u => u.UserPassword == Password && u.UsrName == UserName);
            if (usr != null)
            {
                HttpContext.Session.SetString("username", usr.UserFullName);
                HttpContext.Session.SetString("uid", usr.UserId + "");
                var userRole = usr.RoleId == 1 ? "Administrator" : "user";
                var claims = new List<Claim>
            {
                new Claim("usrname", usr.UsrName),
                new Claim("FullName", usr.UserFullName),
                new Claim(ClaimTypes.Role, userRole),
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),


                    RedirectUri = rd
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                if (userRole == "Administrator")
                    return RedirectToAction("AdminProfile", "manage");
                else
                    return RedirectToAction("Profile", "manage");

            }
            else
            {
                ModelState.AddModelError("", "Enter A Vaild Data");
                return RedirectToAction("login", "manage");

            }

        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("uid");
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "home");
        }
        public IActionResult Denied()
        {
            return View();
        }
        public IActionResult Register()
        {
            var dMSContext = _context.Employee.Include(e => e.EmpC).Include(e => e.EmpL);
            var cities = _context.City.ToList().Select(c => new CityModel() { ID = c.CId, Name = c.CName }).ToList();
            List<Locations> LsLocations = new List<Locations>();
            LsLocations = _context.Locations.ToList();
            var Lsl = LsLocations
                              .Select(s => new
                              {
                                  Text = s.LFrom + " ===> " + s.LTo,
                                  Value = s.LId
                              })
                              .ToList();
            cities.Insert(0, new CityModel() { ID = 0, Name = "==== Select City ====" });
            ViewData["cities"] = new SelectList(cities, "ID", "Name");
            ViewData["locs"] = new SelectList(Lsl, "Value", "Text");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (model !=null)
            {
                long seed = new Random().Next(200, 2000);
                var Id = _context.SenderInfo.ToList().Last().SId;
                var newId = Id + seed;
                var sender = _context.SenderInfo.Add(new SenderInfo() { SId=newId,SAddress = model.Address,SAddressDetail =model.AddressDetails , SCDId=model.LocationID
                   , SCId = model.C_ID,SEmail=model.Email , SMobile = model.Mobile,SName = model.FullName , SSsn = model.SSN
                });
                var newUser = _context.UsersDetails.Add(new UsersDetails() { Count = 0, RoleId = 2, UserFullName=model.FullName,UserId=newId,UsrName=model.Name,
                     UserPassword = model.Password
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("index", "home");
            }
            ViewBag.errors = "Registeration Error";
            return View();
        }
        public IActionResult AdminProfile()
        {
            var usrn = HttpContext.Session.GetString("username");
            if (usrn != null)
            {
                var uid = int.Parse(HttpContext.Session.GetString("uid"));
                string name = usrn;
                UsersDetails user = _context.UsersDetails.SingleOrDefault(x => x.UserId == uid);
                LoginViewModel profile = new LoginViewModel()
                {
                    UserName = user.UsrName,
                    Password = user.UserPassword,
                    FullName = user.UserFullName,
                    ID = user.UserId

                };
                return View(profile);
            }
            else
            {
                //RemoveData();
                return RedirectToAction("login");
            }
        }
        public ActionResult Profile()
        {
            var usrn = HttpContext.Session.GetString("username");
            if (usrn != null)
            {
                var uid = int.Parse(HttpContext.Session.GetString("uid"));
                string name = usrn;
                UsersDetails user = _context.UsersDetails.SingleOrDefault(x => x.UserId == uid);
                LoginViewModel profile = new LoginViewModel()
                {
                    UserName = user.UsrName,
                    Password = user.UserPassword,
                    FullName = user.UserFullName,
                    ID = user.UserId

                };
                return View(profile);
            }
            else
            {
                //RemoveData();
                return RedirectToAction("login");
            }
        }

        public IActionResult SendMail(long pid, string emailTo = "ahmedm.seada@gmail.com", string subject = "Order ", string message = "")
        {
            bool result = false;
            PackagesInfo package = _context.PackagesInfo.SingleOrDefault(x => x.PId == pid);
            var emailBody = $"<h4><span style=\"margin-left:2%%;\">Package {package.Description} Details: </span><p>ID : {package.PId}</p><p>Weight : {package.PWeight}</p><p>Price : {package.PPrice}</p><p>Sender ID : {package.SSsn}</p><p>Delevery Date :{package.Deleverydate.Value.ToShortDateString()}</p><p>Description : {package.Description}</p><span>To Track Your Package Visit : https://www.mds/ <br /> Regards<p>Regards <span style=\"color:#0474ac\">MDS Team &copy; {DateTime.Now.Year}</span></p></span></h4>";
            result = SendEmail(emailTo, subject, emailBody);
            return PartialView("_Sent");
        }



        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {

                string senderEmail = _config.GetValue(typeof(string), "senderEmail").ToString();
                string senderPassword = _config.GetValue(typeof(string), "senderPassword").ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                MailMessage message = new MailMessage(senderEmail, toEmail, subject, emailBody);
                message.IsBodyHtml = true;
                message.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(message);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public PartialViewResult SearchPakage(int ID = 0)
        {
            PackagesInfo package = _context.PackagesInfo.SingleOrDefault(x => x.PId == ID);
            return PartialView("_ReportPakage", package);

        }
    }
}