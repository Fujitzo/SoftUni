using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class TextBoxReader
    {
        public bool isOpen;
        public string currentLine;
        private List<string> text;
        public int index;
        public object sender;

        public List<string> instructions;

        public void OpenText(string name, object sender)
        {
            this.sender = sender;
            isOpen = true;
            StreamReader reader = new StreamReader(@"Text\" + name + ".txt");
            text = new List<string>();
            index = 0;

            instructions = new List<string>();
            while (!reader.EndOfStream)
            {
                text.Add(reader.ReadLine());
            }
            Next();

            reader.Close();

            
        }
        public void Next()
        {
            currentLine = text[index];
            string i = currentLine[0].ToString();

            if (string.Equals(i, "!"))
            {
                instructions.Clear();

                while (index < text.Count)
                {
                    instructions.Add(text[index]);
                    index++;
                }
                isOpen = false;
            }
            index++;
        }
    }
}
