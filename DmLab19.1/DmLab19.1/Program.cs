using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DmLab19._1
{
    class Program
    {
        class Alfavit
        {
            protected List<char> alf = new List<char>();
            public Alfavit(string s)
            {
                foreach (char b in s)
                    if(b!=' ')
                        alf.Add(b);
            }

        }
        
        class Object : Alfavit
        {
            List<char> word = new List<char>();
            public Object(string s) : base(s) { }
            
            bool HasNext()
            {
                bool f = false;
                for(int i = 0; i < word.Count;i++)
                {
                    if(word[i]!=alf[alf.Count-1])
                    {
                        f = true;
                        break;
                    }
                }
                return f;
            }

            void NextWord()
            {
                int i = word.Count - 1;
                while (word[i] == alf[alf.Count - 1])
                    i--;
                word[i] = alf[alf.IndexOf(word[i]) + 1];
                int j = i + 1;
                while (j < word.Count)
                {
                    word[j] = alf[0];
                    j++;
                }
            }

            void Vivod(StreamWriter fsr)
            {
                foreach (char b in word)
                    fsr.Write(b);
                fsr.WriteLine();
            }

            void Swap(int i, int j)
            {
                char b = word[i];
                word[i] = word[j];
                word[j] = b;
            }

            public void SuchitaniyaWithPovtoreniyami(int k)
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\SWP.txt");
                for (int i = 0; i < k; i++)
                {
                    word.Add(alf[0]);
                }
                Vivod(fsr);
                while (HasNext())
                {
                    NextWord();
                    Vivod(fsr);
                }
                fsr.Close();
            }
            
            public void Perestanovki()
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\P.txt");
                word = alf.GetRange(0, alf.Count);
                Vivod(fsr);
                while (true)
                {
                    int i = word.Count - 2;
                    while (i != -1 && alf.IndexOf(word[i]) > alf.IndexOf(word[i + 1])) i--;
                    if (i == -1)
                        break;
                    int j = word.Count - 1;
                    while (alf.IndexOf(word[i]) > alf.IndexOf(word[j])) j--;
                    Swap(i, j);
                    int l = i + 1, r = word.Count - 1;
                    while (l < r)
                        Swap(l++, r--);
                    Vivod(fsr);
                }
                fsr.Close();
            }
            ///
            public void RazmeshPoK(int k)
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\R.txt");
                word.Clear();
                for (int i = 0; i < k; i++)
                    word.Add(alf[i]);
                Vivod(fsr);
                bool f = true;
                while (f)
                {
                    int i;
                    do  
                    {
                        i = alf.Count - 1;
                        while (i != -1 && alf.IndexOf(word[i]) > alf.IndexOf(word[i + 1])) i--;
                        if (i == -1)
                        { 
                            f = false;
                            break;
                        }
                        int j = alf.Count - 1;
                        while (alf.IndexOf(word[i]) > alf.IndexOf(word[j])) j--;
                        Swap(i, j);
                        int l = i + 1, r = alf.Count - 1; 
                        while (l < r)
                            Swap(l++, r--);
                    } while (i > k - 1);
                    Vivod(fsr);
                }
                fsr.Close();
            }
            ///
        }
        
        static void Main(string[] args)
        {
            Console.Write("Введите символы алфавита через пробел:");
            Object obj = new Object(Console.ReadLine());
            Console.Write("Введите число k:");
            int k = Convert.ToInt32(Console.ReadLine());
            obj.SuchitaniyaWithPovtoreniyami(k);
            obj.Perestanovki();
            obj.RazmeshPoK(k);
            Console.ReadKey();
        }
    }
}
