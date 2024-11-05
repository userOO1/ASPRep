using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core.ss
{

    class EisSettings 
    {           
        public string Prefix { get; set; } = "pageNumber={CurrentId}";
        
    }
    public class Order
    {
        public string ItemsNumber { get; set; } = string.Empty;
        public string ItemsObject { get; set; } = string.Empty;
        public string ItemsPrice { get; set; } = string.Empty;
        public string ItemsFz { get; set; } = string.Empty;
        public string ItemsCustomer { get; set; } = string.Empty;


    }
    
}
