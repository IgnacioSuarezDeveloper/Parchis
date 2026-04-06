using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
        public Dice(int InitX, int InitY, int Width, int Heigth, ColorChip Color) : base(InitX, InitY)
        {
            x = InitX;
            y = InitY;
            width = Width;
            heigth = Heigth;
            color = Color;
            if(color == ColorChip.red)
            {
                enable = true;
            }

        }

        public override void Draw(SpriteBatch _spriteBatch, int BoardWidth, int BoardHeight)
        {
            SpritesToTexture.DrawDice(_spriteBatch, x, y, BoardWidth, BoardHeight);
        }

        public async void Click()
        {
            //posicion del mouse.
            Vector2 mousePos = MouseHandeler.GetPos();

            //si se hace click en el dado y esta habilitado.
            if(
                mousePos.X >= this.x && mousePos.X <= this.x + this.width / 10 && 
                mousePos.Y >= this.y && mousePos.Y <= this.y + this.heigth / 10 && MouseHandeler.GetClick() && this.enable)
            {
                //se desactiva el dado
                this.enable = false;

                //se tira el dado.
                faceUp = rnd.Next(1,7);

                //delay que simula el tiempo que tarda.
                await (Task.Delay(1000));

                //muestra la cara arriba en el debug console.
                Debug.WriteLine($"dado tirado {faceUp}");

                //dado habilitado.
                this.enable = true;
            }

        }
    }
}
