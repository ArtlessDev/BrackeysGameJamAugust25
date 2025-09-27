using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Input;

namespace JairLib
{
    public class Globals
    {
        public static ContentManager GlobalContent;
        public static Texture2D puzzleSet;
        public static Texture2DAtlas atlas;
        public static int PUZZLE_SIZE = 25;
        public static KeyboardStateExtended keyb;
    }
}
