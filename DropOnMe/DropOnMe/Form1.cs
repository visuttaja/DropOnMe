﻿using System.Runtime.InteropServices;
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
using System.IO;
using System.Threading;

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
            
            //AttachConsole(ATTACH_PARENT_PROCESS);

        }
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
                       
        private void AlustaDropCallbackit(object sender, EventArgs e)
        {
            textBox_playlistaddress.DragEnter += new DragEventHandler(miunDragEnterHandler);
         //   textBox2.MouseDown += new MouseEventHandler(textBox1_MouseDown);
            textBox_playlistaddress.DragDrop += new DragEventHandler(miunDropHandler);           
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
        //**********************
        static StringBuilder output = new StringBuilder();
        void SortOutputHandler(object sendingProcess,
           DataReceivedEventArgs outLine)
        {
            int numOutputLines=0;  
            
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                numOutputLines++;

                // Add the text to the collected output.
                output.Append(Environment.NewLine +
                    $"[{numOutputLines}] - {outLine.Data}");
                

            }
            logText(output.ToString());

            //Console.WriteLine(output.ToString());
        }
 
        //************************
        private void writeCommand(Process ps,string command)
        {
            ps.StandardInput.WriteLine(command);
            ps.StandardInput.Flush();
        }                 
        //**************************
        private void playlistbutton_Click(object sender, EventArgs e)
        {
                                            
            string urlSoittolista = "\"" + textBox_playlistaddress.Text + "\"";
            System.Environment.CurrentDirectory = @".\";
            //System.Diagnostics.Process.Start("run1_setenv.bat", urlSoittolista);
            //urlSoittolista = urlSoittolista.Replace("&", "^&");

            var startInfo = new ProcessStartInfo();
            
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = @".";

            startInfo.FileName = @"C:\Windows\System32\cmd.exe";
            startInfo.Verb = "runas";
            
            startInfo.Arguments = "K";
            startInfo.RedirectStandardInput = true;

            Process process = Process.Start(startInfo);
            //YtListParser parser = new YtListParser(process, this.textBox_logbox,urlSoittolista);

            //parser.writeCommand("time /t");
            //parser.writeFormatsToTextfile();
            //            startInfo.RedirectStandardOutput = true;                        
            downloadPlaylist(process,urlSoittolista);

        }                             
        //****************************************
        private void downloadPlaylist(Process cmd,string urlPlaylist)

        {
            
            StreamWriter inputStreamWriter = cmd.StandardInput;
                        
            String firstBatch = "call setenv_und_run.bat " + urlPlaylist;
            writeCommand(cmd, firstBatch);
            //startInfo.RedirectStandardInput = false;

            //this.textBox_logbox.Text = command;

            /*
            process.OutputDataReceived += SortOutputHandler;                   
            process.BeginOutputReadLine();
            */
            //textBox_logbox.Text = output.ToString();                        
            // Console.WriteLine("ExitCode: {0}", process.ExitCode);

        }
        
        //********************************************
        delegate void SetTextCallback(string text);

        public  void logText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox_logbox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(logText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox_logbox.Text = text;
            }
        }
//*****************************************************
        private void ExplorerButton_Click(object sender, EventArgs e)
        {

            Process.Start(@".\output\playlists");
        }
        
        //****************************************
        private void formatsButton_Click(object sender, EventArgs e)
        {

            string urlSoittolista = "\"" + textBox_playlistaddress.Text + "\"";
            System.Environment.CurrentDirectory = @".\";
            //System.Diagnostics.Process.Start("run1_setenv.bat", urlSoittolista);
            //urlSoittolista = urlSoittolista.Replace("&", "^&");

            var startInfo = new ProcessStartInfo();

            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = @".";

            startInfo.FileName = @"C:\Windows\System32\cmd.exe";
            startInfo.Verb = "runas";

            startInfo.Arguments = "K";
            startInfo.RedirectStandardInput = true;

            Process process = Process.Start(startInfo);
            
            YtListParser parser = new YtListParser(process, this.textBox_logbox, urlSoittolista);

            parser.writeCommand("time /t");
            parser.writeFormatsToTextfile();
            //            startInfo.RedirectStandardOutput = true;                        
            
        }
    }
}
