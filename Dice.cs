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

        ColorChip color;
        public Dice(int InitX, int InitY, int Width, int Heigth, ColorChip Color) : base(InitX, InitY)
        {
            x = InitX;
            y = InitY;
            width = Width;
            heigth = Heigth;
            color = Color;

        }
        public override void Draw(SpriteBatch _spriteBatch, int BoardWidth, int BoardHeight)
        {
            SpritesToTexture.DrawDice(_spriteBatch, x, y, BoardWidth, BoardHeight);
        }

        public void Click()
        {
            //posicion del mouse.
            Vector2 mousePos = MouseHandeler.GetPos();

            if(
                mousePos.X >= this.x && mousePos.X <= this.x + this.width && 
                mousePos.Y >= this.y && mousePos.Y <= this.y - this.heigth)
            {
                Debug.WriteLine(this.color.ToString());
            }

        }
    }
}
