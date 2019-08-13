using AjaxProject.Models;
using AjaxProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AjaxProject.Controllers
{
    public class UserController : Controller
    {
        //User
        // GET: Admin/Login
        UserRepository ur = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult getUserList()
        {
            var list = ur.List();
            return Json(list, JsonRequestBehavior.AllowGet);
            //GetAsync--details 
            //PostAsync--Add
            //PutAsync--update
            //DeleteAsync---delete
            //IEnumerable<UserModel> u;
            //HttpResponseMessage response = GlobalVariables.userapi.GetAsync("Useraip/GetUser").Result;
            //u = response.Content.ReadAsAsync<IEnumerable<UserModel>>().Result;
            //return Json(u, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginUser(string username, string password)
        {

            var data = ur.LoginCheck(username, password);
            if (data != null)
            {
                Session["loginstatus"] = data.Full_Name;
                Session["profileid"] = data.Login_ID;
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        




        // GET: Admin/Login/Create
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.rol = ur.getAllRoles();
            return View();
        }

        // POST: Admin/Login/Create
        [HttpPost]
        public ActionResult Register(UserModel dat)
        {
            var data = ur.User_Exist(dat.Username);
            if (data!= null)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else
            {

                ur.Add(dat);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
                
                


        }



        public ActionResult UserRoles()
        {
            var data = ur.getAllRoles();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/Login/Create
        [HttpPost]
        public ActionResult Edit(UserModel dat)
        {
            var data = ur.User_Exist(dat.Username);
            if(dat ==null || data != null)
            { 
                
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ur.Edit(dat);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
        }




        public JsonResult GetById(int? id)
        {
            var data = ur.getbyUserID(id);
            return Json(data, JsonRequestBehavior.AllowGet);  
        }


        //POST: User/Delete/5
        public ActionResult Delete(int? uid)
        {
            ur.Delete(uid);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string sear)
        {
           var list = ur.search_list(sear);
            return Json(list,JsonRequestBehavior.AllowGet);
        }


        //Cascade Dropdown for country and state

        public JsonResult DropCountry()
        {
            var clist = ur.DropdownCountry();
            return Json(clist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DropState(int? id)
        {
            var slist = ur.DropdownState(id);
            return Json(slist, JsonRequestBehavior.AllowGet);
        }











    }
}

