using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCHIS
{
    enum ColorChip
    {
        red,
        blue,
        green,
        yellow
    }
    internal class Chip : Entity
    {
        ColorChip color;

        //heredado x;
        //heredad  y;
        //heredado X;
        //heredado Y;

        //constructor inicializa color de la ficha.
        public Chip(int xInit, int yInit, ColorChip ChipColor) : base(xInit, yInit)
        {
            color = ChipColor;
        }

        //dibuja la ficha del color que es.
        public override void Draw(SpriteBatch _spriteBatch)
        {
            if(color == ColorChip.red)
            {
                SpritesToTexture.DrawRedChip(_spriteBatch, this.x, this.y);

            }else if(color == ColorChip.green)
            {
                SpritesToTexture.DrawGreenChip(_spriteBatch, this.x, this.y);

            }else if(color == ColorChip.yellow)
            {
                SpritesToTexture.DrawYellowChip(_spriteBatch, this.x, this.y);

            }else if(color == ColorChip.blue)
            {
                SpritesToTexture.DrawBlueChip(_spriteBatch, this.x, this.y);
            }
        }
    }
}
