using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WordCounterLibrary;

namespace WordCounterWebUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int topRange;

            if (int.TryParse(TextBox2.Text, out topRange))
            {
                ViewTableWords(1, topRange);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int topRange;

            if (int.TryParse(TextBox2.Text, out topRange))
            {
                ViewTableWords(2, topRange);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int topRange;

            if (int.TryParse(TextBox2.Text, out topRange))
            {
                ViewTableWords(3, topRange);
            }
            
        }

        private void ViewTableWords(int quantilityEntry, int top)
        {
            try
            {
                TextParse _inputText = new TextParse(TextBox1.Text);
                WordAnalysis _wordStatistic = new WordAnalysis(_inputText, quantilityEntry);

                Label5.Text = _wordStatistic.CountPhrase.ToString();

                GridView1.DataSource = _wordStatistic.GetTopWordPharse(top);
                GridView1.DataBind();
                
            }
            catch (ArgumentNullException)
            {
                Label3.Text = "Enter text please";
            }
            catch (ArgumentOutOfRangeException) 
            {
                Label3.Text = "Enter text please";
            }

        }
    }
}