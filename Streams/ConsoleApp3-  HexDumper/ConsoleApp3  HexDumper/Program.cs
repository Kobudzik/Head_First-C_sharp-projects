using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3__HexDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1) //jesli damy inna ilosc argumentow niz 1
            { 
                Console.Error.WriteLine("usage: HexDumper file-to-dump");
                System.Environment.Exit(1);
            }


            if (!File.Exists(args[0]))//jesli podbany plik nie istnieje
            { 
                Console.Error.WriteLine("File does not exist: {0}", args[0]); 
                System.Environment.Exit(2);
            }

            using (Stream input = File.OpenRead(args[0]))
            {
                int position = 0;
                byte[] buffer = new byte[16]; //tablica bajtow

                while (position < input.Length)//dopóki pozycja jest w granicach pliku
                {
                    int charactersRead = input.Read(buffer, 0, buffer.Length);//odczytuje kolejne 16 bajtow i zwraca ilosc do characters Read

                    if (charactersRead > 0)//jesli jakies bajty odczytal
                    {
                        Console.Write("{0}: ", String.Format("{0:x4}", position));//wyswietla nr linijki

                        position += charactersRead;//przesuwa pozycje dalej

                        for (int i = 0; i < 16; i++)//dla kazdego z bajtow (max 16)
                        {
                            if (i < charactersRead)//ale nie wiecej niz odczytano
                            {
                                string hex = String.Format("{0:x2}", (byte)buffer[i]);//wyswietla bajt
                                Console.Write(hex + " ");
                            }
                            else 
                                Console.Write("   ");//jesli odczytano wiecej niz 16 to spacje

                            if (i == 7)//w połowie dodaje pauzy
                                Console.Write("-- ");

                            if (buffer[i] < 32 || buffer[i] > 250)
                            {
                                buffer[i] = (byte)'.'; 
                            }
                        }
                        string bufferContents = Encoding.UTF8.GetString(buffer);//convert a byte array to a string
                        Console.WriteLine("   " + bufferContents);
                    }
                }
            }
        }
    }
}
