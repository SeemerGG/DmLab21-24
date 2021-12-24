using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DmLab19._2
{
    class Program
    {
        class Alfavit
        {
            protected List<char> alf = new List<char>();
            public Alfavit(string s)
            {
                foreach (char b in s)
                    if (b != ' ')
                        alf.Add(b);
            }

        }

        class Object : Alfavit
        {
            List<char> word = new List<char>();
            public Object(string s) : base(s) { }

             void Vivod(StreamWriter fsr)
            {
                for(int i=0;i<5;i++)
                    fsr.Write(word[i]);
                fsr.WriteLine();
            }

             bool AA()
            {
                int kol = 0;
                for(int i=0;i<5;i++)
                    if (word[i] == 'a')
                        kol++;
                if (kol == 2)
                    return true;
                else
                    return false;
            }

            bool BezPiAA()
            {
                int kol = 0;
                for (int i = 0; i < 5; i++)
                    if (word[i] == 'a')
                        kol++;
                if (kol == 2)
                {
                    for(int i=0;i<5;i++)
                        for(int j=0;j<5;j++)
                            if(i!=j && word[i] != 'a' && word[i] == word[j])
                                return false;
                    return true;
                }
                else
                    return false;
            }
            public void Zad1()
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.2\result\#1.txt");
                for (int i = 0; i < 6; i++)
                    word.Add(alf[0]);
                while (true)
                {
                    int j = 4;
                    while (j >= 0 && word[j] == alf[5]) j--;
                    if (j < 0) break;
                    if (alf.IndexOf(word[j]) >= 6)
                        j--;
                    word[j] = alf[alf.IndexOf(word[j]) + 1];
                    if (j == 4)
                        if (AA())
                        {
                            Vivod(fsr);
                            continue;
                        }
                    for (int k = j + 1; k < 5; k++)
                        word[k] = alf[0];
                    if (AA())
                        Vivod(fsr);
                }
                fsr.Close();
            }

            public void Zad2()
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.2\result\#2.txt");
                word.Clear();
                for (int i = 0; i < 6; i++)
                    word.Add(alf[0]);
                while (true)
                {
                    int j = 4;
                    while (j >= 0 && word[j] == alf[5]) j--;
                    if (j < 0) break;
                    if (alf.IndexOf(word[j]) >= 6)
                        j--;
                    word[j] = alf[alf.IndexOf(word[j]) + 1];
                    if (j == 4)
                        if (BezPiAA())
                        {
                            Vivod(fsr);
                            continue;
                        }
                    for (int k = j + 1; k < 5; k++)
                        word[k] = alf[0];
                    if (BezPiAA())
                        Vivod(fsr);
                }
                fsr.Close();
            }
            
        }
            
        static void Main(string[] args)
        {
            string s = "a b c d e f";
            Object word = new Object(s);
            word.Zad1();
            word.Zad2();
            Console.ReadKey();
        }
    }
}
