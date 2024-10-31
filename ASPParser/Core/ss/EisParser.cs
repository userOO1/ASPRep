﻿using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using AngleSharp.Html.Dom;
using AngleSharp.Text;

namespace Parser.Core.ss
{
    
    class HabraParser : Order
    {
        
        public List <Order> Parse(IHtmlDocument document)
        {

            List<Order> list = new List<Order>();
            var itemsPrice = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("price-block__value"));
            var itemsFz= document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("col-9 p-0 registry-entry__header-top__title text-truncate"));
            var itemsObject = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("registry-entry__body-value"));
            var itemsCustomer = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("registry-entry__body-href"));
            var itemsNumber = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("registry-entry__header-mid__number"));
            
            for (int i = 0; i < itemsFz.Count();i++)
            {
                byte[] utf8BytesIP = Encoding.UTF8.GetBytes(itemsPrice.ElementAt(i).TextContent.Trim());
                var EncodingIP = Encoding.UTF8.GetString(utf8BytesIP);

                list[i].ItemsNumber = itemsNumber.ElementAt(i).TextContent.Trim();
                list[i].ItemsObject = itemsObject.ElementAt(i).TextContent.Trim();
                list[i].ItemsPrice = EncodingIP;
                list[i].ItemsFz = itemsFz.ElementAt(i).TextContent.Trim();
                list[i].ItemsCustomer = itemsCustomer.ElementAt(i).TextContent.Trim();
                //list.Add(itemsNumber.ElementAt(i).TextContent.Trim());
                //list.Add(itemsObject.ElementAt(i).TextContent.Trim());

                //list.Add(EncodingIP);
                //list.Add(itemsFz.ElementAt(i).TextContent.Trim());
                //list.Add(itemsCustomer.ElementAt(i).TextContent.Trim());
                //list.Add("-------------------------------------");

            }

            // return list.ToArray();
            return list ;
        }

    }
}
