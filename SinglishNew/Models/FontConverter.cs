using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglishNew.Models
{
    public class FontConverter
    {
        public static string Convert(string NewWord)
        {
            word = new Word(NewWord);
            while (word.nextIndex < word.Length)
            {
                word.SetCheckText(6);
                do
                {
                    //Wow
                    if ((word.temp = CheckWow()).Length > 0)
                    {
                        word.AddConverted();
                    }
                    else if ((word.temp = Checklet()).Length > 0)
                    {
                        word.AddConverted();
                    }
                    if (word.temp.Length == 0)
                    {
                        if (word.CheckingLength == 1)
                            break;
                        word.SetCheckText(word.CheckingLength - 1);
                    }
                    else
                        word.SetCheckText(6);

                }
                while (word.CheckingLength > 0);
                if (word.temp.Length == 0)
                {
                    word.temp = word.CheckingString;
                    word.AddConverted();
                    word.nextIndex++;
                }
            }
            return word.Converted;
        }
        public static string CheckWow()
        {
            for (int x = 0; x < DataSet.aryFontWow.Length / 2; x++)
            {
                if (word.CheckingString == DataSet.aryFontWow[x, 0])
                    return DataSet.aryFontWow[x, 1];
            }
            return "";
        }

        public static string Checklet()
        {
            for (int x = 0; x < DataSet.aryFontLet.Length / 3; x++)
            {
                if (word.CheckingString == DataSet.aryFontLet[x, 0])
                {
                    for (int y = word.nextSubstring.Length - 1; y >= 0; y--)
                    {
                        string temp = word.nextSubstring.Substring(0, y + 1);
                        for (int z = 1; z < DataSet.aryFontSign.Length / 2; z++)
                        {
                            if(DataSet.aryCharList.Contains(word.CheckingString) && 
                                (temp == "ea"||temp == "ei")){
                                word.nextIndex += temp.Length;
                                return DataSet.aryFontLet[x, 2] + "f";
                            }
                            if(word.CheckingString == "th" || word.CheckingString == "k")
                            {
                                if (temp == "u") {
                                    word.CheckingLength += temp.Length;
                                    return DataSet.aryFontLet[x, 1] + "=";
                                }
                                if (temp == "uu" || temp == "oo")
                                {
                                    word.CheckingLength += temp.Length;
                                    return DataSet.aryFontLet[x, 1] + "+";
                                }
                            }
                            if(word.CheckingString == "r" && temp == "u")
                            {
                                word.nextIndex += temp.Length;
                                return "r" + "e";
                            }
                            if (word.CheckingString == "r" && (temp == "uu" || temp == "oo"))
                            {
                                word.nextIndex += temp.Length;
                                return "r" + "E";
                            }
                            if (temp != "Y" && temp != "r")
                            {
                                if (DataSet.aryFontSign[z, 0] == temp)
                                {
                                    word.nextIndex += temp.Length;
                                    return DataSet.aryFontLet[x, 1] + DataSet.aryFontSign[z, 1];
                                }
                            }
                            else
                            {
                                string SpecialChar = "";
                                for (int a = 0; a < DataSet.aryFontSpe.Length / 2; a++)
                                {
                                    if (temp == DataSet.aryFontSpe[a, 0])
                                    {
                                        SpecialChar = DataSet.aryFontSpe[a, 1];
                                    }
                                }
                                for (int a = word.nextSubstring.Length - 1; a >= 1; a--)
                                {
                                    string temp2 = word.nextSubstring.Substring(1, a);
                                    for (int b = 1; b < (DataSet.aryFontSign.Length / 2) - 1; b++)
                                    {
                                        if (DataSet.aryFontSign[b, 0] == temp2)
                                        {
                                            word.nextIndex += temp2.Length + 1;
                                            return DataSet.aryFontLet[x, 1] + SpecialChar + DataSet.aryFontSign[b, 1];
                                        }
                                    }
                                    if (temp2.Equals("a"))
                                    {
                                        word.nextIndex += 2;
                                        return DataSet.aryFontLet[x, 1] + SpecialChar;
                                    }
                                }
                            }
                        }
                        if (temp.Equals("a"))
                        {
                            word.nextIndex++;
                            return DataSet.aryFontLet[x, 1];
                        }
                    }
                    if (DataSet.aryCharList.Contains(DataSet.aryFontLet[x, 0]))
                        return DataSet.aryFontLet[x, 2];
                    else
                        return DataSet.aryFontLet[x, 1] + DataSet.aryFontSign[0, 1];
                }
            }
            return "";
        }
        static Word word = null;
    }
}
