using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace SinglishNew.Models
{
   public class DataSet
    {
        // Variables
        public static string[,] aryUniWow =
            { 
            {"a","අ" }, {"aa","ආ" },
              {"ae","ඇ" }, {"aae","ඈ" },
              {"i","ඉ"}, {"ii","ඊ"},
              {"ee","ඊ"}, {"u","උ"},
              {"uu","ඌ" }, {"oo","ඌ"},
              {"iru","ඍ" }, {"iruu","ඎ" },
              {"e","එ" }, {"ei","ඒ" }, {"ea","ඒ" },
              {"ea","ඒ" }, {"ai","ඓ" },
              {"o","ඔ" }, {"oa","ඕ" },
              {"au","ඖ" } , { "x","ං"} };
        public static string[,] aryUniSign =
             { {"0","්"}, {"aa","ා"},{"ae","ැ"}, {"aae","ෑ"},
             {"i","ි"}, {"ii","ී"}, {"ee","ී" }, {"u","ු" },
             {"uu","ූ" }, {"oo","ූ" }, {"ru","ෘ" }, {"ruu","ෲ" },
             {"roo","ෲ" }, {"e","ෙ" }, {"ei","ේ" }, {"ai","ෛ" },
             {"o","ො" }, {"oa","ෝ" }, { "au","ෞ" }, 
             {"x","ං" }, {"ea","ේ" }};
        public static string[,] aryUniLet =
            { {"k","ක" }, {"K","ඛ" }, {"g","ග" }, {"G","ඝ"},
              {"X","ඞ" }, {"nng","ඟ" }, {"ch","ච" }, {"c","ච" },
              {"Ch","ඡ" }, {"C","ඡ" }, {"j","ජ" }, {"J","ඣ" },
              {"knn","ඤ" }, {"gnn","ඥ" },{"t","ට" }, {"T","ඨ" },
              {"d","ඩ" }, {"D","ඪ" },{"N","ණ" }, {"nnd","ඬ" }, 
              {"th","ත" }, {"Th","ථ" }, {"dh","ද" }, {"Dh","ධ" },
              {"n","න" }, {"nndh","ඳ" },{"p","ප" }, {"P","ඵ" },
              {"b","බ" }, {"B","භ" },{"m","ම" }, {"M","ඹ" },
              {"y","ය" }, {"r","ර" },{"l","ල" }, {"v","ව" },{"w","ව" },
              {"L","ළ" }, {"sh","ශ" },{"Sh","ෂ" }, {"z","ෂ" },
              {"s","ස" }, {"h","හ" },{"f","ෆ" }};
        public static string[,] aryUniSpe = { { "r", "්‍ර" }, { "Y", "්‍ය" } };
// Sinhala Font
        public static string[,] aryFontWow =
           { {"a","w" }, {"aa","wd" },
              {"ae","we" }, {"aae","wE" },
              {"i","b"}, {"ii","B"},
              {"ee","B"}, {"u","W"},
              {"uu","W!" }, {"oo","W!"},
              {"iru","R" }, {"iruu","RD" },
              {"e","t" }, {"ei","ta" }, {"ea","ta" },
              {"ea","ta" }, {"ai","ft" },
              {"o","T" }, {"oa","´" },
              {"au","T!" } , { "x","x"},
              {"duu","¥" },{"doo","¥" }, {"lu","¨" }, {"nndhuu","ª" },
              {"Ji","¯" }, {"Jii","°" }, {"Jee","°" }, {"oa","´" },
              {"Lu","¿" }, {"Luu","¿E" }, {"Ti","À" }, {"Tii","Á" },
              {"Tee","Á" }, {"Ki","Å" }, {"luu","Æ" }, {"loo","Æ" },
              {"Kii","Ç" }, {"Kee","Ç" }, {"rii","Í" }, {"ree","Í" },
              {"Di","Î" }, {"Dii","Ð" }, {"Dee","Ð" }, {"chi","Ñ" },
              {"ci","Ñ" }, {"Thii","Ò" }, {"Thee","Ò" }, {"Thi","Ó" },
              {"jii","Ô" }, {"jee","Ô" }, {"chii","Ö" }, {"chee","Ö" },
              {"Pii","Ú" }, {"Pee","Ú" }, {"Pi","Ý" }, {"ri","ß" },
              {"tii","à" },{"tee","à" }, {"ti","á" }, {"dii","ã" },
              {"dee","ã" }, {"di","ä" }, {"nndi","ç" }, {"nndii","é" },
              {"Dhi","ê" }, {"Dhii","ë" }, {"Dhee","ë" }, {"bi","ì" },
              {"bii","î" }, {"bee","î" }, {"ji","ð" }, {"mi","ñ" },
              {"mii","ó" }, {"mee","ó" }, {"Mi","ô" }, {"Mii","ö" },
              {"Mee","ö" }, {"nndhu","÷" }, {"dhra","ø" }, {"vii","ù" },
              {"vee","ù" }, {"wii","ù" }, {"wee","ù" }, {"vi","ú" },
              {"wi","ú" }, {"knnu","û" }, {"knuu","ü" }, {"knoo","ü" }, 
              {"Chi","ý" }, {"Ci","ý" }, {"dhu","ÿ" }, {"Ji","ˉ" }, 
              { "shri","›" }, { ".","'" }, {",","\"" }, { "?","@" }, 
              {"(","^" }, {")","&" } };


        public static string[,] aryFontSign =
             { {"0","a"}, {"aa","d"},{"ae","e"}, {"aae","E"},
             {"i","s"}, {"ii","S"}, {"ee","S"}, {"u","q"},
             {"uu","Q"}, {"oo","Q"}, {"ru","d"}, {"ruu","dd"},
             {"roo","dd"}, {"e","f"}, {"ei","fa"}, {"ai","ff"},
             {"o","fd"}, {"oa","fda"}, { "au","f!"},
             {"ea","fa"}};
        public static string[,] aryFontLet =
            { {"k","l","" }, {"K","L","Ä" }, {"g",".","" }, {"G",">",""},
              {"X","X","" }, {"nng","Õ","" }, {"ch","p","É" }, {"c","p","É" },
              {"Ch","P","þ" }, {"C","P","þ" }, {"j","c","" }, {"J","C","" },
              {"knn","[","" }, {"gnn","{","" },{"t","g","Ü" }, {"T","G","" },
              {"d","v","â" }, {"D","V","" },{"N","K","" }, {"nnd","~" ,"å"},
              {"th",";","" }, {"Th",":","" }, {"dh","o","" }, {"Dh","O","è" },
              {"n","k","" }, {"nndh","|","" },{"p","m","" }, {"P","M","" },
              {"b","n","í"}, {"B","N","" },{"m","u","ï" }, {"M","U","ò" },
              {"y","h","" }, {"r","r","¾" },{"l",",","" }, {"v","j","õ" },{"w","j","õ" },
              {"L","<","" }, {"sh","Y","" },{"Sh","I","" }, {"z","I","" },
              {"s","i","" }, {"h","y","" },{"f","F","" }};
        public static string[,] aryFontSpe = { { "r", "%" }, { "Y", "H" } };

        public static string[] aryCharList = {"K","ch","c","Ch","C","t","d","nnd",
                                              "Dh","b","m","M","r","v","w"};
  
        /*private static bool FontsInstalled()
        {
            Font F1 = new Font("FMBindumathi", 16);
            Font F2 = new Font("Iskoola Pota", 16);
            if (F1.Name == "FMBindumathi" && F2.Name == "Iskoola Pota")
                return true;
            return false;
        }
        public static void CheckFonts()
        {
            if (!FontsInstalled())
            {
                if(MessageBox.Show("Required Fonts Not Found\nDo you want to install Fonts now ?",
                    "Singlish Translater [ SL Soft ]",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {

                }
                else
                {
                    MessageBox.Show("Required Fonts Not Installed.\nTranslated Text Might not be Display Correctly", "Singlish Translater [ SL Soft ]");
                }
            }
        }
        public static void SetFontData(RichTextBox Sin,ToolStripTextBox txtbx,int index)
        {
            if (index == 0)
            {
                // Font Editing
                txtbx.Enabled = false;  
                Sin.Font = SD.FontUni;
            }
            else
            {
                txtbx.Enabled = true;
                Sin.Font = SD.FontSinhala;
            }
            txtbx.Text = "Font : " + Sin.Font.Name;
        }
        public static void SetTextBoxes(Size size,RichTextBox Sin,RichTextBox eng)
        {
            Sin.Location = DataSet.SD.LocationSin;
            eng.Location = DataSet.SD.LocationEng;
            Size dif = size - SD.FormSize;
            if(Sin.Top > eng.Top)
                Sin.Top = Sin.Top + (dif.Height / 2);
            else
                eng.Top = eng.Top + (dif.Height / 2);
            Sin.Height = eng.Height = eng.Height + (dif.Height / 2);
        }

        public static SuggestionsList SL = new SuggestionsList();
        public static SavedData SD;*/
    }
}
