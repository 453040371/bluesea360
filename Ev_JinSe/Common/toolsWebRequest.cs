using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Ev_JinSe
{
    public static class toolsWebRequest
    {
        static HtmlAgilityPack.HtmlDocument xmlDoc;//首页
        static string urlWWW = "http://www.jinse.com";



        #region 网址导航


        /// <summary>
        /// 网址导航的title
        /// </summary>
        /// <returns></returns>
        public static string naviListTitle()
        {
            string htmlUrl = "http://www.jinse.com/nav";
            HtmlDocument xmldd = new HtmlWeb().Load(htmlUrl);
            var coinsTitle = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"tab-nav\"]");
            var str = coinsTitle.OuterHtml.Replace("http://resource.jinse.com/phenix/img/nobg.png", "");
            return str;

        }
        /// <summary>s
        /// 网址导航的详情列表
        /// </summary>
        /// <returns></returns>
        public static string naviListDetails()
        {
            string htmlUrl = "http://www.jinse.com/nav";
            HtmlDocument xmldd = new HtmlWeb().Load(htmlUrl);
            var coinsTitle = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"tabnav-content\"]");
            return coinsTitle.OuterHtml;
        }

        /// <summary>s
        /// 网址导航的详情列表2
        /// </summary>
        /// <returns></returns>
        public static string naviListDetails2()
        {
            string htmlUrl = "http://www.jinse.com/nav";
            HtmlDocument xmldd = new HtmlWeb().Load(htmlUrl);
            var coinsTitle = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"tabnav-contents\"]");
            return coinsTitle.OuterHtml;
        }

        #endregion

        #region 币值  行情

        public static string coinsMarket()
        {
            HtmlDocument xmldd = new HtmlWeb().Load("http://www.jinse.com/market");
            var htmlDDs = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"wrap marginb clearfix\"]");
            return "";
        }


        /// <summary>
        /// 币值的title
        /// </summary>
        /// <returns></returns>
        public static string coinsListTitle()
        {
            string htmlUrl = "http://www.jinse.com/currencies";
            HtmlDocument xmldd = new HtmlWeb().Load(htmlUrl);
            var coinsTitle = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"rankings\"]");
            return coinsTitle.OuterHtml;

        }
        /// <summary>
        /// 币值的详情列表
        /// </summary>
        /// <returns></returns>
        public static string coinsListDetails()
        {
            string htmlUrl = "http://www.jinse.com/currencies";
            HtmlDocument xmldd = new HtmlWeb().Load(htmlUrl);
            var coinsTitle = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"ranking-content\"]");
            return coinsTitle.OuterHtml;
        }

        #endregion

        #region 文章详情


        //新闻文章详情
        public static string loadNewsDetailStr(string htmlUrl)
        {
            string urlStr = urlWWW + htmlUrl;
            HtmlDocument xmldd = new HtmlWeb().Load(urlStr);
            var htmlDDs = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"wrap marginb clearfix\"]");
            if (htmlDDs == null)
            {
                htmlDDs = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"wrap margin-b clearfix\"]");
                if (htmlDDs == null)
                {
                    return "";
                }
            }

            //删除右侧文章作者信息
            var strZuozhe = htmlDDs.SelectSingleNode("//div[@class=\"index-column f\"]");
            if (strZuozhe != null)
            {
                strZuozhe.InnerHtml = "";
            }

            //删除文章中间作者信息
            var strZuozhe2 = htmlDDs.SelectSingleNode("//span[@class=\"left namez\"]");
            if (strZuozhe2 != null)
            {
                strZuozhe2.InnerHtml = "<a class='blue' href='javascript:void(0);'>由网友提供</a>";
            }

            //删除文章中间作者信息
            var strZuozhe3 = htmlDDs.SelectSingleNode("//div[@class=\"time gray5 font12 margin-b10\"]");
            if (strZuozhe3 != null)
            {
                strZuozhe3.InnerHtml = "";
            }

            //删除文章中间作者信息
            var strImglist = htmlDDs.SelectSingleNode("//div[@class=\"con line33 font16\"]");
            if (strImglist != null)
            {
                Regex reges = new Regex(@"<img(.*?)>");
                MatchCollection matchList = reges.Matches(strImglist.InnerHtml);
                var ss = matchList.Count;
                for (int i = 0; i < matchList.Count; i++)
                {
                    var strImg = matchList[i].Groups[0].Value;
                    strImglist.InnerHtml = strImglist.InnerHtml.Replace(strImg, "");
                }
            }


            //获取和修改A标签里面的href路径，设置为本地地址
            var htmlAlist = htmlDDs.SelectNodes("//a");
            for (int i = 0; i < htmlAlist.Count(); i++)
            {
                var htmlHref = htmlAlist[i].Attributes["href"];
                if (htmlHref == null)
                {
                    continue;
                }
                string strHrefValue = htmlHref.Value;


                if (strHrefValue.Length < 4)
                {
                    continue;
                }
                var strLast = strHrefValue.Substring(strHrefValue.Length - 4, 4);
                
                string strReplace = string.Empty;
                if (strLast.Equals("html"))
                {
                    string hU = strHrefValue.Replace(urlWWW, "");
                    hU = HttpUtility.UrlEncode(hU);
                    strReplace = "/Article/Index?hs=" + hU;
                    htmlAlist[i].SetAttributeValue("href", strReplace);
                }
                else
                {
                    strReplace = "javascript:void(0);";
                    htmlAlist[i].SetAttributeValue("href", strReplace);
                }
            }

             var strBanQuan = htmlDDs.SelectSingleNode("//div[@class=\"reading line30\"]");
             if (strBanQuan!=null)
             {
                 strBanQuan.InnerHtml = @"声明：本文由入驻网友转载，观点仅代表作者本人，绝不代表本站赞同其观点或证实其描述。";
             }

            string str = htmlDDs.OuterHtml.Replace(@"金色财经的作者撰写", "网友转载");
            str = str.Replace("金色财经", "本站");
            str = str.Replace("http://resource.jinse.com/phenix/img/nobg.png", "");
            return str;
        }

        #endregion

        #region 首页


        /// <summary>
        /// 首页新闻列表
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string loadNewsStr(string html)
        {

            if (xmlDoc == null)
            {
                xmlDoc = new HtmlWeb().Load(html);
            }

            //获取文章DIV模块
            var htmlDDs = xmlDoc.DocumentNode.SelectSingleNode("//div[@id='main1']");
            var bugSum = htmlDDs;
            
            //获取文章列表模块
            //HtmlNode idmain1 = bugSum.SelectSingleNode("//div[@id='main1']");
           
            var hrefList = bugSum.SelectNodes("//ol[@class='list clearfix']/a");
                
            for (int j = 0; j < hrefList.Count; j++)
            {
                var htmlHref = hrefList[j].Attributes["href"];
                if (htmlHref == null)
                {
                    continue;
                }
                string strHrefValue = htmlHref.Value;
                if (strHrefValue.Substring(0, 20) != urlWWW)
                {
                    continue;
                }
                if (strHrefValue.Length < 20)
                {
                    continue;
                }


                var strLast = strHrefValue.Substring(strHrefValue.Length - 4, 4);
                string strReplace = string.Empty;
                if (strLast.Equals("html"))
                {
                    string htmlUrl = strHrefValue.Replace(urlWWW, "");
                    htmlUrl = HttpUtility.UrlEncode(htmlUrl);
                    strReplace = "/Article/Index?hs=" + htmlUrl;
                    hrefList[j].SetAttributeValue("href", strReplace);
                }
                else
                {
                    strReplace = "javascript:void(0);";
                    hrefList[j].SetAttributeValue("href", strReplace);
                }
                //htmlDDs.InnerHtml.Replace(strHrefValue, strReplace);
                htmlDDs.SelectSingleNode("//a[@href=\"" + strHrefValue + "\"]").SetAttributeValue("href", strReplace);

            }
            var s = htmlDDs.OuterHtml.Replace("http://resource.jinse.com/phenix/img/nobg.png", "");
            s = htmlDDs.InnerHtml.Replace("金色财经", "");
            return s;
        }

        /// <summary>
        /// 首页右侧的折线图
        /// </summary>
        /// <returns></returns>
        public static string loadHomeChat()
        {
            if (xmlDoc == null)
            {
                xmlDoc = new HtmlWeb().Load(urlWWW);
            }
            var coinsTitle = xmlDoc.DocumentNode.SelectSingleNode("//div[@id=\"market_chart\"]");
            var s = coinsTitle.OuterHtml.Replace("http://resource.jinse.com/phenix/img/nobg.png", "");
            return coinsTitle.OuterHtml;
        }


        #endregion


    }
}