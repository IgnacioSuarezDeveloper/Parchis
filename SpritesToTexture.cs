using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PARCHIS
{
    //esta clase carga sprite png entero que contiene tablero fichas dados y de el estan las diferentes funciones
    //de draw que recortan partes de sprite png como los dados o las fichas para luego dibujarlas.
    internal static class SpritesToTexture
    {
       static Texture2D fullSprite;

        //cargando la imagen completa.
        public static void LoadFullSprite(ContentManager Content)
        {
            fullSprite = Content.Load<Texture2D>("sprite.png");
        }

        //dibujando todo el sprite.
        public static void DrawFullSprite(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(fullSprite, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
        }

        //dibuja Ficha roja.
        public static void DrawRedChip(SpriteBatch _spriteBatch, float x, float y)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(0, 0, 200, 250);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
                new Rectangle((int)x, (int)y, 100, 100),
                fuente,
                Color.White
            );
        }

        //dibuaja ficha amarilla.
        public static void DrawYellowChip(SpriteBatch _spriteBatch, float x, float y)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(200, 0, 200, 250);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
                new Rectangle((int)x, (int)y, 100, 100),
                fuente,
                Color.White
            );
        }

        //dibuja la ficha verde.
        public static void DrawGreenChip(SpriteBatch _spriteBatch, float x, float y)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(200, 250, 200, 250);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
                new Rectangle((int)x, (int)y, 100, 100),
                fuente,
                Color.White
            );
        }

        //dibuja la ficha azul.
        public static void DrawBlueChip(SpriteBatch _spriteBatch, float x, float y)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(500, 250, 200, 250);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
                new Rectangle((int)x, (int)y, 100, 100),
                fuente,
                Color.White
            );
        }//ficha azul.

        //dibuja Tablero.
        public static void DrawBoard(SpriteBatch _spriteBatch, float x,float y)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(861, 360, 600, 600);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
                new Rectangle((int)x, (int)y, 1000, 1000),
                fuente,
                Color.White
            );
        }
    }
}
