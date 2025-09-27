using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JairLib.TileGenerators;
using System;
using JairLib;
using MonoGame.Extended.Input;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace BiscuitTower
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _font;
        string seed;
        string[] gridSeed;
        PlayerOverworld player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Globals.GlobalContent = Content;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _font = Content.Load<SpriteFont>("PrettyPixelBIG");
            
            Globals.puzzleSet = Globals.GlobalContent.Load<Texture2D>("puzzleSet");
            Globals.atlas = Texture2DAtlas.Create("Atlas/Cards", Globals.puzzleSet, 64, 64);

            seed = SeedBuilder.TheStringGetsThisLength(Globals.PUZZLE_SIZE);

            player = new PlayerOverworld();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardExtended.Update();
            Globals.keyb = KeyboardExtended.GetState();

            player.Update(gameTime);

            if (Globals.keyb.WasKeyPressed(Keys.Enter))
            {
                seed = SeedBuilder.TheSeedGetsSomeOnes(seed);
                gridSeed = SeedBuilder.SplitTheSeedToAGrid(seed);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            if (!string.IsNullOrEmpty(seed))
            {
                _spriteBatch.DrawString(_font, seed, new Vector2(8, 8), Color.DarkGreen);
            }

            SeedBuilder.DrawtheSeedGrid(_spriteBatch, gridSeed);

            _spriteBatch.DrawString(_font, "press enter to generate a new seed", new Vector2(0, 32), Color.White);

            SeedBuilder.DrawThePlayer(_spriteBatch, player);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
