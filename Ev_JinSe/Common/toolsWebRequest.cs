using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using HtmlAgilityPack;

namespace Ev_JinSe
{
    public static class toolsWebRequest
    {
        static HtmlAgilityPack.HtmlDocument xmlDoc;//首页
        static string urlWWW = "http://www.jinse.com";


        //新闻文章详情
        public static string loadNewsDetailStr(string htmlUrl) {
            string urlStr = urlWWW + htmlUrl;
            HtmlDocument xmldd = new HtmlWeb().Load(urlStr);
            var htmlDDs = xmldd.DocumentNode.SelectSingleNode("//div[@class=\"wrap marginb clearfix\"]");
            var htmlAlist = htmlDDs.SelectNodes("//a");
            for (int i = 0; i < htmlAlist.Count(); i++)
            {
                 var htmlHref = htmlAlist[i].Attributes["href"];
                if (htmlHref == null)
                {
                    continue;
                }
                string strHrefValue = htmlHref.Value;
                var strLast = strHrefValue.Substring(strHrefValue.Length - 4, 4);
                string strReplace = string.Empty;
                if (strLast.Equals("html"))
                {
                    string hU = strHrefValue.Replace(urlWWW, "");
                    hU = HttpUtility.UrlEncode(hU);
                    strReplace = "/Article/Index?hs=" + hU;
                    htmlAlist[i].SetAttributeValue("href", strReplace);
                }
                else {
                    strReplace = "javascript:void(0);";
                    htmlAlist[i].SetAttributeValue("href", strReplace);
                }
            }


            return htmlDDs.OuterHtml;
        }


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
            var htmlDDs = xmlDoc.DocumentNode.SelectSingleNode("//div[@id='topic_list']");
            var bugSum = htmlDDs.SelectSingleNode("//div[@id='main1']");
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
                if (strHrefValue.Length<20)
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
                else {
                    strReplace = "javascript:void(0);";
                    hrefList[j].SetAttributeValue("href", strReplace);
                }
                //htmlDDs.InnerHtml.Replace(strHrefValue, strReplace);
                htmlDDs.SelectSingleNode("//a[@href=\"" + strHrefValue + "\"]").SetAttributeValue("href", strReplace);
               
            }
            return htmlDDs.InnerHtml;
        }



    }
}