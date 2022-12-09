using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace T_Cubed
{
    public partial class Form1 : Form
    {

        string selectedFile = "File 1";
        bool testRunning = false;
        char[] testArray;
        int arrayVal;
        public Form1()
        {
            InitializeComponent();

            this.newToolStripMenuItem.Click += new EventHandler(NewToolStripMenuItem__Click);
            this.openToolStripMenuItem.Click += new EventHandler(OpenToolStripMenuItem__Click);
            this.saveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem__Click);
            this.exitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem__Click);

            this.copyToolStripMenuItem.Click += new EventHandler(CopyToolStripMenuItem__Click);
            this.cutToolStripMenuItem.Click += new EventHandler(CutToolStripMenuItem__Click);
            this.pasteToolStripMenuItem.Click += new EventHandler(PasteToolStripMenuItem__Click);

            this.boldToolStripMenuItem.Click += new EventHandler(BoldToolStripMenuItem__Click);
            this.italicsToolStripMenuItem.Click += new EventHandler(ItalicsToolStripMenuItem__Click);
            this.underlineToolStripMenuItem.Click += new EventHandler(UnderlineToolStripMenuItem__Click);

            this.mSSansSerifToolStripMenuItem.Click += new EventHandler(MSSansSerifToolStripMenuItem__Click);
            this.timesNewRomanToolStripMenuItem.Click += new EventHandler(TimesNewRomanToolStripMenuItem__Click);

            this.testToolStripButton.Click += new EventHandler(TestToolStripButton__Click);

            this.toolStrip.ItemClicked += new ToolStripItemClickedEventHandler(ToolStrip__ItemClicked);

            this.richTextBox.SelectionChanged += new EventHandler(RichTextBox__SelectionChanged);

            this.richTextBox.KeyPress += new KeyPressEventHandler(RichTextBox__KeyPress);

            this.countdownLabel.Visible = false;

            this.timer.Tick += new EventHandler(Timer__Tick);

            test1ToolStripMenuItem.Click += new EventHandler(Test1ToolStripMenuItem__Click);
            test2ToolStripMenuItem.Click += new EventHandler(Test2ToolStripMenuItem__Click);
            test3ToolStripMenuItem.Click += new EventHandler(Test3ToolStripMenuItem__Click);
            test4ToolStripMenuItem.Click += new EventHandler(Test4ToolStripMenuItem__Click);

            this.Text = "MyEditor";

            TestSelector();
        }

        private void NewToolStripMenuItem__Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            this.Text = "MyEditor";
        }

        private void TestToolStripButton__Click(object sender, EventArgs e)
        {
            this.timer.Interval = 500;
            this.toolStripProgressBar1.Value = 60;
            this.countdownLabel.Text = "3";
            this.countdownLabel.Visible = true;
            this.richTextBox.Visible = false;
            testRunning = true;

            Form2 form2 = new Form2(selectedFile);
            form2.Show();

            for(int i = 3; i > 0; i--)
            {
                this.countdownLabel.Text = i.ToString();
                this.Refresh();
                Thread.Sleep(1000);
            }

            this.countdownLabel.Visible = false;
            this.richTextBox.Visible = true;

            this.timer.Start();
        }

        private void Timer__Tick(object sender, EventArgs e)
        {
            --this.toolStripProgressBar1.Value;

            if (this.toolStripProgressBar1.Value == 0)
            {
                this.timer.Stop();

                string performance = "Congratulations!  You typed " + Math.Round(this.richTextBox.TextLength/ 30.0, 2) + " letters per second!";
                MessageBox.Show(performance);
                Application.OpenForms["Form2"].Close();
            }
        }

        private void BoldToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Bold;
            Font selectionFont = null;

            selectionFont = richTextBox.SelectionFont;
            if(selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            SetSelectionFont(fontStyle, !selectionFont.Bold);
        }

        private void ItalicsToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Italic;
            Font selectionFont = null;

            selectionFont = richTextBox.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            SetSelectionFont(fontStyle, !selectionFont.Italic);
        }

        private void UnderlineToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Underline;
            Font selectionFont = null;

            selectionFont = richTextBox.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            SetSelectionFont(fontStyle, !selectionFont.Underline);
        }

        private void MSSansSerifToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Font newFont = new Font("MS Sans Serif", richTextBox.SelectionFont.Size, richTextBox.SelectionFont.Style);

            richTextBox.SelectionFont = newFont;
        }

        private void TimesNewRomanToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Font newFont = new Font("Times New Roman", richTextBox.SelectionFont.Size, richTextBox.SelectionFont.Style);

            richTextBox.SelectionFont = newFont;
        }

        private void RichTextBox__SelectionChanged(object sender, EventArgs e)
        {
            if(this.richTextBox.SelectionFont != null)
            {
                this.boldToolStripButton.Checked = richTextBox.SelectionFont.Bold;
                this.italicsToolStripButton.Checked = richTextBox.SelectionFont.Italic;
                this.underlineToolStripButton.Checked = richTextBox.SelectionFont.Underline;
            }

            this.colorToolStripButton.BackColor = richTextBox.SelectionColor;
        }

        private void OpenToolStripMenuItem__Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxStreamType richTextBoxStreamType = RichTextBoxStreamType.RichText;
                if (openFileDialog.FileName.ToLower().Contains(".txt"))
                {
                    richTextBoxStreamType = RichTextBoxStreamType.PlainText;
                }
                richTextBox.LoadFile(openFileDialog.FileName, richTextBoxStreamType);

                this.Text = "MyEditor (" + openFileDialog.FileName + ")";
            }
        }

        private void SaveToolStripMenuItem__Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = openFileDialog.FileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxStreamType richTextBoxStreamType = RichTextBoxStreamType.RichText;
                if (saveFileDialog.FileName.ToLower().Contains(".txt"))
                {
                    richTextBoxStreamType = RichTextBoxStreamType.PlainText;
                }
                richTextBox.SaveFile(saveFileDialog.FileName, richTextBoxStreamType);

                this.Text = "MyEditor (" + saveFileDialog.FileName + ")";
            }
        }

        private void ExitToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CopyToolStripMenuItem__Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void CutToolStripMenuItem__Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void PasteToolStripMenuItem__Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void ToolStrip__ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            FontStyle fontStyle = FontStyle.Regular;

            ToolStripButton toolStripButton = null;

            if(e.ClickedItem == this.boldToolStripButton)
            {
                fontStyle = FontStyle.Bold;
                toolStripButton = this.boldToolStripButton;
            }
            else if (e.ClickedItem == this.italicsToolStripButton)
            {
                fontStyle = FontStyle.Italic;
                toolStripButton = this.italicsToolStripButton;
            }
            else if (e.ClickedItem == this.underlineToolStripButton)
            {
                fontStyle = FontStyle.Underline;
                toolStripButton = this.underlineToolStripButton;
            }
            else if (e.ClickedItem == this.colorToolStripButton)
            {
                if(colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SelectionColor = colorDialog.Color;
                    colorToolStripButton.BackColor = colorDialog.Color;
                }
            }

            if (fontStyle != FontStyle.Regular)
            {
                toolStripButton.Checked = !toolStripButton.Checked;

                SetSelectionFont(fontStyle, toolStripButton.Checked);
            }
        }

        private void SetSelectionFont(FontStyle fontStyle, bool bSet)
        {
            Font newFont = null;
            Font selectionFont = null;

            selectionFont = richTextBox.SelectionFont;
            if(selectionFont == null)
            {
                selectionFont = richTextBox.Font;
            }

            if (bSet)
            {
                newFont = new Font(selectionFont, selectionFont.Style | fontStyle);
            }
            else
            {
                newFont = new Font(selectionFont, selectionFont.Style & ~fontStyle);
            }

            this.richTextBox.SelectionFont = newFont;
        }

        private void Test1ToolStripMenuItem__Click(object sender, EventArgs e)
        {
            selectedFile = "File 1";
            TestSelector();
        }

        private void Test2ToolStripMenuItem__Click(object sender, EventArgs e)
        {
            selectedFile = "File 2";
            TestSelector();
        }

        private void Test3ToolStripMenuItem__Click(object sender, EventArgs e)
        {
            selectedFile = "File 3";
            TestSelector();
        }

        private void Test4ToolStripMenuItem__Click(object sender, EventArgs e)
        {
            selectedFile = "File 4";
            TestSelector();
        }

        private void RichTextBox__KeyPress(object sender, KeyPressEventArgs e)
        {
            if(testRunning == true)
            {
                if(e.KeyChar != testArray[arrayVal])
                {
                    e.Handled = true;
                    arrayVal+=1;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else { }
        }



        private void TestSelector()
        {
            string test;

            arrayVal = 0;

            if(selectedFile == "File 1")
            {
                test = "Engineers, as practitioners of engineering, are people who invent, design, analyze, build, and test machines, systems, structures and materials to fulfill objectives and requirements while considering the limitations imposed by practicality, regulation, safety, and cost. The work of engineers forms the link between scientific discoveries and their subsequent applications to human and business needs and quality of life.";
                testArray = new char[test.Length];
            }
            else if(selectedFile == "File 2")
            {
                test = "There are many idiosyncratic typing styles in between novice-style \"hunt and peck\" and touch typing. For example, many \"hunt and peck\" typists have the keyboard layout memorized and are able to type while focusing their gaze on the screen. Some use just two fingers, while others use 3-6 fingers. Some use their fingers very consistently, with the same finger being used to type the same character every time, while others vary the way they use their fingers.";
                testArray = new char[test.Length];
            }
            else if(selectedFile == "File 3")
            {
                test = "A late 20th century trend in typing, primarily used with devices with small keyboards (such as PDAs and Smartphones), is thumbing or thumb typing. This can be accomplished using one or both thumbs. Similar to desktop keyboards and input devices, if a user overuses keys which need hard presses and/or have small and unergonomic layouts, it could cause thumb tendonitis or other repetitive strain injury. (Wikipedia)";
                testArray = new char[test.Length];
            }
            else
            {
                test = "A freelancer or freelance worker, is a term commonly used for a person who is self-employed and is not necessarily committed to a particular employer long-term. Freelance workers are sometimes represented by a company or a temporary agency that resells freelance labor to clients; others work independently or use professional associations or websites to get work. While the term \"independent contractor\" would be used in a higher register of English to designate the tax and employment classes of this type of worker, the term freelancing is most common in culture and creative industries and this term specifically motions to participation therein. Fields, professions, and industries where freelancing is predominant include: music, writing, acting, computer programming, web design, graphic design, translating and illustrating, film and video production and other forms of piece work which some cultural theorists consider as central to the cognitive-cultural economy.";
                testArray = new char[test.Length];
            }

            for(int i = 0; i < test.Length; i++)
            {
                testArray[i] = test[i];
            }
        }
    }
}
