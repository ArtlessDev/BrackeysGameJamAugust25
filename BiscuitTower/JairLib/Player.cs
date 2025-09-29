using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Input;
using System.Diagnostics;

namespace JairLib;

public class PlayerOverworld : ITileObject
{
    public string identifier { get; set; }
    public Rectangle rectangle { get; set; }
    public Texture2DRegion texture { get; set; }
    public Color color { get; set; }
    public PlayerState state { get; set; }

    public SpriteEffects flipper;

    public PlayerOverworld()
    {
        identifier = "blokkit";
        //texture = Globals.atlas[2 - '0'];
        texture = Globals.atlas[10];
        rectangle = new Rectangle(64, 64, 64, 64);
        color = Color.White;
        flipper = SpriteEffects.None;
        state = PlayerState.Waiting;
    }

    public void Movement()
    {


        if (Globals.keyb.WasKeyPressed(Keys.Left) || Globals.keyb.WasKeyPressed(Keys.A))
        {
            flipper = SpriteEffects.FlipHorizontally;
            rectangle = new Rectangle(rectangle.X - 32, rectangle.Y, 64, 64);
            rectangle = new Rectangle(rectangle.X - 32, rectangle.Y, 64, 64);
            state = PlayerState.Walking;
        }
        else if (Globals.keyb.WasKeyPressed(Keys.Right) || Globals.keyb.WasKeyPressed(Keys.D))
        {
            flipper = SpriteEffects.None;
            rectangle = new Rectangle(rectangle.X + 32, rectangle.Y, 64, 64);
            rectangle = new Rectangle(rectangle.X + 32, rectangle.Y, 64, 64);
            state = PlayerState.Walking;
        }
        else if (Globals.keyb.WasKeyPressed(Keys.Up) || Globals.keyb.WasKeyPressed(Keys.W))
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y - 32, 64, 64);
            rectangle = new Rectangle(rectangle.X, rectangle.Y - 32, 64, 64);
            state = PlayerState.Walking;
        }
        else if (Globals.keyb.WasKeyPressed(Keys.Down) || Globals.keyb.WasKeyPressed(Keys.S))
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y + 32, 64, 64);
            rectangle = new Rectangle(rectangle.X, rectangle.Y + 32, 64, 64);
            state = PlayerState.Walking;
        }
    }

    public void AnimatePlayerIdle(GameTime gameTime)
    {

        var deltaTime = (float)gameTime.TotalGameTime.Milliseconds;

        if (deltaTime < 500)
        {
            texture = Globals.atlas[11];
            Debug.WriteLine($"{deltaTime}");
        }
        else
        {
            texture = Globals.atlas[10];
            Debug.WriteLine($"{deltaTime}");
        }
    }


    public void AnimatePlayerMoving(GameTime gameTime)
    {
        texture = Globals.atlas[12];

        var deltaTime = (float)gameTime.TotalGameTime.Milliseconds;

        if (deltaTime == 0)
        {
            state = PlayerState.Waiting;

        }
    }

    public void Update(GameTime gameTime)
    {
        Movement();
        
        if(state == PlayerState.Walking)
        {
            AnimatePlayerMoving(gameTime);
        }
        else
        {
            AnimatePlayerIdle(gameTime);
        }

    }
}
