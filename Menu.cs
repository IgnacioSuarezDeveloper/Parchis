using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PARCHIS
{
    internal static class Menu
    {
        

        private static bool selectedNPlayers;
        private static int Nplayers;
        private static Vector2 MinusButtonPositionxy;
        private static Vector2 MaxButtonPositionxy;
        private static Entity[] buttons;

        public static Vector2 MInusButtonPositionxy
        {
            get { return MinusButtonPositionxy; }
        }

        public static Vector2 MAxButtonPositionxy
        {
            get { return MaxButtonPositionxy; }
        }

        public static int NPlayers
        {
            get { return Nplayers; }
            set
            {
                if(value >= 1 && value <= 4)
                {
                    Nplayers = value;
                }
                else
                {
                    throw new Exception("number of players not abailable.");
                }
            }
        }

        public static bool SelectedNPlayers
        {
            get { return selectedNPlayers; }
        }

        public static void InitializeButtons(Vector2 Mxy, Vector2 Pxy)
        {
            buttons = new Entity[2];
            MinusButtonPositionxy = Mxy;
            MaxButtonPositionxy = Pxy;
        }
    }
}
