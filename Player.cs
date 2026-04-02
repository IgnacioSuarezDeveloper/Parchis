using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCHIS
{
    //para crear cada jugador de la partida con sus fichas del mismo color que el jugador.
    internal class Player
    {
        //fichas.
        Chip [] fichas;
        ColorChip color;

        public Chip [] Fichas
        {
            get { return fichas; }
        }

        public Player(ColorChip _color, int xInit, int yInit)
        {
            //fichas del jugador.
            fichas = new Chip[4];

            //color jugador.
            color = _color;

            int InitChipSeparation = 55;

            //Inicializando las  de fichas del jugador dandole pos x y pos y.
            for (int i = 0; i < fichas.Length; i++)
            {
                fichas[i] = new Chip(xInit + i * InitChipSeparation, yInit * (int)color, _color);
            }

        }

        public void DrawAllChips(SpriteBatch _spriteBatch)
        {
            //dibujar la ficha verde.
            for (int i = 0; i < 4; i++)
            {
                fichas[i].Draw(_spriteBatch);
            }
        }
    }
}
