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
using System.Threading;
using Newtonsoft.Json.Linq;

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
            thisProcess.StandardInput.Flush();
        }
        public void writeFormatsToTextfile()
        {
            string conmsg = "Console Write!";
            //Console.SetWindowSize(180, 60);
            Console.WriteLine(conmsg);

            writeCommand("color 1A");
            writeCommand( "cd youtube-dl");
            writeCommand( "dir");
            writeCommand( "yt-dlp -j --flat-playlist " + urlPlaylist + ">" + fileInfosJsonFileName);



            //string fileInfosJsonString = File.ReadAllText("./youtube-dl/"+fileInfosJsonFileName);
            string fileInfosJsonString = readFileWaitForReady("./youtube-dl/" + fileInfosJsonFileName);


            JsonTextReader nameReader = new JsonTextReader(new StringReader(fileInfosJsonString));
            nameReader.SupportMultipleContent = true;

                var nameSerializer = new Newtonsoft.Json.JsonSerializer();
                while (nameReader.Read())
                {
                    if (nameReader.TokenType == JsonToken.StartObject)
                    {
                        YtFileInfo p = nameSerializer.Deserialize<YtFileInfo>(nameReader);
                        string fileUrl = p.original_url;
                    Console.WriteLine("osoite: " + fileUrl);
                    string dumpFileName = "./dumps/currentDump.txt";
                    string dumpCommand = "call yt-dlp --dump-json " + "\"" + fileUrl + "\"" + ">" + dumpFileName;

                                        writeCommand(dumpCommand);
                    
                    
                    string dumpJsonString = readFileWaitForReady("./youtube-dl/" + dumpFileName);
           
                    
                    JsonTextReader dumpReader = new JsonTextReader(new StringReader(dumpJsonString));
                    var dumpSerializer = new Newtonsoft.Json.JsonSerializer();
                    while (dumpReader.Read())
                    {
                        if (dumpReader.TokenType == JsonToken.StartObject)
                        {
                            
                            dynamic stuff = JObject.Parse(dumpJsonString);
                            string dur1 = stuff.duration_string;
                            
                            YtdlpDump d = dumpSerializer.Deserialize<YtdlpDump>(dumpReader);
                            string dur = d.duration_string;
                            
                            foreach (Format f in d.formats)
                            {
                                prettyPrintFormats(d,f);                                
                            }
                            Console.WriteLine(dur);
                        }
                    }
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
        }
        //***************************
        public string readFileWaitForReady(string fileName) {
            string fileString = null;
            int cnt = 0;
            while (true)
            {
                try
                {
                    fileString = File.ReadAllText(fileName);
                    break;
                }
                catch
                {
                    System.Threading.Thread.Sleep(100);
                    cnt += 1;
                }
            }
            Console.WriteLine("POLLED file ready:" + cnt + " times");
            return fileString;
        }
        //*****************************
        public void prettyPrintFormats(YtdlpDump d,Format f) {

            System.Console.WriteLine(f.format_id);

        }
    }
}
