using HtmlParser.Core;
using HtmlParser.Core.HtmlParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HtmlParser
{
    public partial class ParserForm : Form
    {
        ParseWorker<string[]> parser;

        public ParserForm()
        {
            InitializeComponent();
            parser = new ParseWorker<string[]>(new HtmlParser.Core.HtmlParser.HtmlParser());
            parser.OnCompleted += Parser_OnCompleted;
            MessageBox.Show("Note: No Validation for url and queries yet");
        }

        private void Parser_OnCompleted(object arg1, string[] arg2)
        {
            ParsedInfoList.Items.AddRange(arg2);
            MessageBox.Show("Parsing Finished");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            parser.Settings = new HtmlParserSettings(UrlBox.Text);
            parser.Query = QueryBox.Text;
            parser.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ParsedInfoList.Items.Clear();
        }
    }
}
