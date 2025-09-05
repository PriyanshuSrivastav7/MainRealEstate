using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainRealEstate.Models;
namespace MainRealEstate.Controllers
{
    public class AdminZoneController : Controller
    {
        //
        // GET: /AdminZone/
        REALSTATEEntities db = new REALSTATEEntities();


        public ActionResult Index()
        {
            if (Session["aid"] != null)
            {
            }
            else
            {
                Response.Write("<script>alert('Login first');window.location.href='/Home/Login'</script>");
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldpasswd, string newpasswd, string confirmpasswd)
        { 
            if (newpasswd == confirmpasswd)
            {
                string email = Session["aid"].ToString();
                TBL_Login lg = db.TBL_Login.Where(x => x.Password == oldpasswd && x.Email == email).SingleOrDefault();
                lg.Password = newpasswd;
                db.SaveChanges();
                Response.Write("<script>alert('Change Password  Successfully');window.location.href='/Home/LogIn'</script>");
            }
            else
            {
                Response.Write("<script>alert('Password not Change ');window.location.href='/AdminZone/ChangePassword'</script>");
            }

            return View();
        }
        public ActionResult ContactMGMT()
        {
            if (Session["aid"] != null)
            {
            }
            else
            {
                Response.Write("<script>alert('Login First Then go NextZone');window.location.href='/Home/LogIn'</script>");
            }
            List<TBL_Contact1> lst = null;
            lst = db.TBL_Contact1.ToList();
            return View(lst);
        }
        public ActionResult RegistrationMGMT()
        {
            if (Session["aid"] != null)
            {
            }
            else
            {
                Response.Write("<script>alert('Login First Then go NextZone');window.location.href='/Home/LogIn'</script>");
            }
            List<TBL_Registration> ds = db.TBL_Registration.ToList();
            return View(ds);
        }


        public void logout()
        {
            Session.Abandon();
            Response.Write("<script>alert('LogOut');window.location.href='/Home/LogIn'</script>");

        }

        public void delete()
        {
            try
            {
                string m = Request.QueryString["m"];
                TBL_Registration tb = db.TBL_Registration.SingleOrDefault(x => x.Email == m);
                db.TBL_Registration.Remove(tb);
                db.SaveChanges();
                Response.Write("<script>alert('Record Deleted');window.location.href='/AdminZone/RegistrationMGMT'</script>");
            }
            catch
            {
                Response.Write("<script>alert('Record Not Deleted');window.location.href='/AdminZone/RegistrationMGMT'</script>");
            }
        }
        public ActionResult UpdateRecord()
        {
            string aid = Request.QueryString["u"];
            TBL_Registration reg = db.TBL_Registration.SingleOrDefault(a => a.Email == aid);
            return View(reg);
        }
        [HttpPost]
        public void UpdateRecord(TBL_Registration re, string Email)
        {

            TBL_Registration rg = db.TBL_Registration.SingleOrDefault(a => a.Email == Email);
            try
            {
                HttpPostedFileBase file = Request.Files["Profile"];
                if(file.FileName != "")
                {
                    rg.Name = re.Name;
                    rg.Mobile = re.Mobile;
                    rg.Profile = re.Profile;
                    rg.RegDate = re.RegDate;
                    rg.Gender = re.Gender;
                    rg.Address = re.Address;
                    rg.DOB = re.DOB;
                    rg.Profile = file.FileName.ToString();
                    file.SaveAs(Server.MapPath("../Content/imgpro" + file.FileName.ToString()));
                    db.SaveChanges();
                    Response.Write("<script>alert('Record Update Successfuly');window.location.href='/AdminZone/RegistrationMGMT'</script>");
                }
                else
                {
                    TBL_Registration rt = db.TBL_Registration.SingleOrDefault(a => a.Email == Email);
                    rt.Name = re.Name;
                    rt.Mobile = re.Mobile;
                    rt.RegDate = re.RegDate;
                    rt.Gender = re.Gender;
                    rt.Address = re.Address;
                    rt.DOB = re.DOB;
                    db.SaveChanges();
                    Response.Write("<script>alert('Record Not Update ');window.location.href='/AdminZone/RegistrationMGMT'</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record not Update');window.location.href='/AdminZone/RegistrationMGMT'</script>");
            }
        }
        public void delete1()
        {
            try
            {
                string m = Request.QueryString["m"];
                TBL_Contact1 tb = db.TBL_Contact1.SingleOrDefault(x => x.Email == m);
                db.TBL_Contact1.Remove(tb);
                db.SaveChanges();
                Response.Write("<script>alert('Record Deleted');window.location.href='/AdminZone/RegistrationMGMT'</script>");
            }
            catch
            {
                Response.Write("<script>alert('Record Not Deleted');window.location.href='/AdminZone/RegistrationMGMT'</script>");
            }
        }
        public ActionResult BookingMGMT()
        {
            if (Session["aid"] != null)
            {
            }
            else
            {
                Response.Write("<script>alert('Login First Then go NextZone');window.location.href='/Home/LogIn'</script>");
            }
            List<TBL_Booking> lst = null;
            lst = db.TBL_Booking.ToList();
            return View(lst);
            
            
        }


        public void delete2()
        {
            try
            {
                string m = Request.QueryString["m"];
                TBL_Booking tb = db.TBL_Booking.SingleOrDefault(x => x.Email == m);
                db.TBL_Booking.Remove(tb);
                db.SaveChanges();
                Response.Write("<script>alert('Record Deleted');window.location.href='/AdminZone/BookingMGMT'</script>");
            }
            catch
            {
                Response.Write("<script>alert('Record Not Deleted');window.location.href='/AdminZone/BookingMGMT'</script>");
            }
        }
      

    }
}
