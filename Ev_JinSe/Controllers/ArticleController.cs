using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ev_JinSe.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/

        public ActionResult Index(string hs)
        {
            string strHtml = string.Empty;
            if (hs != null && hs.Trim().Length > 0)
            {
                string str = HttpUtility.HtmlDecode(hs);
               strHtml = toolsWebRequest.loadNewsDetailStr(str);
            }
            ViewBag.ssss = strHtml;
            return View();
        }

        public ActionResult Detail(string hs) {
            if (hs == "1s")
            {
                ViewBag.ssss = "<h1>sdjhkjsdhkjadfhgdfkjh</h1>";
            }
            else {
                string str = "<div style=\" skjfsdfjh  \">";

                ViewBag.ssss = "1231231111111111111111111";
            }
            
            return View();
        }
    }
}
