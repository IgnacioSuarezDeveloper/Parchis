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
        protected int x;
        protected int y;
        
        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Entity(int InitX, int InitY)
        {
            //inicializando x.
            x = InitX;

            //inicializando y.
            y = InitY;
        }

        public abstract void Draw(SpriteBatch _spriteBatch);
    }
}
