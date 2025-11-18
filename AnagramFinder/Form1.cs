/*
 * Matthew Foley
 * CST-201-O500
 * November 2025
 * Activity 1
 */
namespace AnagramFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblErrorWordOne.Visible = false;
            lblErrorWordTwo.Visible = false;
            lblAnswer.Visible = false;
        }

        private void WordOneLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtWordOne.Text))
            {
                lblErrorWordOne.Visible = false;
            }
            else
            {
                lblErrorWordOne.Visible = true;
            }
        }

        private void WordTwoLeeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtWordTwo.Text))
            {
                lblErrorWordTwo.Visible = false;
            }
            else
            {
                lblErrorWordTwo.Visible = true;
            }
        }

        private void CheckWordsButton(object sender, EventArgs e)
        {
            if (lblErrorWordOne.Visible == true || lblErrorWordTwo.Visible == true)
            {

            }
            else if(string.IsNullOrWhiteSpace(txtWordOne.Text) || string.IsNullOrWhiteSpace(txtWordTwo.Text))
            {
                if (string.IsNullOrWhiteSpace(txtWordOne.Text))
                {
                    lblErrorWordOne.Visible = true;
                }
                if (string.IsNullOrWhiteSpace(txtWordTwo.Text))
                {
                    lblErrorWordTwo.Visible = true;
                }
            }
            else
            {
                string wordOne = txtWordOne.Text;
                string wordTwo = txtWordTwo.Text;
                List<char> listOne=wordOne.ToList();
                List<char> listTwo = wordTwo.ToList();
                if(listOne.Count != listTwo.Count)
                {
                    lblAnswer.Text = "The Two words " + wordOne.ToUpper() + " and " + wordTwo.ToUpper() + " Are NOT Anagrams";
                    lblAnswer.Visible = true;
                }
                else
                {
                    for (int i = 0; i < listOne.Count; i++)
                    {
                        for(int j = 0; j< listTwo.Count; j++)
                        {
                            if (listOne[i] == listTwo[j])
                            {
                                listTwo.Remove(listTwo[j]);
                                continue;
                            }
                        }
                    }
                    /*
                    foreach(char ch in listOne)
                    {
                        foreach (char ch2 in listTwo)
                        {
                            if (ch == ch2)
                            {
                                listTwo.Remove(ch);
                                continue;
                            }
                        }
                    }
                    */
                    if (listTwo.Count == 0)
                    {
                        lblAnswer.Text = "The Two Words " + wordOne.ToUpper() + " And " + wordTwo.ToUpper() + " Are INDEED Anagrams";
                        lblAnswer.Visible = true;
                    }
                    else
                    {
                        lblAnswer.Text = "The Two words " + wordOne.ToUpper() + " and " + wordTwo.ToUpper() + " Are NOT Anagrams";
                        lblAnswer.Visible = true;
                    }
                }
                txtWordOne.Clear();
                txtWordTwo.Clear();
            }
        }
    }
}
