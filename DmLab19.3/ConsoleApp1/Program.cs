using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        class Alfavit
        {
            protected List<char> alf = new List<char>();

            protected int n;
            public Alfavit(string s)
            {
                foreach (char b in s)
                    if (b != ' ')
                        alf.Add(b);
                n = alf.Count;
            }

        }

        class Object : Alfavit
        {
            List<char> word = new List<char>();

            public Object(string s) : base(s) { }

            void Vivod(StreamWriter fsr, int k)
            {
                for (int i = 0; i < k; i++)
                    fsr.Write(word[i]);
                fsr.WriteLine();
            }

            bool Proverka1()
            {
                int[] kol =new int[6];
                for (int i = 0; i < 5; i++)
                    kol[alf.IndexOf(word[i])]++;
                int k = 0;
                for (int i = 0; i < 6; i++)
                    if (kol[i] == 2)
                        k++;
                    else
                        if (kol[i] > 2)
                        return false;
                if (k == 1)
                    return true;
                else
                    return false;
            }

            bool Proverka2()
            {
                int[] kol = new int[6];
                for (int i = 0; i < 6; i++)
                    kol[alf.IndexOf(word[i])]++;
                int k = 0;
                for (int i = 0; i < 6; i++)
                    if (kol[i] == 2)
                        k++;
                    else
                        if (kol[i] > 2)
                        return false;
                if (k == 2)
                    return true;
                else
                    return false;
            }

            void NextWord()
            {
                int i = word.Count - 1;
                while (word[i] == alf[n - 1])
                    i--;
                word[i] = alf[alf.IndexOf(word[i]) + 1];
                int j = i + 1;
                while (j < word.Count)
                {
                    word[j] = alf[0];
                    j++;
                }
            }

            bool HasNext()
            {
                bool f = false;
                for (int i = 0; i < word.Count; i++)
                {
                    if (word[i] != alf[n - 1])
                    {
                        f = true;
                        break;
                    }
                }
                return f;
            }
            public void Zad1(int k)
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.3\result\#1.txt");
                word.Clear();
                for (int i = 0; i < k; i++)
                    word.Add(alf[0]);
                while (HasNext())
                {
                    NextWord();
                    if(Proverka1())
                        Vivod(fsr, k);
                }
                fsr.Close();
            }

            public void Zad2(int k)
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.3\result\#2.txt");
                word.Clear();
                for (int i = 0; i < k; i++)
                    word.Add(alf[0]);
                while (HasNext())
                {
                    NextWord();
                    if(Proverka2())
                        Vivod(fsr, k);
                }
                fsr.Close();
            }

        }

        static void Main(string[] args)
        {
            string s = "a b c d e f";
            Object word = new Object(s);
            word.Zad1(5);
            word.Zad2(6);
        }
    }
}
