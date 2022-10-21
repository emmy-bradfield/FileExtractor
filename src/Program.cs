using System;
using FileReadWrite;
using Utils;
namespace Program
{
    class Runner
    {
        static Boolean running = true;
        public static void Main(string[] args)
        {
            IO util = new IO();
            FileController extractor = new FileController();
            String file;
            while(running)
            {
                String param = util.FileIn();
                file = util.file;
                extractor.ExtractFile(file, param);
                String loop = util.FileOut();
                if (loop != "X") running = false;
            }
        }
    }
}