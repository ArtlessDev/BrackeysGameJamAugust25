using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JairLib.TileGenerators;
using JairLib;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace BiscuitTower
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


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


            Globals.Load();
            
            // Globals.spriteSheet.DefineAnimation("walking", builder =>
            // {
            //     builder.IsLooping(true)
            //     .AddFrame("", TimeSpan.FromSeconds(0.1));
            // });



            player = new PlayerOverworld();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.Update(gameTime);

            player.Update(gameTime);




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            Globals.Draw(gameTime, _spriteBatch);
            SeedBuilder.DrawThePlayer(_spriteBatch, player);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
