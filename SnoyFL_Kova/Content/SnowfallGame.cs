using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnoyFL_Kova
{
    /// <summary>
    /// Представляет основную логику для игры
    /// </summary>
    public class SnowfallGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D snowflakeTexture;
        private Snowflake[] snowflakes;

        /// <summary>
        /// Инициализация объекта SnowfallGame
        /// </summary>
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
            for (var i = 0; i < snowflakes.Length; i++)
            {
                snowflakes[i] = new Snowflake();
                SnowflakeBehavior.Initialize(
                    snowflakes[i],
                    graphics.PreferredBackBufferWidth,
                    graphics.PreferredBackBufferHeight
                    );
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
        /// <param name="gameTime">Время, прошедшее с последнего обновления</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var snowflake in snowflakes)
            {
                SnowflakeBehavior.Update(
                    snowflake,
                    graphics.PreferredBackBufferWidth,
                    graphics.PreferredBackBufferHeight
                    );
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Рисование снежинок
        /// </summary>
        /// <param name="gameTime">Время отрисовки</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach (var snowflake in snowflakes)
            {
                SnowflakeBehavior.Draw(
                    spriteBatch,
                    snowflake,
                    snowflakeTexture
                    );
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
