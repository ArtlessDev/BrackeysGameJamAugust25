using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JairLib.TileGenerators
{
    public static class SeedBuilder
    {
        public static string TheStringGetsThisLength(int length)
        {
            var str = "";

            for (int i = 0; i < length; i++)
            {
                str += "0";
            }

            return str;
        }

        public static string TheSeedGetsSomeOnes(string seed)
        {
            int[] tempSeed = new int[seed.Length];
            var newSeed = "";

            for (int i = 0; i < seed.Length; i++)
            {
                int rand = Random.Shared.Next(0, 10);

                if (rand < 5)
                {
                    ///IM AN IDIOT STRINGS ARE IMMUTABLE AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
                    tempSeed[i] = rand;
                }
                else
                {
                    tempSeed[i] = 0;
                }
                
            }

            foreach (var i in tempSeed)
            {
                newSeed += i;
            }

            return newSeed;
        }

        public static string[] SplitTheSeedToAGrid(string seed)
        {
            string[] gridSeed = new string[(int)Math.Sqrt(seed.Length)];

            int splitbyThisAmount = (int)Math.Sqrt(seed.Length);
            int splitterIndicator = 0;

            foreach (var i in seed)
            {
                gridSeed[splitterIndicator] += i; 

                if (gridSeed[splitterIndicator].Length == splitbyThisAmount)
                {
                    splitterIndicator++;
                }
            }

            return gridSeed;
        }
    }
}
