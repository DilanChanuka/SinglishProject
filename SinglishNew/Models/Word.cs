using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglishNew.Models
{
   public class Word
    {
        public Word(string aWord)
        {
            word = aWord;
            Length = word.Length;
        }
        public void SetCheckText(int length)
        {
            if (length > Length)
                length = Length;
            end = nextIndex + length - 1;
            if (end + 1 + 3 > Length)
                if (end + 1 < Length)
                    nextSubstring = word.Substring(end + 1);
                else ;
            else
                nextSubstring = word.Substring(end + 1, 3);
            CheckingLength = end - nextIndex + 1;
            if (Length - nextIndex >= length && length != 0)
                CheckingString = word.Substring(nextIndex, length);
            else
            {
                end = Length - 1;
                CheckingLength = end - nextIndex + 1;
                if(nextIndex < Length)
                    CheckingString = word.Substring(nextIndex);
            }
            
        }

        public void AddConverted()
        {
            nextIndex += CheckingLength;
            Converted += temp;
            nextSubstring = "";
        }

        public string word = "";
        public string temp = "";
        public int Length;
        public int end;
        public string nextSubstring = "";
        public int nextIndex = 0;
        public string Converted = "";
        public int CheckingLength = 0;
        public string CheckingString = "";
    }
}
