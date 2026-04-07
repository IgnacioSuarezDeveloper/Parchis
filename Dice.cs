using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;

namespace PARCHIS
{
    internal class Dice : Entity
    {
        int width;

        int heigth;

        int faceUp;

        bool enable;

        public bool Enable
        {
            get { return enable; }
        }

        public int FaceUp
        {
            get { return faceUp; }
        }

        public static Random rnd = new Random();

        ColorChip color;
        private int sixesInRow;

        public Dice(int InitX, int InitY, int Width, int Heigth, ColorChip Color) : base(InitX, InitY)
        {
            x = InitX;
            y = InitY;
            width = Width;
            heigth = Heigth;
            color = Color;
            if (color == ColorChip.red)
            {
                enable = true;
            }

        }

        public override void Draw(SpriteBatch _spriteBatch, int BoardWidth, int BoardHeight)
        {
            SpritesToTexture.DrawDice(_spriteBatch, x, y, BoardWidth, BoardHeight, 0);
        }

        public bool Click()
        {
            //posicion del mouse.
            Vector2 mousePos = MouseHandeler.GetPos();

            //si se hace click en el dado y esta habilitado.
            if (
                mousePos.X >= this.x && mousePos.X <= this.x + this.width / 10 &&
                mousePos.Y >= this.y && mousePos.Y <= this.y + this.heigth / 10 && MouseHandeler.GetClick() && this.enable)
            {
                //se desactiva el dado
                this.enable = false;

                //se tira el dado.
                faceUp = rnd.Next(1, 7);

                //muestra la cara arriba en el debug console.
                Debug.WriteLine($"dado tirado {faceUp}");

                //dado habilitado.
                if (faceUp == 6)
                {
                    this.enable = true;
                    sixesInRow++;
                }
                else
                {
                    this.enable = false;
                    sixesInRow = 0;
                }
                return true;
            }
            else { return false; }


        }

        public void Animation(SpriteBatch _spriteBatch, int BoardWidth, int BoardHeigth, bool inDraw)
        {
            if (inDraw)
            {
                for (int x = 0; x < 6; x++)
                {
                    SpritesToTexture.DrawDice(_spriteBatch, this.x + 200, this.y + 200, BoardWidth, BoardHeigth, (x * (SpritesToTexture.DIcesSprite.Width - 950) + 50));
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
