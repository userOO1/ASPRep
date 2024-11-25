using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using Parser.Core.ss;

namespace Parser.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
        
    }
}
