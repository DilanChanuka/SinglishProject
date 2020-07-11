using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglishNew.Models
{
    public class UniConverter
    {   
        public static string Convert(string NewWord)
        {
            word = new Word(NewWord);
            while (word.nextIndex < word.Length)
            {
                word.SetCheckText(4);
                do
                {
                    //Wow
                    if((word.temp = CheckWow()).Length > 0)
                    {
                        word.AddConverted();
                    }
                    else if((word.temp = Checklet()).Length > 0)
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
                        word.SetCheckText(4);

                }
                while (word.CheckingLength > 0);
                if(word.temp.Length == 0)
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
            for (int x = 0; x < DataSet.aryUniWow.Length/2; x++)
            {
                if (word.CheckingString == DataSet.aryUniWow[x, 0])
                    return DataSet.aryUniWow[x, 1];
            }
            return "";
        }

        public static string Checklet()
        {
            for (int x = 0; x < DataSet.aryUniLet.Length/2; x++)
            {
                if (word.CheckingString == DataSet.aryUniLet[x, 0])
                {
                    for(int y = word.nextSubstring.Length - 1; y >= 0 ; y--)
                    {
                        string temp = word.nextSubstring.Substring(0, y + 1);
                        for(int z = 1;z < DataSet.aryUniSign.Length/2; z++)
                        {
                            if (temp != "Y" && temp != "r")
                            {
                                if (DataSet.aryUniSign[z, 0] == temp)
                                {
                                    word.nextIndex += temp.Length;
                                    return DataSet.aryUniLet[x, 1] + DataSet.aryUniSign[z, 1];
                                }
                            }
                            else
                            {
                                string SpecialChar = "";
                                for(int a = 0; a < DataSet.aryUniSpe.Length/2; a++)
                                {
                                    if(temp == DataSet.aryUniSpe[a, 0])
                                    {
                                        SpecialChar = DataSet.aryUniSpe[a, 1];
                                    }
                                }
                                for(int a = word.nextSubstring.Length - 1; a >= 1; a--)
                                {
                                    string temp2 = word.nextSubstring.Substring(1, a);
                                    for(int b = 1; b < (DataSet.aryUniSign.Length/2) - 1; b++)
                                    {
                                        if (DataSet.aryUniSign[b, 0] == temp2)
                                        {
                                            word.nextIndex += temp2.Length + 1;
                                            return DataSet.aryUniLet[x, 1] + SpecialChar + DataSet.aryUniSign[b, 1];
                                        }
                                    }
                                    if (temp2.Equals("a"))
                                    {
                                        word.nextIndex += 2;
                                        return DataSet.aryUniLet[x, 1] + SpecialChar;
                                    }
                                }
                            }
                        }
                        if (temp.Equals("a"))
                        {
                            word.nextIndex++;
                            return DataSet.aryUniLet[x, 1];
                        }
                    }
                    return DataSet.aryUniLet[x, 1] + DataSet.aryUniSign[0, 1];
                }
            }
            return "";
        }
       static Word word = null;
    }
}
