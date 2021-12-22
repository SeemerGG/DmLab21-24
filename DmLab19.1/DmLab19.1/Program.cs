using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmLab19._1
{
    class Program
    {
        
        public static bool HasNext(List<char> word,List<char> alf)
        {
            bool f = false;
            for(int i = 0; i < word.Count; i++)
            {
                if (word[i] != alf[alf.Count - 1])
                {
                    f = true;
                    break;
                }
            }
                return f;
        }

        public static void NextWord(ref List<char> word,List<char> alf)
        {
            int i = word.Count-1;
            while (word[i] == alf[alf.Count - 1])
                i--;
            word[i] = alf[alf.IndexOf(word[i]) + 1];
            int j =i+1;
            while (j < word.Count)
            {
                word[j] = alf[0];
                j++;
            } 
        }

        public static void Vivod(List<char> word)
        {
            foreach (char b in word)
                Console.Write(b);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            List<char> alf = new List<char>();
            Console.Write("Введите символы алфавита через пробел:");
            List<char> word = new List<char>();
            foreach (char b in Console.ReadLine())
            {
                if (b != ' ')
                    alf.Add(b);
            }
            Console.Write("Введите число k:");
            int k = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < k; i++)
            {
                word.Add(alf[0]);
            }
            Vivod(word);
            while (HasNext(word, alf))
            {
                
                NextWord(ref word, alf);
                Vivod(word);
            } 
            Console.ReadKey();
        }
    }
}
