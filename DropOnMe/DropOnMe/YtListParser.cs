using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DropOnMe
{

    class YtListParser
    {

        static TextBox logBox;
        Process thisProcess;//cmd.exe
        string urlPlaylist;
        string fileInfosJsonFileName = "rawYtFilesInfos.json";
        public YtListParser(Process process, TextBox textBox,string urlList) {
            thisProcess = process;
            logBox = textBox;
            urlPlaylist = urlList;
            logBox.Text = "";
        }
        public void writeCommand(string command)
        {
            
            thisProcess.StandardInput.WriteLine(command);
            //thisProcess.StandardInput.Flush();
        }
        public void writeFormatsToTextfile()
        {
            string conmsg = "Console Write!";
            //Console.SetWindowSize(180, 60);
            Console.WriteLine(conmsg);

            
            writeCommand( "cd youtube-dl");
            writeCommand( "dir");
            writeCommand( "yt-dlp -j --flat-playlist " + urlPlaylist + ">" + fileInfosJsonFileName);
            


            string fileInfosJsonString = File.ReadAllText("./youtube-dl/"+fileInfosJsonFileName);



            JsonTextReader reader = new JsonTextReader(new StringReader(fileInfosJsonString));
                           reader.SupportMultipleContent = true;

                var serializer = new Newtonsoft.Json.JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        YtFileInfo p = serializer.Deserialize<YtFileInfo>(reader);
                        string fileUrl = p.original_url;
                    Console.WriteLine("osoite: " + fileUrl);
                    //writeCommand("yt-dlp -F " + fileUrl + ">" + "currentFormats.txt");
                    //writeCommand("echo youtubevideon osoite:" + fileUrl);
                    //writeCommand("echo otsikko:" + p.title);
                    Console.WriteLine("otsikko: " + p.title);
                    writeCommand("yt-dlp -F " + fileUrl );
                    //string formatInfo = File.ReadAllText("./youtube-dl/" + "currentFormats.txt");
                    logBox.AppendText(fileUrl+ Environment.NewLine);
                    //logBox.AppendText(formatInfo + Environment.NewLine);
                }
                }
            
            writeCommand("cd..");//done with cmd
            //YtFileInfo  fileInfo = JsonSerializer.Deserialize<YtFileInfo>(jsonString)!;

            //TODO
            //READ i.e parse here as native json.net!
            //next uses third party commandline tool to parse
            /*
            writeCommand("yt-dlp -j --flat-playlist " + urlPlaylist + " | jq -r " + ".url > listUris.log");
            */


            //            cmd.StartInfo.RedirectStandardInput = false;
            /*
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            */


            //  tb.Text = cmd.StandardOutput.ReadToEnd();
        }
    }
}
