using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ev_JinSe.Controllers
{
    public class CoinsController : Controller
    {
        //
        // GET: /Coins/

        public ActionResult Index()
        {
            ViewBag.coinsTitle = toolsWebRequest.coinsListTitle();
            ViewBag.coinsDetail = toolsWebRequest.coinsListDetails();

            return View();
        }

        /// <summary>
        /// 行情列表
        /// </summary>
        /// <returns></returns>
        public ActionResult coinsMarket() {
            string strHtml = toolsWebRequest.loadNewsDetailStr("/market");
            ViewBag.strHtml = strHtml;
            return View();
        }

    }
}
