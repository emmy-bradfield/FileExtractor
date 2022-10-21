using System;

namespace FileReadWrite
{

    class Line
    {
        string main;
        string second;

        public Line(string main)
        {
            this.main = main;
        }

        public Line(string main, string second){
            this.main = main;
            this.second = second;
        }

        public override string ToString()
        {
            if (second != null) return $"{main} : {second}";
            else return $"{main}";
        }
    }
}