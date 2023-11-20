using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager
{
    internal class WordCounter
    {
        protected string word; 
        public string Word
        {
            get { return word; }
            set { this.word = value; }
        }

        protected int frequency; 
        public int Frequency
        {
            get { return frequency; }
            set { this.frequency = value; }
        }

        public WordCounter(string word, int frequency)
        {
            this.word = word;
            this.frequency = frequency;
        }


    }
}
