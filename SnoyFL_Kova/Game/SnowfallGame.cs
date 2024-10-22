using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnoyFL_Kova
{
    /// <summary>
    /// </summary>
    public class SnowfallGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D snowflakeTexture;
        private Snowflake[] snowflakes;

        public SnowfallGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        /// <summary>
        /// Иницилизация снежинок
        /// </summary>
        protected override void Initialize()
        {
            snowflakes = new Snowflake[200];
            for (int i = 0; i < snowflakes.Length; i++)
            {
                snowflakes[i] = new Snowflake(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }

            base.Initialize();
        }

        /// <summary>
        /// Создание текстуры для снежинки
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snowflakeTexture = new Texture2D(GraphicsDevice, 1, 1);
            snowflakeTexture.SetData(new[] { Color.White });
        }

        /// <summary>
        /// Обновление снежинок
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var snowflake in snowflakes)
            {
                snowflake.Update(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Рисование снежинок
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach (var snowflake in snowflakes)
            {
                snowflake.Draw(spriteBatch, snowflakeTexture);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
