using HtmlParser.Core;
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
        }

        private void Parser_OnCompleted(object obj)
        {
            throw new NotImplementedException();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void StopButton_Click(object sender, EventArgs e)
        {

        }
    }
}
