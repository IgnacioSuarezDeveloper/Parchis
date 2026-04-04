using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PARCHIS
{
    //esta clase carga sprite png entero que contiene tablero fichas dados y de el estan las diferentes funciones
    //de draw que recortan partes de sprite png como los dados o las fichas para luego dibujarlas.
    internal static class SpritesToTexture
    {
        //almacena el sprite del parchis. png.

        static Texture2D fullSprite;

        //almacena el sprite de botones .png.

        static Texture2D buttonsSprite;

        //porcentaje del tablero que es el tamaño de las fichas.

        static int percentejeChipSize = 20;

        //cargando la imagen completa.

        public static void LoadFullSprite(ContentManager Content)
        {

            //cargando el sprite del parchis.

            fullSprite = Content.Load<Texture2D>("sprite.png");

            //cargando el sprite de botones.

            buttonsSprite = Content.Load<Texture2D>("buttons.png");

        }


        //dibujando todo el sprite de parchis.
        public static void DrawFullParchisSprite(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(fullSprite, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
        }


        //dibujando todo el sprite de botones.
        public static void DrawFullButtonsSprite(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(buttonsSprite, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);

        }


        //dibuja Ficha roja.
        public static void DrawRedChip(SpriteBatch _spriteBatch, float x, float y, int BoardWidth, int BoardHeigth)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(0, 25, 155, 180);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
                new Rectangle((int)x, (int)y, BoardWidth / percentejeChipSize, BoardHeigth / percentejeChipSize),
                fuente,
                Color.White
            );
        }


        //dibuaja ficha amarilla.
        public static void DrawYellowChip(SpriteBatch _spriteBatch, float x, float y, int BoardWidth, int BoardHeigth)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(155, 25, 155, 180);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
               new Rectangle((int)x, (int)y, (int)(BoardWidth / percentejeChipSize), (int)(BoardHeigth / percentejeChipSize)),
                fuente,
                Color.White
            );
        }


        //dibuja la ficha verde.
        public static void DrawGreenChip(SpriteBatch _spriteBatch, float x, float y, int BoardWidth, int BoardHeigth)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(155, 250, 155, 180);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
                new Rectangle((int)x, (int)y, BoardWidth / percentejeChipSize, BoardHeigth / percentejeChipSize),
                fuente,
                Color.White
            );
        }


        //dibuja la ficha azul.
        public static void DrawBlueChip(SpriteBatch _spriteBatch, float x, float y , int BoardWidth, int BoardHeight)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(535, 250, 155, 180);

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
               new Rectangle((int)x, (int)y, BoardWidth / percentejeChipSize, BoardHeight / percentejeChipSize),
                fuente,
                Color.White
            );
        }//ficha azul.


        //dibuja Tablero.
        public static void DrawBoard(SpriteBatch _spriteBatch, float x,float y, int BoardWidth, int BoardHeigth)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(861, 360, 600, 600);

           

            // Dibujamos
            _spriteBatch.Draw(
                fullSprite,
                new Rectangle((int)x, (int)y, BoardWidth, BoardHeigth),
                fuente,
                Color.White
            );
        }


        //dibujar boton izquierdo.
        public static void DrawLeftButton(SpriteBatch _spriteBatch, float x, float y, int BoardWidth, int BoardHeight)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(345, 430, 240, 190);
                
            // Dibujamos
            _spriteBatch.Draw(
                buttonsSprite,
               new Rectangle((int)x, (int)y, BoardWidth / 10, BoardHeight / 10),
                fuente,
                Color.White
            );
        }//ficha azul.
        

        //dibujar boton derecho.
        public static void DrawRightButton(SpriteBatch _spriteBatch, float x, float y, int BoardWidth, int BoardHeight)
        {
            // Definimos qué parte del sprite queremos (x, y, ancho, alto)
            Rectangle fuente = new Rectangle(345 + 610, 430, 240, 190);

            // Dibujamos
            _spriteBatch.Draw(
                buttonsSprite,
               new Rectangle((int)x, (int)y, BoardWidth / 10, BoardHeight / 10),
                fuente,
                Color.White
            );
        }//ficha azul.

    }
}
