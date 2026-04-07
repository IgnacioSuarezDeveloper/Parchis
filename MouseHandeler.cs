using Microsoft.Xna.Framework.Input;
using System.Numerics;

namespace PARCHIS
{
    internal static class MouseHandeler
    {
        //estado del mouse.
        static MouseState mouseState = new MouseState();

        //posicion del mouse.
        static Vector2 pos = new Vector2();

        //obtiene la posicion del raton en x e y.
        static public Vector2 GetPos()
        {
            mouseState = Mouse.GetState();
            return new Vector2(mouseState.X, mouseState.Y);
        }

        //click mouse?
        static public bool GetClick()
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else return false;
        }
    }
}
