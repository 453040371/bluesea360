using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ev_JinSe.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           string sss =  toolsWebRequest.loadNewsStr("http://www.jinse.com");
           ViewBag.xxxhtml = sss;
            string chatStr = string.Empty;
           string strHomeChat = toolsWebRequest.loadHomeChat();
           ViewBag.strHomeChat = strHomeChat;
            return View();
        }

        public ActionResult JiuCaiTong() {
            return View();
        }

        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutMe() {
            return View();
        }


    }
}
