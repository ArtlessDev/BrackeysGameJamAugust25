using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace JairLib
{
    public class TileSpace : ITileObject
    {
        public string identifier { get; set; }
        public Rectangle rectangle { get; set; }
        public Texture2DRegion texture { get; set; }
        public Color color { get; set; }

        public TileSpace()
        {
            texture = Globals.atlas[0];
            rectangle = new Rectangle();
            color = Color.White;
        }
    }
}
