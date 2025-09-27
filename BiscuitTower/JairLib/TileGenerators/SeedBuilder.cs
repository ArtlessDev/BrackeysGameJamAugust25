using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Graphics;

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

        public static void DrawThePlayer(SpriteBatch _spriteBatch, PlayerOverworld player)
        {
            player.texture = Globals.atlas[10];
            _spriteBatch.Draw(player.texture, new Vector2(player.rectangle.X, player.rectangle.Y), player.color, 0f, new Vector2(1,1), new Vector2(1,1), player.flipper, 0f);
        }

        public static void DrawtheSeedGrid(SpriteBatch _spriteBatch, string[] gridSeed)
        {
            if (gridSeed != null)
            {
                foreach (var item in gridSeed)
                {
                    int height = (64 * (Array.IndexOf(gridSeed, item) + 1));
                    foreach (var digit in item)
                    {
                        var xValue = (64 * (Array.IndexOf(item.ToCharArray(), digit) + 1));

                        Texture2DRegion tile = Globals.atlas[digit - '0'];
                        _spriteBatch.Draw(tile, new Vector2(xValue, height), Color.White);


                    }
                }
            }
        }
    }
}
