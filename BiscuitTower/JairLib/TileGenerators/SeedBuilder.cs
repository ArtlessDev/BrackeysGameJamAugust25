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
            var tempSeed = seed;

            for (int i = 0; i <= seed.Length; i++)
            {
                int rand = Random.Shared.Next(0, 10);

                if (rand < 5)
                {
                    ///IM AN IDIOT STRINGS ARE IMMUTABLE AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
                    //tempSeed.cut
                    //tempSeed.Insert;
                    //tempSeed[i] = rand;
                }
            }

            return seed;
        }
    }
}
