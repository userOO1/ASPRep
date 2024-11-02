using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using AngleSharp.Html.Dom;
using AngleSharp.Text;

namespace Parser.Core.ss
{
    
    class HabraParser : IParser<List <Order>>
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
                List<Order> l = new List<Order>();

                byte[] utf8BytesIP = Encoding.UTF8.GetBytes(itemsPrice.ElementAt(i).TextContent.Trim());
                var EncodingIP = Encoding.UTF8.GetString(utf8BytesIP);

                
                var ItemsNumber = itemsNumber.ElementAt(i).TextContent.Trim();
                string ItemsObject= "";
                if (itemsObject != null && itemsObject.Count() > 0)
                {
                    if (i >= 0 && i < itemsObject.Count())
                    {
                        ItemsObject = itemsObject.ElementAt(i).TextContent.Trim();
                    }
                }

                var ItemsPrice = EncodingIP;
                var ItemsFz = itemsFz.ElementAt(i).TextContent.Trim();
                var ItemsCustomer = itemsCustomer.ElementAt(i).TextContent.Trim();

                list.Add(new Order() {ItemsNumber=ItemsNumber, ItemsObject = ItemsObject, ItemsPrice = ItemsPrice , ItemsFz = ItemsFz , ItemsCustomer = ItemsCustomer });                

            }

            // return list.ToArray();
            return list ;
        }

    }
}
