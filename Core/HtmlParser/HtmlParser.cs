﻿using AngleSharp.Html.Dom;
using HtmlParser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Core.HtmlParser
{
    class HtmlParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document, string query)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll(query).Where(item => item.TextContent != null);

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
