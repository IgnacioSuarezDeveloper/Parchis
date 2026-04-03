using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PARCHIS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player [] PlayersList;
        private int BoardWidth;
        private int BoardHeidth;


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

            //carga sprite.png entero.
            SpritesToTexture.LoadFullSprite(Content);

            BoardWidth = 1000;
            BoardHeidth = 1000;

            int buttonsOfset = 300;

            Menu.InitializeButtons(new System.Numerics.Vector2((BoardWidth / 2) + (BoardWidth / 10) - buttonsOfset , (BoardHeidth / 2) - (BoardHeidth / 20) ), new System.Numerics.Vector2(( BoardWidth / 2 ) + (BoardWidth / 10), (BoardHeidth / 2) - (BoardHeidth / 20)));

            //Inicializar lista de 4 jugadores.
            PlayersList = new Player[4];

            for(int i = 0; i < PlayersList.Length; i++)
            {
                PlayersList[i] = new Player((ColorChip)i, BoardWidth,BoardHeidth);
            }

            //Inicializar Dado.

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Brown);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            
            //dibujando tablero.
            SpritesToTexture.DrawBoard(_spriteBatch, 10, 10, BoardWidth, BoardHeidth);


            //dibuja las fichas de todos los players.

            foreach(Player p in PlayersList)
            {
                p.DrawAllChips(_spriteBatch, BoardWidth, BoardHeidth);
            }

            //SpritesToTexture.DrawFullButtonsSprite(_spriteBatch);

            SpritesToTexture.DrawLeftButton(_spriteBatch,Menu.MInusButtonPositionxy.X, Menu.MInusButtonPositionxy.Y, BoardWidth, BoardHeidth);
            SpritesToTexture.DrawRightButton(_spriteBatch, Menu.MAxButtonPositionxy.X, Menu.MAxButtonPositionxy.Y, BoardWidth, BoardHeidth);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
