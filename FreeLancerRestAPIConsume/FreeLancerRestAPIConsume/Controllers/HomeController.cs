using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeLancerRestAPIConsume.Models;
using FreeLancerRestAPIConsume.BAL;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FreeLancerRestAPIConsume.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Create()
        {
            ViewBag.Message = "Your are in Index View.";
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Your are in Index View.";
            User_BL userObjBL = new FreeLancerRestAPIConsume.BAL.User_BL();
            IEnumerable<Users> userList = userObjBL.GetUserList();
            return View(userList);
            //< Users > books = IEnumerable(userList);
           // return View(userList as IEnumerable<Users>);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Your are in Edit View.";
            User_BL userObjBL = new FreeLancerRestAPIConsume.BAL.User_BL();
            IEnumerable<Users> userList = userObjBL.GetUserDetailsById(id);
            var car = userList.FirstOrDefault((I) => I.UserId == id);
            if (car == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return View( car);

           // return View(userList);
        }

        public ActionResult Delete(int id)
        {
            User_BL userObjBL = new FreeLancerRestAPIConsume.BAL.User_BL();
            int i =  userObjBL.DeleteUserInfo(id);
            if (i == 0)
            {
                return RedirectToAction("Index");
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            } else return RedirectToAction("Index");

            // return View(userList);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Users model)
        {
            if (ModelState.IsValid)
            {
                User_BL userObjBL = new FreeLancerRestAPIConsume.BAL.User_BL();
                int i = userObjBL.UpdateUserInfo(model);
                return RedirectToAction("Index");
            }
           return View("Edit", model) ;

        }

        [HttpPost]
        public ActionResult Add(Users model)
        {
            if (ModelState.IsValid)
            {
                User_BL userObjBL = new FreeLancerRestAPIConsume.BAL.User_BL();
                int i = userObjBL.AddUserInfo(model);
            }
                return RedirectToAction("Index");

        }

        public ActionResult Find(Users model)
        {
            User_BL userObjBL = new FreeLancerRestAPIConsume.BAL.User_BL();
            IEnumerable<Users> userList = userObjBL.GetUserDetailsByName(model.UserName, model.Email);
            var car = userList.FirstOrDefault((I) => I.UserName.Contains( model.UserName ) ||  I.Email.Contains(model.Email));
            if (car == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //return View("Index",car);

            return View("Index", userList);
        }
        //public ActionResult Index(Users model)
        //{
        //    return View(model);
        //    //< Users > books = IEnumerable(userList);
        //    // return View(userList as IEnumerable<Users>);
        //}
    }
}