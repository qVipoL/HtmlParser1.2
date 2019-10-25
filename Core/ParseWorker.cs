using AngleSharp.Html.Parser;
using HtmlParser.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlParser.Core
{
    class ParseWorker<T> where T : class
    {
        IParser<T> MyParser;
        IParserSettings parserSettings;

        HtmlLoader loader;

        bool isWorking;

        public IParser<T> Parser
        {
            get
            {
                return MyParser;
            }
            set
            {
                MyParser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsWorking
        {
            get
            {
                return isWorking;
            }
            set
            {
                isWorking = value;
            }
        }

        public event Action<object> OnCompleted;

        public ParseWorker(IParser<T> parser)
        {
            this.MyParser = parser;
        }

        public ParseWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            isWorking = true;
            Worker();
        }

        public void Stop()
        {
            isWorking = false;
        }

        private async void Worker()
        {
            var source = await loader.GetSourcePage();

            var domParser = new AngleSharp.Html.Parser.HtmlParser();

            var htmlDocument = await domParser.ParseDocumentAsync(source);

            var result = MyParser.Parse(htmlDocument);

            OnCompleted?.Invoke(this);
            isWorking = false;
        }
    }
}
