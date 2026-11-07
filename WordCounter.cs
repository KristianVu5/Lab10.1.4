using System;
using System.Collections;
using System.Text;

namespace Lab10._1._4
{
    class Program
    {
        internal class WordCounter
        {
            public static string testString = "This Is A Well-Done Program";

            SortedList wordCounter = new SortedList();

            public int UniqueWords
            {
                get { return wordCounter.Count; }
            }

            public IDictionaryEnumerator GetWordsAlphabeticallyEnumerator()
            {
                return (IDictionaryEnumerator)wordCounter.GetEnumerator();
            }

            public Boolean CountStats(out Int64 numWords, out Int64 numChars)
            {
                Boolean Ok = true;
                numWords = numChars = 0;

                string[] Words = testString.Split(null);
                numWords = Words.Length;

                for (int Word = 0; Word < numWords; Word++)
                {
                    if (Words[Word] != "")
                    {
                        numChars += Words[Word].Length;
                        if (!wordCounter.Contains(Words[Word]))
                        {
                            wordCounter.Add(Words[Word], 1);
                        }
                        else
                        {
                            wordCounter[Words[Word]] = (Int32)wordCounter[Words[Word]] + 1;
                        }
                    }

                }
                return (Ok);
            }

        }


        public static int Main()
        {
            WordCounter wc = new WordCounter();
            Int64 NumWords, NumChars;

            Console.WriteLine("\n1.Izvikvane na CountStats(out NumWords, out NumChars)");
            wc.CountStats(out NumWords, out NumChars);

            Console.WriteLine("\n2.");
            Console.WriteLine("For string\n {0}", WordCounter.testString);

            Console.WriteLine("\n3. Statistics:");
            Console.WriteLine("Words: {0} \tChars: {1}",NumWords, NumChars);

            Console.WriteLine("\n4. Value of collection:");
            Console.WriteLine("Word\t\tCount");

            IDictionaryEnumerator enumerator = wc.GetWordsAlphabeticallyEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine("{0,-12}\t{1}", enumerator.Key, enumerator.Value);
            }

            Console.WriteLine("\nCount of saved twins: {0}", wc.UniqueWords);

            Console.ReadLine();
            return 0;
        }
    }
}
