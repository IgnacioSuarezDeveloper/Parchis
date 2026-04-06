using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography.X509Certificates;


namespace PARCHIS
{
    internal static class TextDrawer
    {
        //textura de las letras .png.
        static Texture2D lettersTexture;
        
        //textura de las letras geter
        public static Texture2D LettersTexture
        {
            get { return lettersTexture; }
        }


        //cargar la textura de letras
        public static void LoadLettersTexture(ContentManager Content)
        {
            lettersTexture = Content.Load<Texture2D>("letras.png");
        }


        //dibujar todas las letras.
        public static void DrawLettersTexture(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(lettersTexture, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
        }


        //dibuja el texto elegido.
        public static void DrawText(SpriteBatch _spriteBatch, string texto)
        {
            int width = 200;
            int height = 200;

            texto = texto.ToUpper();

            CutLetter(_spriteBatch, texto, width, height, 0,0);
        }


        //dibujar el texto.
        public static void DrawTextUpdate(SpriteBatch spriteBatch, Texture2D spriteSheet, string text, Vector2 position, int letterSize = 200)
        {
            int columns = spriteSheet.Width / letterSize;

            for (int i = 0; i < text.Length; i++)
            {
                char c = char.ToUpper(text[i]);

                // Ignorar espacios
                if (c == ' ')
                    continue;

                // Convertir letra a índice (A=0, B=1...)
                int index = c - 'A';

                if (index < 0 || index > 25)
                    continue; // ignora caracteres raros

                // Calcular fila y columna
                int col = index % columns;
                int row = index / columns;

                // Rectángulo de recorte
                Rectangle sourceRect = new Rectangle(
                    col * letterSize,
                    row * letterSize,
                    letterSize,
                    letterSize
                );

                // Posición en pantalla
                Vector2 drawPos = new Vector2(
                    position.X + (i * letterSize),
                    position.Y
                );

                spriteBatch.Draw(spriteSheet, drawPos, sourceRect, Color.White);
            }
        }


        //corta letras del sprite segun el texto elegido.
        private static void CutLetter(SpriteBatch _spriteBatch, string text, int letterOriginalWidth, int letterOriginalHeight , int posOfTextY, int posOfTextX) 
        {
            int count = 0;
            int Y = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int ind = text[i] - 65;

                if (ind >= 0 && ind <= 5)
                {
                   
                    Y = 0;
                }else if(ind >= 6 && ind <= 10)
                {
                    ind = ind - 5;
                    Y = 1;
                }else if(ind >= 11 && ind <= 15)
                {
                    ind = ind - 10;
                    Y = 2;
                }else if(ind >= 16 && ind <= 20)
                {
                    ind = ind - 15;
                    Y = 3;
                }else if (ind >= 21 && ind <= 25)
                {
                    ind = ind - 20;
                    Y = 4;
                }

                    // Definimos qué parte del sprite queremos (x, y, ancho, alto)
                    Rectangle fuente = new Rectangle(ind * letterOriginalWidth, Y * letterOriginalHeight, letterOriginalWidth, letterOriginalHeight);

                // Dibujamos
                _spriteBatch.Draw
                    (
                        lettersTexture,
                        new Rectangle((((i - (6 * count)) * letterOriginalWidth / 2 )  + posOfTextX),  posOfTextY + (count * letterOriginalHeight), letterOriginalWidth / 2, letterOriginalHeight / 2), fuente,
                        Color.White
                    );

                if (i % 5 == 0 && i != 0)
                {
                    count++;
                }
            }
        }
    }
}
