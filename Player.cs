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

        public Player(ColorChip _color, int BoardWidth, int BoardHeight)
        {
            //fichas del jugador.
            fichas = new Chip[4];

            //color jugador.
            color = _color;

            //espacio entre fichas al inicializar.
            int InitChipSeparation = 55;

            //Inicializando las de fichas del jugador dandole pos x y pos y.

            /*y arriba 333 - (333 / 2) rojo verde
            y abajo 333 * 3 - (333/2); amarillo azul

            x izquierda 333 - (333 / 2) rojo amarillo
            x derecha 333 * 3 - (333/2); verde azul*/

            int xinit = Math.Abs(BoardWidth / 3);
            int yinit = Math.Abs(BoardHeight / 3);
            

            for (int i = 0; i < fichas.Length; i++)
            {
                if((int)color % 2 == 0)
                {
                    //fichas roja verde Posicion inicial.
                    fichas[i] = new Chip((xinit / 2 - 100) + ((int)color * (xinit - 30) )  +  i * InitChipSeparation, yinit / 2, _color);
                }
                else
                {
                    //fichas amarilla azul Posicion inicial.
                    fichas[i] = new Chip((xinit / 2 - 100) + (((int)color - 1) * (xinit - 30)) + i * InitChipSeparation, (yinit + 50) * 2, _color);
                }
            }






        }

        public void DrawAllChips(SpriteBatch _spriteBatch, int BoardWidth, int BoardHeigth)
        {
            //dibujar la ficha verde.
            for (int i = 0; i < 4; i++)
            {
                if (fichas[i] != null)
                {
                    fichas[i].Draw(_spriteBatch,BoardWidth, BoardHeigth);
                }
            }
        }
    }
}
