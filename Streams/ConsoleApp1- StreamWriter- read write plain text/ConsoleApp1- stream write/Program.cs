using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1__stream_write
{
    class Program
    {
        static void Main(string[] args)


        {
            //przpisanie pelnej scieżki do readera1
            //zapisuje na pulpicie
            StreamWriter writer1 = new StreamWriter(@"C:\USERS\KonradRyzen\desktop\toaster oven.txt");

            writer1.WriteLine("How I’ll defeat Captain Amazing");
            writer1.WriteLine("Another genius secret plan by The Swindler");
            writer1.Write("I’ll create an army of clones and ");
            writer1.WriteLine("unleash them upon the citizens of Objectville.");



            string location = "the mall";

            for (int number = 0; number <= 6; number++)
            {
                writer1.WriteLine("Clone #{0} attacks {1}", number, location);
                if (location == "the mall")
                {
                    location = "downtown";
                }
                else
                {
                    location = "the mall";
                }
            }
            writer1.Close();


            

            //ustala folder na moje dokumenty
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //przpisanie pelnej scieżki do readera1
            StreamReader reader1 = new StreamReader(folder + @"\secret_plan.txt");




            //przpisanie pelnej scieżki do writera2
            StreamWriter writer2 = new StreamWriter(folder + @"\emailToCaptainAmazing.txt");

            writer2.WriteLine("To: CaptainAmazing@objectville.net");
            writer2.WriteLine("From: Commissioner@objectville.net");
            writer2.WriteLine("Subject: Can you save the day... again?");            
            writer2.WriteLine();
            writer2.WriteLine("We’ve discovered the Swindler’s plan:");



            //zczytuje cały plik
            while (!reader1.EndOfStream)
            {
                //jedna linia readera1 do zmiennej
                string lineFromThePlan = reader1.ReadLine();
                //writer2 przepisuje linie ze zmiennej do swojego pliku
                writer2.WriteLine("The plan -> " + lineFromThePlan);
            }
           
            writer2.WriteLine(); 
            writer2.WriteLine("Can you help us?");
            writer2.Close();

            reader1.Close();
        }
    }
}
