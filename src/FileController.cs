using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace FileReadWrite
{
    class FileController
    {
        protected List<Line> _lines;
        public string fileName;

        public FileController() { }

        public void ExtractFile(string fileName, string param)
        {
            this.fileName = fileName;
            Extract(param);
            Boolean valid = false;
            String TO = "";
            if (fileName == "help.txt") TO = "CONSOLE";
            else 
            {
                Console.WriteLine("Where would you like to extract the contents?");
                System.Threading.Thread.Sleep(500);
                while (!valid)
                {
                    Console.Write("\nCONSOLE - write the contents of the file line-by-line to the console\nTEXTFILE - write the contents to a new .txt file (stored in /_extracts\n\n>>");
                    TO = Console.ReadLine().ToUpper();
                    if (TO == "CONSOLE" || TO == "TEXTFILE") valid = true;
                    else Console.WriteLine("\nInvalid Selection. Please try again");
                }
            }
            Read(TO);

        }

        public override string ToString()
        {
            StringBuilder lines = new StringBuilder(_lines.Count);
            foreach (Line line in _lines)
            {
                lines.Append(line.ToString() + Environment.NewLine);
            }
            return lines.ToString();
        }

        public void Extract(string param)
        {
            if (param == "CSV")
            {
                string[] lines = File.ReadAllLines($"samples/{this.fileName}");
                _lines = new List<Line>(lines.Length);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] linesArray = lines[i].Split(",");
                    ExtractLine(new Line(linesArray[0], linesArray[1]));
                }
            } else {
                string[] lines = File.ReadAllLines($"samples/{this.fileName}");
                _lines = new List<Line>(lines.Length);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] linesArray = lines[i].Split("\n");
                    ExtractLine(new Line(linesArray[0]));
                }
            }

        }

        public void ExtractLine(Line line)
        {
            _lines.Add(line);
        }

        public void Read(string TO)
        {
            ToString();

            if (TO == "CONSOLE")
            {
                foreach (Line line in _lines)
                {
                    CONSOLE(line.ToString());
                }
            }
            else if (TO == "TEXTFILE")
            {
                System.IO.Directory.CreateDirectory("../_extracts/");
                if (System.IO.Directory.Exists($"../_extracts/{fileName}")) System.IO.Directory.Delete($"./_extracts/{fileName}");
                String output = "";
                foreach (Line line in _lines)
                {
                    output += line.ToString() + "\n";
                }
                TEXTFILE(output);
            }
        }
        public void CONSOLE(string line)
        {
            Console.WriteLine(line);
            System.Threading.Thread.Sleep(1000);
        }

        public void TEXTFILE(string contents)
        {
            File.WriteAllText($"./_extracts/{fileName}", contents);
        }
    }
}