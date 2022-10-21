using System;

namespace Utils
{

    public class IO
    {
        public String file;
        public IO() { }

        public string FileIn()
        {
            Console.Write("\nPlease enter the name of the .txt file you wish to extract or help for more information\n>> ");
            String fileName = Console.ReadLine();
            while (!System.IO.File.Exists($"./samples/{fileName}.txt"))
            {
                System.Threading.Thread.Sleep(1500);
                Console.Write($"\nERROR: {fileName}.txt does not exist in /samples\nPlease try again\n>> ");
                fileName = Console.ReadLine();
            }
            if (fileName.ToLower() == "help") 
            {
                String type = "TXT";
                this.file = (fileName + ".txt");
                Console.WriteLine($"\n{fileName}.txt located\nStarting {type.ToLower()} extractor...\n");
                return type;
            } else 
            {
                Console.Write("\nPlease specify the extractor you wish to use:\n TXT - seperates items by line breaks \n CSV - seperates items by commas\n\n>> ");
                String type = Console.ReadLine();
                while (type.ToUpper() != "TXT" && type.ToUpper() != "CSV")
                {
                    Console.WriteLine($"ERROR: {type.ToUpper()} is not a valid extractor");
                    Console.Write("\nPlease specify the extractor you wish to use:\n TXT - seperates items by line breaks \n CSV - seperates items by commas\n\n>> ");
                    type = Console.ReadLine();
                }
                this.file = (fileName + ".txt");
                Console.WriteLine($"\n{fileName}.txt located\nStarting {type.ToLower()} extractor...\n");
                return type.ToUpper();
            }  
        }

        public string FileOut()
        {
            Console.Write($"\n\nExtraction of {this.file} successful\nEnter 'X' to extract another file, or any other key to quite\n>> ");
            String X = Console.ReadLine();
            return X.ToUpper();
        }
    }
}