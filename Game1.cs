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
        private SpriteFont miFuente;
        int numero = 2;
        private Player [] PlayersList;
        private int BoardWidth;
        private int BoardHeidth;
        bool llamado = false;
        int nPlayers;
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
            nPlayers = 2;
            miFuente = Content.Load<SpriteFont>("File");
            //carga sprite.png entero.

            SpritesToTexture.LoadFullSprite(Content);

            //ancho y alto del tablero.

            BoardWidth = 1000;
            BoardHeidth = 1000;

            //distancia entre los botones.

            int buttonsOfset = 300;

            //dibujando el boton.

            Menu.InitializeButtons(new System.Numerics.Vector2((BoardWidth / 2) + (BoardWidth / 10) - buttonsOfset , (BoardHeidth / 2) - (BoardHeidth / 20) ), new System.Numerics.Vector2(( BoardWidth / 2 ) + (BoardWidth / 10), (BoardHeidth / 2) - (BoardHeidth / 20)));

            //Inicializar lista de 4 jugadores.

            PlayersList = new Player[4];

            //creando 4 jugadores con sus fichas.

            for(int i = 0; i < PlayersList.Length; i++)
            {
                PlayersList[i] = new Player((ColorChip)i, BoardWidth,BoardHeidth);
            }

            //Inicializar Dado.
            

        }


        protected override void Update(GameTime gameTime)
        {
            //para salir si se presiona escape o se hace click en la x.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //prueba a mover la ficha del jugador.
            /*if (!llamado)
            {
                MoveChip();
                llamado = true;
            }*/
            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            //fondo del juego.
            GraphicsDevice.Clear(Color.Brown);

            _spriteBatch.Begin();

            // TODO: Add your drawing code here

            Menu.SelectedNPlayers = false;

            //si ya hay un numero de jugadores dibuja el juego.

            if (Menu.SelectedNPlayers)
            {
                //dibujando tablero.

                SpritesToTexture.DrawBoard(_spriteBatch, 10, 10, BoardWidth, BoardHeidth);

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

                _spriteBatch.DrawString(miFuente, nPlayers.ToString(), new Vector2(BoardWidth / 2, (BoardHeidth / 2) - 30), Color.White);



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
    }
}
