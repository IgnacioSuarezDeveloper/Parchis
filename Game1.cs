using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PARCHIS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player [] PlayersList;


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


            //Inicializar lista de 4 jugadores.
            PlayersList = new Player[4];

            for(int i = 0; i < PlayersList.Length; i++)
            {
                PlayersList[i] = new Player((ColorChip)i, 100,100);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            
            //dibujando tablero.
            SpritesToTexture.DrawBoard(_spriteBatch, 10, 10);


            //dibuja las fichas de todos los players.

            foreach(Player p in PlayersList)
            {
                p.DrawAllChips(_spriteBatch);
            }
            
            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
