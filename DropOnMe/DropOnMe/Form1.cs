using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DropOnMe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                                                                               

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
           
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            AlustaDropCallbackit(sender,  e);

        }
        private void AlustaDropCallbackit(object sender, EventArgs e)
        {
            textBox2.DragEnter += new DragEventHandler(miunDragEnterHandler);
         //   textBox2.MouseDown += new MouseEventHandler(textBox1_MouseDown);
            textBox2.DragDrop += new DragEventHandler(miunDropHandler);

           
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }
        //*************************************
        private void miunDropHandler(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);
            tb.SelectAll();

        }
        //*************************************
        private void miunDragEnterHandler(object sender, DragEventArgs e)
        {
            Type tyyppi1 = sender.GetType();
            string [] formats = e.Data.GetFormats();
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
          }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void playlistbutton_Click(object sender, EventArgs e)
        {
            string urlSoittolista = "\""+textBox2.Text+"\"";
            System.Environment.CurrentDirectory = @".\";
            //System.Diagnostics.Process.Start("run1_setenv.bat", urlSoittolista);
            //urlSoittolista = urlSoittolista.Replace("&", "^&");
            ExecuteCommand("setenv_und_run.bat "+ urlSoittolista);

        }
       private void ExecuteCommand(string command)
        {
        
            var processInfo = new ProcessStartInfo("cmd.exe", "/k " + command);
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            
            //processInfo.RedirectStandardError = true;
            //processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);
            Console.WriteLine("qwerqwrq");
            /*
            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();


            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();
            */
            //process.WaitForExit();

           // Console.WriteLine("ExitCode: {0}", process.ExitCode);
           // process.Close();
        }
    }
}
