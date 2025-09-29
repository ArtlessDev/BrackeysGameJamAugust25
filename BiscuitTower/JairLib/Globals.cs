using JairLib.TileGenerators;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Input;
using System;

namespace JairLib
{
    public static class Globals
    {
        public static ContentManager GlobalContent;
        public static Texture2D puzzleSet;
        public static Texture2DAtlas atlas;
        public static int PUZZLE_SIZE = 25;
        public static KeyboardStateExtended keyb;
        public static SpriteSheet spriteSheet;
        public static string seed;
        public static string[] gridSeed;
        public static SpriteFont font;
        public static int currentLevel = 1;
        public static int CountOfTiles = 8;

        public static void Load()
        {
            puzzleSet = GlobalContent.Load<Texture2D>("puzzleSet");
            atlas = Texture2DAtlas.Create("tileSpaceSet", Globals.puzzleSet, 64, 64);
            font = GlobalContent.Load<SpriteFont>("PrettyPixelBIG");
            spriteSheet = new SpriteSheet("SpriteSheet/tileSpaceSetJSON", Globals.atlas);
        }

        public static void Update(GameTime gameTime)
        {
            KeyboardExtended.Update();
            keyb = KeyboardExtended.GetState();

            if (keyb.WasKeyPressed(Keys.Enter))
            {
                seed = SeedBuilder.TheSeedGetsSomeOnes(seed);
                gridSeed = SeedBuilder.SplitTheSeedToAGrid(seed);
            }

            seed = SeedBuilder.TheStringGetsThisLength(Globals.PUZZLE_SIZE);
        }

        public static void Draw(GameTime gameTime, SpriteBatch _spriteBatch)
        {
            
            if (!string.IsNullOrEmpty(seed))
            {
                _spriteBatch.DrawString(font, seed, new Vector2(8, 8), Color.DarkGreen);
            }

            _spriteBatch.DrawString(font, "press enter to generate a new seed", new Vector2(0, 32), Color.White);

            SeedBuilder.DrawtheSeedGrid(_spriteBatch, gridSeed);

        }

    }
}
