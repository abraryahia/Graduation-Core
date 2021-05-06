using Graduation_Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Graduation_Core.Controllers
{
    public class PackageController : Controller
    {
        private readonly DMSContext db = new DMSContext();
        private readonly IConfiguration _config;
        private IHostingEnvironment _hostingEnvironment;
        public PackageController(IConfiguration config, IHostingEnvironment hostingEnvironment)
        {
            _config = config;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Send()
        {
            var cities = db.City.ToList().Select(c => new CityModel() { ID = c.CId, Name = c.CName }).ToList();
            cities.Insert(0, new CityModel() { ID = 0, Name = "==== Select City ====" });
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.mcities = cities;
                var SID = long.Parse(HttpContext.Session.GetString("uid"));
                var SCity = db.SenderInfo.SingleOrDefault(s => s.SId == SID).SCId;
                ViewBag.scid = SCity;

            }
            Random rand = new Random();
            long PackageID = Math.Abs((db.PackagesInfo.ToList().Last().PId + rand.Next(100, int.MaxValue)) % int.MaxValue);
            HttpContext.Session.SetString("pid", PackageID.ToString());
            ViewBag.pid = HttpContext.Session.GetString("pid");
            dynamic model = new ExpandoObject();
            model.p = new PackagViewModel();
            model.s = new SenderViewModel();
            model.r = new ReciverViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(SenderViewModel s, PackagViewModel p, ReciverViewModel r)
        {
            if (s.Name != null && p.Fargial != null && r.Name != null)
            {

                Random rand = new Random();
                City SenderCity = db.City.FirstOrDefault(c => c.CId == s.C_ID);
                City RecieverCity = db.City.FirstOrDefault(c => c.CId == r.C_ID);
                if (HttpContext.Session.GetString("uid")!=null)
                {
                    long ReciverID = Math.Abs((db.ReceiverInfo.ToList().Last().RId + rand.Next(100, int.MaxValue)) % int.MaxValue);
                    long PackageID = long.Parse(HttpContext.Session.GetString("pid").ToString());
                    var price = Price(p.Wight, p.Fargial, p.Early) + RoadPrice(SenderCity.CName, RecieverCity.CName);
                    ViewBag.P_ID = PackageID;
                    //=========Sender Data===================//
                    var SenderID = long.Parse(HttpContext.Session.GetString("uid"));
                    //long SenderID = db.SenderInfo.
                    //============ Reciever Data ============//
                    ReceiverInfo Receiver = new ReceiverInfo()
                    {
                        RId = ReciverID,
                        RName = r.Name,
                        RAddress = RecieverCity.CName,
                        SId = SenderID,
                        RSsn = r.SSN,
                        RCDId = r.LocationID,
                        RCId = r.C_ID,
                        RAddressDetail = r.AddressDetails,
                        REmail = r.Email,
                        RMobile = r.Mobile,


                    };
                    //=========Package Data================//
                    PackagesInfo package = new PackagesInfo()
                    {
                        PId = PackageID,
                        Deleverydate = p.Date,
                        Earlydelivery = p.Early,
                        Description = p.Describtion,
                        PWeight = p.Wight,
                        PDeliverStatus = "no",
                        PFaragial = p.Fargial,
                        PPrice = price,
                        RSsn = r.SSN,
                        SSsn = s.SSN,
                        PLId = s.LocationID
                    };
                    db.ReceiverInfo.Add(Receiver);
                    db.SaveChanges();
                    db.PackagesInfo.Add(package);
                    db.SaveChanges();
                    SendMobileMessage(package, Receiver.RMobile);
                }
                else
                {
                    long SenderID = (long)Math.Abs((db.SenderInfo.ToList().Last().SId + rand.Next(100, int.MaxValue)) % int.MaxValue);
                    long ReciverID = Math.Abs((db.ReceiverInfo.ToList().Last().RId + rand.Next(100, int.MaxValue)) % int.MaxValue);
                    long PackageID = long.Parse(HttpContext.Session.GetString("pid").ToString());
                    var price = Price(p.Wight, p.Fargial, p.Early) + RoadPrice(SenderCity.CName, RecieverCity.CName);
                    ViewBag.P_ID = PackageID;
                    //=========Sender Data===================//
                    SenderInfo Sender = new SenderInfo()
                    {
                        SId = SenderID,
                        SAddress = SenderCity.CName,
                        SCDId = s.LocationID,
                        SCId = s.C_ID,
                        SEmail = s.Email,
                        SMobile = s.Mobile,
                        SAddressDetail = s.AddressDetails,
                        SName = s.Name,
                        SSsn = s.SSN,

                    };
                    //============ Reciever Data ============//
                    ReceiverInfo Receiver = new ReceiverInfo()
                    {
                        RId = ReciverID,
                        RName = r.Name,
                        RAddress = RecieverCity.CName,
                        SId = SenderID,
                        RSsn = r.SSN,
                        RCDId = r.LocationID,
                        RCId = r.C_ID,
                        RAddressDetail = r.AddressDetails,
                        REmail = r.Email,
                        RMobile = r.Mobile,


                    };
                    //=========Package Data================//
                    PackagesInfo package = new PackagesInfo()
                    {
                        PId = PackageID,
                        Deleverydate = p.Date,
                        Earlydelivery = p.Early,
                        Description = p.Describtion,
                        PWeight = p.Wight,
                        PDeliverStatus = "no",
                        PFaragial = p.Fargial,
                        PPrice = price,
                        RSsn = r.SSN,
                        SSsn = s.SSN,
                        PLId = s.LocationID
                    };
                    db.SenderInfo.Add(Sender);
                    db.ReceiverInfo.Add(Receiver);
                    db.SaveChanges();
                    db.PackagesInfo.Add(package);
                    db.SaveChanges();
                    SendMobileMessage(package, Receiver.RMobile);
                }
                
                return RedirectToAction("Index", "Home");
            }
            //Checked in
            ViewBag.Error = "Please Enter Data Correctly ";
            return View();
        }
        public void SendMail(long pid, string emailTo = "ahmedm.seada@gmail.com", string subject = "sub", string message = "")
        {


            PackagesInfo package = db.PackagesInfo.SingleOrDefault(x => x.PId == pid);

            var emailBody = $"<h4><span style=\"margin-left:2%%;\">Package {package.Description} Details: </span><p>ID : {package.PId}</p><p>Weight : {package.PWeight}</p><p>Price : {package.PPrice}</p><p>Sender ID : {package.SSsn}</p><p>Delevery Date :{package.Deleverydate.Value.ToShortDateString()}</p><p>Description : {package.Description}</p><span>To Track Your Package Visit : https://www.mds/ <br /> Regards<p>Regards <span style=\"color:#0474ac\">MDS Team &copy; {DateTime.Now.Year}</span></p></span></h4>";
            SendEmail(emailTo, "Your Order Recorded", emailBody);

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

        private void SendMobileMessage(PackagesInfo p, string _mobile)
        {

            string usName = _config.GetValue(typeof(string), "un").ToString();
            string password = _config.GetValue(typeof(string), "passWord").ToString();
            string email = _config.GetValue(typeof(string), "email").ToString();
            string accpassword = _config.GetValue(typeof(string), "pass").ToString();
            string language = "1";
            string Sender = "MDS Team";
            string mobile = _mobile;
            string msg = $@"
            Order Saved
            ID : {p.PId}
            Price: {p.PWeight}
            Sender ID : {p.SSsn}
            Track at : www.mds.com
            Regards MDS_Team {DateTime.Now.Year}";
            string postUrl = $"https://smsmisr.com/api/webapi/?username={usName}&password={password}&language={language}&sender={Sender}&mobile={mobile}&message=" + msg;
            WebRequest requestObject = WebRequest.Create(postUrl);
            requestObject.Credentials = new NetworkCredential(email, accpassword);
            requestObject.Method = "POST";
            requestObject.ContentType = "application/json";
            var result = "";
            using (var SW = new StreamWriter(requestObject.GetRequestStream()))
            {
                SW.Flush();
                SW.Close();
                var httpResponse = (HttpWebResponse)requestObject.GetResponse();
                using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }
        }

        public JsonResult GetLocations(int id)
        {
            List<CityDetails> locations = db.CityDetails.ToList();
            var models = locations.Where(l => l.CId == id).Select(m => new LocationsModel() { ID = m.CDId, Name = m.TCName }).ToList();
            return Json(new SelectList(models, "ID", "Name"));
        }
        public JsonResult LocationPrice(string from, string to)
        {
            var model = RoadPrice(from, to);
            return Json(model);
        }
        private float RoadPrice(string from, string to)
        {
            List<Locations> locations = db.Locations.ToList();
            foreach (var location in locations)
            {
                if (location.LFrom == from && location.LTo == to)
                {
                    return location.Price;
                }
            }

            return 0;
        }
        public JsonResult CalcPrice(double weight, int fra, int ear, int s_c, int r_c)
        {
            var from = db.City.FirstOrDefault(c => c.CId == s_c).CName;
            var to = db.City.FirstOrDefault(c => c.CId == r_c).CName;
            var roadPrice = RoadPrice(from, to);
            var mprice = Price(weight, fra + "", ear + "") + roadPrice;
            return Json(mprice);
        }
        private double Price(double weight, string fra, string ear)
        {
            var price = GetPrice();
            double mprice = (weight * price.KgPrice);
            if (fra == "2")
                mprice += price.Fragial;
            if (ear == "2")
                mprice = mprice + (mprice * price.Early);
            return mprice;
        }
        private PriceModel GetPrice()
        {
            var dbprice = db.Calculations.FirstOrDefault(p => p.CalcId == 1);
            var price = new PriceModel() { Early = dbprice.CalcEarly, Fragial = dbprice.CalcFragile, KgPrice = dbprice.CalcWeight };
            return price;

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Track(long id)
        {

            var loc = db.PackagesInfo.SingleOrDefault(p => p.PId == id);
            if (loc != null)
            {
                var locations = db.Locations.SingleOrDefault(l => l.LId == loc.PLId);
                var FromCity = db.City.SingleOrDefault(c => c.CId == locations.CId);
                var ToCity = db.City.SingleOrDefault(cn => cn.CName == locations.LTo);
                CoordiantesModel coordiantes = new CoordiantesModel()
                {
                    //==== From City =====
                    FLat = FromCity.CLat,
                    FLong = FromCity.CLong,
                    // ======  To City =====
                    TLat = ToCity.CLat,
                    TLong = ToCity.CLong

                };
                return View(coordiantes);
            }
            else
                return View("Error");

        }
        public ActionResult Report()
        {
            return View(from Packages_Info in db.PackagesInfo.Take(10)
                        select Packages_Info);
        }
        public PartialViewResult ReportPakage(int ID)
        {
            PackagesInfo package = db.PackagesInfo.SingleOrDefault(x => x.PId == ID);
            return PartialView("_ReportPakage", package);

        }
        // GET: Report
        public PartialViewResult Packages(string ID)
        {
            List<PackagesInfo> packages = db.PackagesInfo.ToList();
            packages = db.PackagesInfo.Where(x => x.SSsn == ID).ToList();
            ViewBag.Packages = packages;
            return PartialView("_packages", packages);

        }
    }
}