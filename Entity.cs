using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCHIS
{
    //Clase de la que heredaran dado
    //ficha
    internal abstract class Entity
    {
        //posicion en x e y.

        protected int x;

        protected int y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Entity(int InitX, int InitY)
        {
            //inicializando x.

            x = InitX;

            //inicializando y.

            y = InitY;
        }

        //metodo para dibujar.
        public abstract void Draw(SpriteBatch _spriteBatch, int BoardWidth, int BoardHeight);
    }
}
