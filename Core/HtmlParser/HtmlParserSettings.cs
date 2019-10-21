using HtmlParser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Core.HtmlParser
{
    class HtmlParserSettings : IParserSettings
    {
        public string Url { get; set; }
        public string Query { get; set; }

        public HtmlParserSettings(string url, string query)
        {
            this.Url = url;
            this.Query = query;
        }
    }
}
