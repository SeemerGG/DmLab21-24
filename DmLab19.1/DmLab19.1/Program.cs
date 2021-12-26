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

            protected int n;
            public Alfavit(string s)
            {
                foreach (char b in s)
                    if(b!=' ')
                        alf.Add(b);
                n = alf.Count;
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
                    if(word[i]!=alf[n-1])
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

            void Vivod(StreamWriter fsr, int k)
            {
                for (int i = 0; i < k; i++)
                    fsr.Write(word[i]);
                fsr.WriteLine();
            }

            void VivodMnog(StreamWriter fsr, int k)
            {
                fsr.Write("{");
                for (int i = 0; i < k; i++)
                    fsr.Write(" {0}", word[i]);
                fsr.Write(" }\n");
            }

            void Swap(int i, int j)
            {
                char b = word[i];
                word[i] = word[j];
                word[j] = b;
            }

            public void RazmeshenieWithP(int k)
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\RWP.txt");
                word.Clear();
                for (int i = 0; i < k; i++)
                {
                    word.Add(alf[0]);
                }
                Vivod(fsr,k);
                while (HasNext())
                {
                    NextWord();
                    Vivod(fsr,k);
                }
                fsr.Close(); 
            }
            
            public void Perestanovki()
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\P.txt");
                word = alf.GetRange(0, n);
                Vivod(fsr,n);
                while (true)
                {
                    int i = n - 2;
                    while (i != -1 && alf.IndexOf(word[i]) > alf.IndexOf(word[i + 1])) i--;
                    if (i == -1)
                        break;
                    int j = n - 1;
                    while (alf.IndexOf(word[i]) > alf.IndexOf(word[j])) j--;
                    Swap(i, j);
                    int l = i + 1, r = n - 1;
                    while (l < r)
                        Swap(l++, r--);
                    Vivod(fsr,n);
                }
                fsr.Close();
            }
            
            public void RazmeshPoK(int k)
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\R.txt");
                word.Clear();
                for (int i = 0; i < n; i++)
                    word.Add(alf[i]);
                bool f = true;
                while (f)
                {
                    int i;
                    Vivod(fsr, k);
                    do  
                    {
                        i = n - 2;
                        while (i != -1 && alf.IndexOf(word[i]) > alf.IndexOf(word[i + 1])) i--;
                        if (i == -1)
                        {
                            f = false;
                            break;
                        }
                        int j = n - 1;
                        while (alf.IndexOf(word[i]) > alf.IndexOf(word[j])) j--;
                        Swap(i, j);
                        int l = i + 1, r = n - 1; 
                        while (l < r)
                            Swap(l++, r--);
                    } while (i > k - 1);
                }
                fsr.Close();
            }

            public void AllPodMnog()
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\AllPodMnog.txt");
                fsr.WriteLine("{ }");
                for (int i = 1; i < n; i++)
                {
                    word = alf.GetRange(0, n);
                    VivodMnog(fsr, i);
                    while (HasNextSuchit(i))
                    {
                        VivodMnog(fsr, i);
                    }
                }
                fsr.Close();
            }

            bool HasNextSuchit(int k)
            {
                for (int i = k - 1; i >= 0; --i)
                    if (alf.IndexOf(word[i]) < n - k + i)
                    {
                        word[i] = alf[alf.IndexOf(word[i]) + 1];
                        for (int l = i + 1; l < k; ++l)
                            word[l] = alf[alf.IndexOf(word[l - 1]) + 1];
                        return true;
                    }
                return false;
            }

            public void Suchitaniya(int k)
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\SNWPPoK.txt");
                word = alf.GetRange(0, n);
                Vivod(fsr, k);
                while (HasNextSuchit(k))
                {
                    Vivod(fsr, k);
                }
                fsr.Close();
            } 

            public void AllSuchitaniyaWithPovtoreniyami()
            {
                StreamWriter fsr = new StreamWriter(@"C:\Users\PcBoyarin\Desktop\GayDev\DmLab21-24\DmLab19.1\result\ASWP.txt");
                for(int i=1;i<=n;i++)
                {
                    word.Clear();
                    for (int j = 0; j < i; j++)
                    {
                        word.Add(alf[0]);
                    }
                    Vivod(fsr, i);
                    while(true)
                    {
                        int k = i- 1;
                        while (k >= 0 && word[k] == alf[n-1] ) k--;
                        if (k < 0) break;
                        word[k] = alf[alf.IndexOf(word[k]) + 1];
                        if (k == i - 1)
                        {
                            Vivod(fsr, i);
                            continue;
                        }
                        for (int p = k + 1; p < i; p++)
                            word[p]  = word[k];
                        Vivod(fsr, i);
                    }
                }
                fsr.Close();
            }
        }
        
        static void Main(string[] args)
        {
            Console.Write("Введите символы алфавита:");
            Object obj = new Object(Console.ReadLine());
            Console.Write("Введите число k:");
            int k = Convert.ToInt32(Console.ReadLine());
            obj.RazmeshenieWithP(k);
            obj.Perestanovki();
            obj.RazmeshPoK(k);
            obj.Suchitaniya(k);
            obj.AllPodMnog();
            obj.AllSuchitaniyaWithPovtoreniyami();
        }
    }
}
