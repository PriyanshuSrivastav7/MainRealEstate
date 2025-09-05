using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainRealEstate.Models;

namespace MainRealEstate.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        REALSTATEEntities db = new REALSTATEEntities();
        EmailSender es = new EmailSender();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_Booking book)
        {
            try
            {
                book.BookingDate = DateTime.Now.ToString();
                db.TBL_Booking.Add(book);
                db.SaveChanges();
                
                Response.Write("<script>alert('Record Save Successfully')</script>");
            }
            catch
            {
                Response.Write("<script>alert('Record Not Save')</script>");
            }

            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Media()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(TBL_Contact1 rt)
        {
            try
            {
                rt.ContactDate = DateTime.Now.ToString();
                db.TBL_Contact1.Add(rt);
                db.SaveChanges();
                es.SendMyEmail(rt.Email, "Regards my project:", "Thanks " + rt.Email + "  Welcome to contact for my email");
                Response.Write("<script>alert('Record Save Successfully')</script>");
            }
            catch
            {
                Response.Write("<script>alert('Record Not Save')</script>");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBL_Login lg)
        {
            try
            {
                TBL_Login t1 = db.TBL_Login.Where(x => x.Email == lg.Email && x.Password == lg.Password).SingleOrDefault();
                if (t1 != null)
                {
                    Session["aid"] = t1.Email;
                    Response.Write("<script>alert('Welcome To The AdminZone');window.location.href='/AdminZone/Index'</script>");
                }
                else {
                    Response.Write("<script>alert('Invalid User Id Or Password')</script>");
                }

            }
            catch
            {
            }
            return View();
        }

        public ActionResult Reg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reg(TBL_Registration rg, string hdn1, string ct1)
        {
            try
            {
                if (hdn1==ct1)
                {
                    //start code for file upload
                    HttpPostedFileBase file = Request.Files["profile"];
                    file.SaveAs(Server.MapPath("../Content/imgpro/" + file.FileName.ToString()));
                    rg.Profile = file.FileName.ToString();
                    //End File upload
                    rg.RegDate = DateTime.Now.ToString();
                    db.TBL_Registration.Add(rg);
                    db.SaveChanges();
                    Response.Write("<script>alert('Record save successfuly')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Captcha code ')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record Not save')</script>");
            }
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Clubs()
        {
            return View();
        }
    }
}
