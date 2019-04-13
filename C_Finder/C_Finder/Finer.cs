using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Finder
{
    class Finer
    {
        string[] acceptFormats = new string[] { ".txt", ".tex", ".pdf" };
        public void Find(List<string> files, string TheWord, string path)
        {
            int allresult = 0;
            WriteInFile("Find:" + TheWord, true);
            WriteInFile("Source:" + path, true);
            foreach (string file in files)
            {
                CanBeOpen canBeOpen = FormatIs(file);
                
                if (canBeOpen.TakeCanI())
                {
                   
                    answer answ = ToOpener(file, canBeOpen.TakeFormat(), TheWord);
                    if (answ.ResultCount() == 0)
                    {
                        //WriteInFile("result not found.", false);
                    }
                    else
                    {
                        WriteInFile("-----", true);
                        WriteInFile("In file:  " + file.Substring(path.Length), true);
                        allresult += answ.ResultCount();
                        //WriteInFile("found " + answ.ResultCount().ToString() + " results", false);
                        foreach (var result in answ.AllResultsData())
                        {
                            WriteInFile(result, true);
                        }
                        WriteInFile("", true);
                    }

                }
                else
                {
                    //WriteInFile("File have wrong format:  " + file, true);
                }
                //WriteInFile("", true);
            }
            WriteInFile("Results:" + allresult, true);
        }
        private CanBeOpen FormatIs(string path)
        {
            CanBeOpen canBeOpen = new CanBeOpen();
            string format = Path.GetExtension(path);
            if (acceptFormats.Contains(format))
            {
                canBeOpen.AddData(true, format);
            }
            else
            {
                canBeOpen.AddData(false);
            }
            return canBeOpen;
        }

        private answer ToOpener(string path, string format, string TheWord)
        {
            answer thisansw = new answer();
            if (format==acceptFormats[0] || format == acceptFormats[1])//.txt .tex
            {
                Easyread(thisansw, path,TheWord);
            }
            else if (format == acceptFormats[2] )//.pdf
            {
                PdfReader(thisansw, path, TheWord);
            }
            return thisansw;
        }

        private void Easyread(answer thisansw, string path, string TheWord)
        {
            try
            {
                if (File.ReadAllText(path).Contains(TheWord))
                {
                    string AllData = File.ReadAllText(path);
                    AllData = GetClean(AllData);
                    foreach (Match mtch in Regex.Matches(AllData, TheWord))
                    {
                        takesting tkstr = new takesting();
                        GetIndexs(tkstr,mtch,AllData);
                        string answ = AllData.Substring(tkstr.GetStarti(), tkstr.GetLasti());
                        thisansw.addResult(answ);
                    }
                }
            }
            catch (Exception)
            {
                WriteInFile("ERROR:"+path, true);
                throw;
            }

        }//txt, tex


        private void PdfReader(answer thisansw, string path, string TheWord)
        {
            try
            {
                /* 
                 * if (File.ReadAllText(path).Contains(TheWord))
                 {
                     string AllData = File.ReadAllText(path);
                     AllData = GetClean(AllData);
                     foreach (Match mtch in Regex.Matches(AllData, TheWord))
                     {
                         takesting tkstr = new takesting();
                         GetIndexs(tkstr, mtch, AllData);
                         string answ = AllData.Substring(tkstr.GetStarti(), tkstr.GetLasti());
                         thisansw.addResult(answ);
                     }
                 }*/

            }
            catch (Exception)
            {
                WriteInFile("ERROR:" + path, true);
                throw;
            }
        }//pdf
        private void GetIndexs(takesting tkstr, Match mtch, string AllData)
        {
            int beforeAndAfter = 30;
            if (mtch.Index>beforeAndAfter)
            {
                tkstr.PutStarti(mtch.Index - beforeAndAfter);
            }
            else
            {
                tkstr.PutStarti(0);
            }
            if (AllData.Length>(mtch.Length+mtch.Length+beforeAndAfter))
            {
                tkstr.Putlasti(mtch.Length + mtch.Length + beforeAndAfter);
            }
            else
            {
                tkstr.Putlasti(AllData.Length);
            }
        }
        private string GetClean(string AllData)
        {
            AllData = Regex.Replace(AllData, @"\s+", " ");
            return AllData;
        }
        private void WriteInFile(string line, bool newstring)
        {
            using (StreamWriter sw = new StreamWriter("results.txt", true, Encoding.Default))
            {
                if (newstring)
                {
                    sw.WriteLine(line);
                }
                else
                {
                    sw.Write("  " + line);
                }

            }
        }
    }
    class answer
    {
        private int resultsWasFound = 0;
        private List<string> Results = new List<string>();

        public void addResult(string result)
        {
            resultsWasFound++;
            Results.Add(result);
        }
        public int ResultCount()
        {
            return resultsWasFound;
        }
        public List<string> AllResultsData()
        {
            return Results;
        }
    }
    class takesting
    {
        private int starti;
        private int lasti;
        public void PutStarti(int start) { starti = start; }
        public void Putlasti(int End) {lasti = End; }
        public int GetStarti() { return starti; }
        public int GetLasti() { return lasti; }
    }
    class CanBeOpen
    {
        private bool canOpen;
        private string format;
        public void AddData(bool CanOpen)
        {
            canOpen = CanOpen;
        }
        public void AddData(bool CanOpen, string Format)
        {
            canOpen = CanOpen;
            format = Format;
        }
        public bool TakeCanI()
        {
            return canOpen;
        }
        public string TakeFormat()
        {
            return format;
        }
    }
}
