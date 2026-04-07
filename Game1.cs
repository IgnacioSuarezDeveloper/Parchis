using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

namespace PARCHIS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public int BoardWidth;
        private int BoardHeidth;

        private Vector2 vectorMinusButton;
        private Vector2 vectorPlusButton;
        private Vector2 vectorOkButton;
        private Vector2 MousePos;

        private SpriteFont miFuente;
        private Player[] PlayersList;
        private Dice[] DicesList;

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


        #region init(),load(),update(),Draw()
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //inicializa variables
            InitVariables();


            //carga todos los sprites usados en el juego
            SpritesToTexture.LoadSprites(Content);


            //InicializandoBotones los botones del menu.
            Menu.InitializeButtons(vectorMinusButton, vectorPlusButton, vectorOkButton);

        }

        protected override void Update(GameTime gameTime)
        {

            //para salir si se presiona escape o se hace click en la x.
            ExitGame();

            //posicion del mouse en pantalla.
            MousePos = MouseHandeler.GetPos();

            //si no se ha seleccionado numero de jugadores.
            MenuOrDiceClickDetection();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //fondo del juego.
            GraphicsDevice.Clear(Color.Brown);

            _spriteBatch.Begin();

            DrawGameOrMenu();

            _spriteBatch.End();

            base.Draw(gameTime);
           
        }
        #endregion


        #region Me Functions
        public void InitPlayerList()
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

        public void InitDiceList()
        {
            //inicializando numero de dados.
            DicesList = new Dice[Menu.NPlayers];

            //creando n dados
            for (int i = 0; i < DicesList.Length; i++)
            {
                if (i == (int)ColorChip.red || i == (int)ColorChip.yellow)
                {
                    int add = 0;
                    if (i == (int)ColorChip.yellow)
                    {
                        add = 204;
                    }
                    DicesList[i] = new Dice(PlayersList[i].Fichas[0].X - 40, PlayersList[i].Fichas[0].Y - 100 + add, BoardWidth, BoardHeidth, (ColorChip)i);
                }
                else
                {
                    int add = 0;
                    if (i == (int)ColorChip.blue)
                    {
                        add = 204;

                    }
                    DicesList[i] = new Dice(PlayersList[i].Fichas[0].X - 40, PlayersList[i].Fichas[0].Y - 100 + add, BoardWidth, BoardHeidth, (ColorChip)i);

                }
                DiceListInit = true;
            }
        }

        public void DrawAllDices()
        {
            foreach (Dice d in DicesList)
            {
                SpritesToTexture.DrawDice(_spriteBatch, d.X, d.Y, BoardWidth, BoardHeidth, 0);
            }
        }

        public void DrawAllChips()
        {
            foreach (Player p in PlayersList)
            {
                //dibuja las fichas del jugador.
                p.DrawAllChips(_spriteBatch, BoardWidth, BoardHeidth);
            }
        }

        public void DrawGameOrMenu()
        {
            //si ya hay un numero de jugadores dibuja el juego.
            if (Menu.SelectedNPlayers)
            {
                //inicializa la lista de dados y jugadores.
                InitPlayerDiceList();

                //dibujando tablero.
                SpritesToTexture.DrawBoard(_spriteBatch, 10, 10, BoardWidth, BoardHeidth);

                //dibujar los dados.
                DrawAllDices();

                //dibuja las fichas de todos los players.
                DrawAllChips();
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

        }

        public void InitPlayerDiceList()
        {
            //inicializa la lista de jugadores. 
            if (!ListInit)
            {
                //inicializar lista de jugadores.
                InitPlayerList();
            }
            if (!DiceListInit)
            {
                //inicializar lista de dados.
                InitDiceList();
            }
        }

        public void InitVariables()
        {
            //numero de jugadores minimo
            Menu.NPlayers = 2;

            //ancho y alto del tablero.
            BoardWidth = 1000;
            BoardHeidth = 1000;

            //carga sprite de letras
            miFuente = Content.Load<SpriteFont>("File");

            vectorMinusButton = new System.Numerics.Vector2((BoardWidth / 2) + (BoardWidth / 10) - buttonsOfset, (BoardHeidth / 2) - (BoardHeidth / 20));
            vectorPlusButton = new System.Numerics.Vector2((BoardWidth / 2) + (BoardWidth / 10), (BoardHeidth / 2) - (BoardHeidth / 20));
            vectorOkButton = new System.Numerics.Vector2((BoardWidth / 2) - 80, (BoardHeidth / 2) + 200);

        }

        public void MenuOrDiceClickDetection()
        {
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
                if (DicesList != null)
                {
                    foreach (Dice d in DicesList)
                    {
                        d.Click();
                    }
                }
            }
        }

        public void ExitGame()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
        }
        #endregion
    }
}
