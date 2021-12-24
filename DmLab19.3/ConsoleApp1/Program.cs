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

            
            public void Zad1()
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.3\result\#1.txt");
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
                        if (Proverka1())
                        {
                            Vivod(fsr, 5);
                            continue;
                        }
                    for (int k = j + 1; k < 5; k++)
                        word[k] = alf[0];
                    if (Proverka1())
                        Vivod(fsr, 5);
                }
                fsr.Close();
            }
///
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

            void Swap(int i, int j)
            {
                char b = word[i];
                word[i] = word[j];
                word[j] = b;
            }
            ///

            public void Zad2()
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.3\result\#2.txt");
                word = alf.GetRange(0, alf.Count);
                while (true)
                {
                    int i = 4;
                    while (i != -1 && alf.IndexOf(word[i]) > alf.IndexOf(word[i + 1])) i--;
                    if (i == -1)
                        break;
                    int j = 5;
                    while (alf.IndexOf(word[i]) > alf.IndexOf(word[j])) j--;
                    Swap(i, j);
                    int l = i + 1, r = 5;
                    while (l < r)
                        Swap(l++, r--);
                    if(Proverka2())
                        Vivod(fsr, 6);
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
