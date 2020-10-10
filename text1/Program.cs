using System;
using System.Linq;
using System.Threading;

namespace text1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст.");
            string text = Console.ReadLine();

            //1.кол-во знаков препинания:
            int signs = 0;
            char[] mark = { '.', ',', ';', ':', '-', '?', '!' };
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < mark.Length; j++)
                {
                    if (text[i] == mark[j])
                        signs++;
                }
            }
            Console.WriteLine($"1. Количество знаков препинания: {signs}");


            //2.разделение текста на предложения:
            string[] sentences = text.Split(new char[] { '.', ';', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("2. Разделение текста на предложения:");
            for (int i = 0; i < (sentences.Length); i++)
                Console.WriteLine($"{i + 1}) {sentences[i]}.");


            //3.создание массива уникальных слов и их вывод через запятую:
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] unique = new string[] { };
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim(new char[] { '.', ',', ';', ':', '?', '!' }); //обрезка символа в конце слова
                words[i] = words[i].ToLower(); //приведение к нижнему регистру
                
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[i] != words[j])
                    {
                        unique[count] = words[i];
                        count++;
                    }
                }
            }
            Console.WriteLine("3. Уникальные слова:");
            for (int i = 0; i < unique.Length; i++)
            Console.WriteLine(unique[i], ',');
            if (unique.Length == 0)
                Console.WriteLine("Уникальных слов нет:(");


            //4.самое длинное слово в тексте:
            string[] words2 = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int lengthmax = 0;
            string longest = "";
            for (int i = 0; i < words2.Length; i++)
            {
                if (words2[i].Length > lengthmax)
                {
                    lengthmax = words2[i].Length;
                    longest = words2[i];
                }
            }
            Console.WriteLine($"4. Cамое длинное слово в тексте: ", longest);


            //5.работа с длиной длинного слова:
            if (longest.Length % 2 == 0)
                Console.WriteLine(longest.Substring(longest.Length / 2));
            else
            {
                char[] letter = longest.ToCharArray();
                letter[longest.Length / 2] = '*';
                longest = new string(letter);
                Console.WriteLine(longest);
            }
        }
    }
}
