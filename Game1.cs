using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace PARCHIS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont miFuente;
        private int numero = 2;
        private Player [] PlayersList;
        private Dice[] DicesList;
        private int BoardWidth;
        private int BoardHeidth;
        private Vector2 MousePos;
        private bool clickRightButton = false;
        private bool clickLeftButton = false;
        private bool clickOkButton = false;
        private int buttonsOfset = 300;
        private bool ListInit = false;
        private bool DiceListInit = false;
       

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
         
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //carga sprite de letras

            Menu.NPlayers = 2;
            miFuente = Content.Load<SpriteFont>("File");

            //carga sprite.png entero.

            SpritesToTexture.LoadSprites(Content);

            //ancho y alto del tablero.

            BoardWidth = 1000;
            BoardHeidth = 1000;

            //dibujando el boton.

            Menu.InitializeButtons(new System.Numerics.Vector2((BoardWidth / 2) + (BoardWidth / 10) - buttonsOfset , (BoardHeidth / 2) - (BoardHeidth / 20) ), new System.Numerics.Vector2(( BoardWidth / 2 ) + (BoardWidth / 10), (BoardHeidth / 2) - (BoardHeidth / 20)), new System.Numerics.Vector2((BoardWidth / 2) - 80 , (BoardHeidth / 2) + 200));



            //Inicializar Dado.

        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            //para salir si se presiona escape o se hace click en la x.

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
          
           //posicion del mouse en pantalla.

            MousePos = MouseHandeler.GetPos();

            //posicion en x en y del mouse.

            if (!Menu.SelectedNPlayers)
            {
                //clicado.
                bool cliked = MouseHandeler.GetClick();

                //boton maxcliked.
                Menu.MaxButtonClicked(cliked, MousePos, ref clickRightButton, BoardWidth, BoardHeidth);

                //boton mincliked.
                Menu.MinButtonClicked(cliked, MousePos, ref clickLeftButton, BoardWidth, BoardHeidth);

                //boton okClicked.
                Menu.OkButtonClicked(cliked, MousePos, ref clickOkButton, BoardWidth, BoardHeidth);

            }
            else
            {
                if(DicesList != null)
                {
                    foreach(Dice d in DicesList)
                    {
                        d.Click();
                    }
                }
            }


                base.Update(gameTime);
        }
       
        protected override void Draw(GameTime gameTime)
        {
            //fondo del juego.
            GraphicsDevice.Clear(Color.Brown);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here


            //si ya hay un numero de jugadores dibuja el juego.

            if (Menu.SelectedNPlayers)
            {
                //inicializa la lista de jugadores. 
                if (!ListInit)
                {
                    InitList();

                }
                if (!DiceListInit)
                {
                    //inicializar lista de dados.

                    InitDiceList();
                }



                //dibujando tablero.

                SpritesToTexture.DrawBoard(_spriteBatch, 10, 10, BoardWidth, BoardHeidth);

                //dibujar el dado
                foreach(Dice d in DicesList)
                {
                    /*if(p.Color == (ColorChip)0  || p.Color == (ColorChip)1)
                    {
                        int add = 0;
                        if(p.Color == (ColorChip)1)
                        {
                            add = 204;
                        }
                        SpritesToTexture.DrawDice(_spriteBatch, p.Fichas[0].X - 40, p.Fichas[0].Y - 100 + add, BoardWidth, BoardHeidth);

                    }
                    else
                    {
                        int add = 0;
                        if (p.Color == (ColorChip)3)
                        {
                            add = 204;
                        }
                        SpritesToTexture.DrawDice(_spriteBatch, p.Fichas[0].X - 60, p.Fichas[0].Y - 100 + add, BoardWidth, BoardHeidth);
                    }*/

                    SpritesToTexture.DrawDice(_spriteBatch, d.X, d.Y, BoardWidth, BoardHeidth);


                }

                //dibuja las fichas de todos los players.

                foreach (Player p in PlayersList)
                {
                    //dibuja las fichas del jugador.

                    p.DrawAllChips(_spriteBatch, BoardWidth, BoardHeidth);
                }
            }
            else
            {
                
                //dibuja el boton izquierdo del menu.

                SpritesToTexture.DrawLeftButton(_spriteBatch, Menu.MInusButtonPositionxy.X, Menu.MInusButtonPositionxy.Y, BoardWidth, BoardHeidth);

                //dibuja el boton derecho del menu.

                SpritesToTexture.DrawRightButton(_spriteBatch, Menu.MAxButtonPositionxy.X, Menu.MAxButtonPositionxy.Y, BoardWidth, BoardHeidth);

                //dibuja el boton de okey
                SpritesToTexture.DrawOkButton(_spriteBatch, Menu.OKButtonPositionxy.X, Menu.OKButtonPositionxy.Y, BoardWidth, BoardHeidth);


                //dibuja numero de jugadores.
                _spriteBatch.DrawString(miFuente, Menu.NPlayers.ToString(), new Vector2((BoardWidth / 2) - 10, (BoardHeidth / 2) - 60), Color.White);

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public async Task MoveChip()
        {

            //cambiando pos inicial.
            PlayersList[0].Fichas[0].X += 300;

            //bucle para actualizar la posicion ficha.
            while (true)
            {
                PlayersList[0].Fichas[0].Y += 41;
                await (Task.Delay(2000));
            }

        }

        //inicializar.
        public void InitList()
        {
            //Inicializar lista de 4 jugadores.

            PlayersList = new Player[Menu.NPlayers];

            //creando n jugadores con sus fichas.

            for (int i = 0; i < PlayersList.Length; i++)
            {
                PlayersList[i] = new Player((ColorChip)i, BoardWidth, BoardHeidth);
            }

            ListInit = true;
        }
        
        //inicializar lista de dados
        public void InitDiceList()
        {
            //inicializando numero de dados.

            DicesList = new Dice[Menu.NPlayers];

            //creando n dados

            for(int i = 0; i < DicesList.Length; i++)
            {

                if(i == (int)ColorChip.red || i == (int)ColorChip.yellow)
                {
                    int add = 0;
                    if (i == (int)ColorChip.yellow)
                    {
                        add = 204;
                    }
                    DicesList[i] = new Dice(PlayersList[i].Fichas[0].X - 40, PlayersList[i].Fichas[0].Y - 100 + add, BoardWidth, BoardHeidth,(ColorChip)i);
                }
                else
                {
                    int add = 0;
                    if(i == (int)ColorChip.blue)
                    {
                        add = 204;

                    }
                    DicesList[i] = new Dice(PlayersList[i].Fichas[0].X - 40, PlayersList[i].Fichas[0].Y - 100 + add, BoardWidth, BoardHeidth, (ColorChip)i);

                }
                DiceListInit = true;

            }
        }
    }
}
