using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace PARCHIS
{
    internal static class TextDrawer
    {
        static Texture2D lettersTexture;

        public static void LoadLettersTexture(ContentManager Content)
        {
            lettersTexture = Content.Load<Texture2D>("letras.png");
        }
        public static void DrawLettersTexture(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(lettersTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);

        }
    }
}
