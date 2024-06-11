using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class WordFinder
    {
        char[,] wordsMatrix = null;
        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix != null && matrix.Count() > 0)
            {
                var wordsMatrixSize = matrix.Count();
                wordsMatrix = new char[wordsMatrixSize, matrix.First().Length];
                var rowPossition = 0;
                foreach (var word in matrix)
                {
                    Char[] charToInclude = word.ToCharArray();

                    for (int idx = 0; idx < charToInclude.Length; idx++)
                    {
                        wordsMatrix[rowPossition, idx] = charToInclude[idx];
                    }
                    rowPossition++;
                }
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var result = new List<string>();

            var wordPosY = 0;
            var positionY = new List<int>();
            var match = false;

            foreach (var word in wordstream)
            {
                var wordSize = word.Length;
                var wordPosX = 0;
                wordPosY = 0;
                match = false;
                var positionX = new List<int>();
                positionY.Clear();

                for (int idj = 0; idj < wordsMatrix.GetLength(0); idj++) //loop main j
                {
                    for (int idx = 0; idx < wordsMatrix.GetLength(1); idx++) //loop  main x
                    {
                        if (wordsMatrix[idj, idx] == word[wordPosX])
                        {
                            wordPosX = wordPosX + 1;

                            if (wordPosX == wordSize) //process x
                            {
                                if (!result.Contains(word))
                                    result.Add(word);
                                wordPosX = 0;
                                wordPosY = 0;
                            }
                        }

                        if (wordPosY == 0)
                        {
                            if (wordsMatrix[idj, idx] == word[wordPosY])
                            {
                                match = true;                                
                                positionY.Add(idx);
                            }
                        }
                        else
                        {
                            if (positionY.Contains(idx))
                            {
                                foreach (var posY in positionY)
                                {
                                    if (wordsMatrix[idj, idx] == word[wordPosY] && idx == posY)
                                    {
                                        match=true;
                                        
                                        if (wordPosY + 1 == wordSize) //process y
                                        {
                                            if (!result.Contains(word))
                                                result.Add(word);
                                            wordPosY = 0;
                                            wordPosX = 0;
                                            match = false;
                                        }
                                    }
                                }
                            }
                        }

                        if ( idx +1 == wordsMatrix.GetLength(1))
                        {
                            if (positionY.Count > 0 && match)
                            {
                                wordPosY = wordPosY + 1;
                            }                            
                            wordPosX = 0;
                        }
                    }
                }
            }


            return result;
        }

    }  
}
