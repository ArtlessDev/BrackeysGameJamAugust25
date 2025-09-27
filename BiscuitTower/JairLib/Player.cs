using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

    public SpriteEffects flipper;

    public PlayerOverworld()
    {
        identifier = "blokkit";
        //texture = Globals.atlas[2 - '0'];
        rectangle = new Rectangle(64, 64, 64, 64);
        color = Color.White;
        flipper = SpriteEffects.None;
    }

    public void Movement()
    {
        if (Globals.keyb.WasKeyPressed(Keys.Left) || Globals.keyb.WasKeyPressed(Keys.A))
        {
            flipper = SpriteEffects.FlipHorizontally;
            rectangle = new Rectangle(rectangle.X - 32, rectangle.Y, 64, 64);
            rectangle = new Rectangle(rectangle.X - 32, rectangle.Y, 64, 64);
            texture = Globals.atlas[12];

        }
        else if (Globals.keyb.WasKeyPressed(Keys.Right) || Globals.keyb.WasKeyPressed(Keys.D))
        {
            flipper = SpriteEffects.None;
            rectangle = new Rectangle(rectangle.X + 32, rectangle.Y, 64, 64);
            rectangle = new Rectangle(rectangle.X + 32, rectangle.Y, 64, 64);
            texture = Globals.atlas[12];
        }
        else if (Globals.keyb.WasKeyPressed(Keys.Up) || Globals.keyb.WasKeyPressed(Keys.W))
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y - 32, 64, 64);
            rectangle = new Rectangle(rectangle.X, rectangle.Y - 32, 64, 64);
            texture = Globals.atlas[12];
        }
        else if (Globals.keyb.WasKeyPressed(Keys.Down) || Globals.keyb.WasKeyPressed(Keys.S))
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y + 32, 64, 64);
            rectangle = new Rectangle(rectangle.X, rectangle.Y + 32, 64, 64);
            texture = Globals.atlas[12];
        }
        else
        {
            texture = Globals.atlas[10];
        }

    }

    public void Update(GameTime gameTime)
    {
        Movement();


    }
}
