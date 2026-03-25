using System;

namespace MyHashAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
   
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string input = string.Empty;

            
            Console.WriteLine("word or sentence");

            while (true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (input != null && input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                int hashResult = FoldingHash(input);
                Console.WriteLine("Folding Hash արժեքը: {0}", hashResult);
            }
        }


        private static int FoldingHash(string input)
        {
            int hashValue = 0;
            int currentFourBytes;
            int startIndex = 0;

            do
            {
                currentFourBytes = GetNextBytes(startIndex, input);

                unchecked
                {
                    hashValue += currentFourBytes;
                }

                startIndex += 4;

            } while (currentFourBytes != 0);

            return hashValue;
        }

        private static int GetNextBytes(int startIndex, string str)
        {
            int currentFourBytes = 0;

            currentFourBytes += GetByte(str, startIndex);
            currentFourBytes += GetByte(str, startIndex + 1) << 8;
            currentFourBytes += GetByte(str, startIndex + 2) << 16;
            currentFourBytes += GetByte(str, startIndex + 3) << 24;

            return currentFourBytes;
        }

        private static int GetByte(string str, int index)
        {
            if (index < str.Length)
            {
                return (int)str[index];
            }

            return 0;
        }
    }
}