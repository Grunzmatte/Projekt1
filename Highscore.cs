using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;


namespace Projekt1
{
    static class Highscore
    {
        private static FileStream fileMangaer;
        private static string filePath = "Highscore.txt";        

        internal static string[] Reader()
        {
            string Row = "";
            //Indexer (Zeilenanzahl)
            int index = 0;

            //Array mit indexer Zeilen    1 Zeile entspricht 1 Index
            string[] highscore = new string[index];

            //Text aus Datei auslesen
            //Wenn kein gültiger Dateipfad abgespeichert ist
            if (!File.Exists(filePath))
            {
                fileMangaer = new FileStream(filePath, FileMode.CreateNew);
            }

            fileMangaer = new FileStream(filePath, FileMode.Open);
            StreamReader textReader = new StreamReader(fileMangaer);

            while (textReader.Peek() != -1)
            {
                //Array wird pro Durchgang um 1 Zeile erweitert
                Array.Resize<string>(ref highscore, index + 1);
                //Eine Zeile aus Textdatei auslesen
                Row = textReader.ReadLine();
                //Zeileninhalt wird gespeichert und Indexer i wird zugleich um 1 erhöht
                highscore[index++] = Row;
            }
            textReader.Close();
            return highscore;
        }

        internal static void Writer(string[] highscoreList)
        {
            //Text in Datei Speichern
            
            fileMangaer = new FileStream(filePath, FileMode.Create);
            StreamWriter textWriter = new StreamWriter(fileMangaer);
                       
            for (int index = 0; index < highscoreList.Length; index++)
            {
                textWriter.WriteLine(highscoreList[index]);
            }
                
            textWriter.Close();
           
        }        
        
    }
}
