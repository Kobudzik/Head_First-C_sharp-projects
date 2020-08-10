using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp4_deck_serializable
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

       

        private Deck RandomDeck(int number)
        {
            Deck myDeck = new Deck(new Card[] { });
            
            for (int i = 0; i < number; i++) 
            { 
                myDeck.Add(new Card((Suits)random.Next(4), (Values)random.Next(1, 14)));
            }
            return myDeck;
        }

        private void DealCards(Deck deckToDeal, string title)
        {
            Console.WriteLine(title); 
            
            while (deckToDeal.Count > 0)
            {
                Card nextCard = deckToDeal.Deal(0);
                Console.WriteLine(nextCard.Name);
            } 
            Console.WriteLine("------------------");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deck deckToWrite = RandomDeck(5);
            using(Stream output= File.Create("deck1.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, deckToWrite);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Stream input= File.OpenRead("Deck1.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Deck deckFromFile = (Deck)bf.Deserialize(input);
                DealCards(deckFromFile, "What I read from file");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Stream output = File.Create("Deck2.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();

                for (int i = 1; i <= 5; i++)
                {
                    Deck deckToWrite = RandomDeck(random.Next(1, 10));//tworzy deck losowej wielkosci
                    bf.Serialize(output, deckToWrite);//zapisuje go
                    DealCards(deckToWrite, "Deck #" + i + " written");//wyswietla go
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Stream input = File.OpenRead("Deck2.dat"))//otwiera plik
            {
                BinaryFormatter bf = new BinaryFormatter();

                for (int i = 1; i <= 5; i++)
                {
                    Deck deckToRead = (Deck)bf.Deserialize(input);//zczytuje i dodaje do drugiego decka
                    DealCards(deckToRead, "Deck #" + i + " read");
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(@"inputFile.txt"))
            using (StreamWriter writer = new StreamWriter(@"outputFile.txt", false))
            {
                int position = 0;

                while (!reader.EndOfStream)//jesli są znaki w pliku
                {
                    char[] buffer = new char[16]; //buffer- tablica 16 elementowa znakow
                    int charactersRead = reader.ReadBlock(buffer, 0, 16);//odczytuje nastepne 16 elementow(jesli nie ma 16 to max ile jest)
                    writer.Write("{0}: ", String.Format("{0:x4}", position));//wypisuje pozycje w hex
                    position += charactersRead;//dodaje do pozycji ilosc zczytanych elementow

                    for (int i = 0; i < 16; i++)// dla kazdego z odczytanych znakow
                    {
                        if (i < charactersRead)//jeśli są jakieś odczytane znaki
                        {
                            string hex = String.Format("{0:x2}", (byte)buffer[i]);
                            writer.Write(hex + " ");//wypisuje znak(jako bajt) i spacje
                        }
                        else writer.Write("   ");//wypisuje spacje

                        if (i == 7)//po 8 bicie
                        {
                            writer.Write("-- ");//kreski
                        }
                        if (buffer[i] < 32 || buffer[i] > 250)//jesli aktualny element jest nie do oczytania(mniejszy od 32)
                        {
                            buffer[i] = '.';
                        }
                    }
                    string bufferContents = new string(buffer);//array do stringa
                    writer.WriteLine("   " + bufferContents.Substring(0, charactersRead));  //na końcu lini wypisuje znaki od 0 do ilosci odczytanych znakow                      
                }

            }
        }





    }
}
