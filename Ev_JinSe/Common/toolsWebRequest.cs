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
        static HtmlAgilityPack.HtmlDocument xmlDoc;
        public static string loadNewsStr(string html)
        {

            if (xmlDoc == null)
            {
                xmlDoc = new HtmlWeb().Load(html);
            }

            //获取文章DIV模块
            var bugSum = xmlDoc.DocumentNode.SelectSingleNode("//div[@id='topic_list']/div[@id='main1']");
            //获取文章列表模块
            //HtmlNode idmain1 = bugSum.SelectSingleNode("//div[@id='main1']");
            var hrefList = bugSum.SelectNodes("//ol[@class='list clearfix']");
            for (int j = 1; j <= hrefList.Count; j++)
            {
                var hrefAList = hrefList[j].SelectSingleNode("//ol[@class='list clearfix']/a[" + j + "]");

                if (j == 1 || j == 2)
                {
                    //前两个截取跳转路径字符串
                    var strHref = hrefAList.Attributes["href"].Value;
                    string hhs = strHref.Substring(strHref.LastIndexOf('/') + 1);
                    hrefList[j].SelectSingleNode("//ol[@class='list clearfix']/a[" + j + "]").SetAttributeValue("href", "/Article/Index?hs=" + hhs);
                }
                else
                {
                    //其他连接直接删除点击事件
                    hrefList[j].SelectSingleNode("//ol[@class='list clearfix']/a[" + j + "]").SetAttributeValue("href", "javascript:void(0);");
                }
            }


            return "";// bugSum.InnerHtml;
        }



    }
}