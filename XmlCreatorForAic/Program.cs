//Johannes Ramsebner, 26.05.2018
//lun.3@ki.ooelfv.at
//
//Program to Parse the next Google Calendar Events
//to the AIC (Alarm Info Center) XML-File
//
//Make a folder were the AIC get the xml File.
//In that folder save the 'Input.xml' with the pattern
//In a subfolder are the files of that program
//Also on the subfolder the 'client_secret.json' from google api is required

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlCreatorForAic
{
    class Program
    {
        static void Main(string[] args)
        {
            int defaultVal = 5;
            int countEvents = defaultVal;
            if (args.Count() > 0)
            {
                if (args.Count() == 1)
                {
                    try
                    {
                        countEvents = Int32.Parse(args.FirstOrDefault().ToString());
                        if (countEvents < 1)
                        {
                            Console.WriteLine("Parameter has to be > 0! Value is set to " + defaultVal);
                            countEvents = defaultVal;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Parameter has to be a integer-value!");
                        Console.Read();
                        return;
                    }

                }
                else
                {
                    Console.WriteLine("False amount of parameters!" + Environment.NewLine + "Usage: XmlCreatorForAic [<numberOfNextEvents>]");
                    Console.Read();
                    return;
                }
            }

            Console.WriteLine("Begin...");
            try
            {
                //get xml file
                XmlDocument doc = new XmlDocument();
                doc.Load("../Input.xml");

                var nodes = doc.GetElementsByTagName("InfoCenter");
                IList<string> eventsAsString = DateStringBuilder.getDateStrings(countEvents);
                XmlElement page = doc.CreateElement("Page");
                page.SetAttribute("Type", "Default");
                XmlElement title = doc.CreateElement("Title");
                title.AppendChild(doc.CreateTextNode("Kommende Termine"));
                page.AppendChild(title);
                XmlElement text = doc.CreateElement("Text");
                text.SetAttribute("UseMaxTextSize", "true");
                text.SetAttribute("LeftAligned", "true");
                foreach (string dateEvent in eventsAsString)
                {
                    XmlElement textline = doc.CreateElement("TextLine");
                    textline.AppendChild(doc.CreateTextNode(dateEvent));
                    text.AppendChild(textline);
                }
                page.AppendChild(text);
                nodes.Item(0).AppendChild(page);
                doc.Save("../Output.xml");
                Console.WriteLine("File 'Output.xml' was written.");
                Console.WriteLine("Finished!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception!" + Environment.NewLine + ex.Message);
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.StackTrace);
                }
                
            }
            finally
            {
                //Console.Read();
            }

        }
    }
}
