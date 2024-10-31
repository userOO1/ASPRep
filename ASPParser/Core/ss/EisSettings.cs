using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.ss
{

    class HabraSettings 
    {           
        public string Prefix { get; set; } = "pageNumber={CurrentId}";
        
    }
    public class Order
    {
        public string ItemsNumber { get; set; } = "";
        public string ItemsObject { get; set; } = "";
        public string ItemsPrice { get; set; } = "";
        public string ItemsFz { get; set; } = "";
        public string ItemsCustomer { get; set; } = "";


    }
    
}
