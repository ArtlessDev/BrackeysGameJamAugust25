using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JairLib.TileGenerators;
using System;

namespace BiscuitTower
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont _font;
        string seed;
        string[] gridSeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            seed = SeedBuilder.TheStringGetsThisLength(16);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var keyb = Keyboard.GetState();
            if (keyb.IsKeyDown(Keys.Enter))
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
            _spriteBatch.Begin();

            if (!string.IsNullOrEmpty(seed))
            {
                _spriteBatch.DrawString(_font, seed, new Vector2(8, 8), Color.DarkGreen);
            }
            
            if (gridSeed != null)
            {
                foreach (var item in gridSeed)
                {
                    int height  = Array.IndexOf(gridSeed, item) + 1;
                    _spriteBatch.DrawString(_font, item, new Vector2(64, 64*height), Color.White);

                }
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
