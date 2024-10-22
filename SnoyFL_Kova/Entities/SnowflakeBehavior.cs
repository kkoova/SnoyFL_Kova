using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnoyFL_Kova
{
    /// <summary>
    /// Поведение снежинки (перемещение, отрисовка).
    /// </summary>
    public static class SnowflakeBehavior
    {
        /// <summary>
        /// Инициализация снежинки с случайной позицией и скоростью
        /// </summary>
        /// <param name="snowflake">Объект снежинки для инициализации</param>
        /// <param name="screenWidth">Ширина экрана</param>
        /// <param name="screenHeight">Высота экрана</param>
        public static void Initialize(
            Snowflake snowflake,
            int screenWidth,
            int screenHeight)
        {
            snowflake.Position = new Vector2(
                Snowflake.Random.Next(screenWidth),
                Snowflake.Random.Next(-screenHeight, 0));
            snowflake.Speed = (float)Snowflake.Random.NextDouble()
                * 2
                + 1;
            snowflake.Radius = (float)Snowflake.Random.NextDouble()
                * 3
                + 2;
        }

        /// <summary>
        /// Обновление позиции снежинки, двигая её вниз
        /// </summary>
        /// <param name="snowflake">Объект снежинки</param>
        /// <param name="screenWidth">Ширина экрана</param>
        /// <param name="screenHeight">Высота экрана</param>
        public static void Update(
            Snowflake snowflake,
            int screenWidth,
            int screenHeight)
        {
            snowflake.Position = new Vector2(
                snowflake.Position.X,
                snowflake.Position.Y + snowflake.Speed);

            if (snowflake.Position.Y > screenHeight)
            {
                snowflake.Position = new Vector2(
                    Snowflake.Random.Next(screenWidth),
                    0);
            }
        }

        /// <summary>
        /// Рисование снежики
        /// </summary>
        /// <param name="spriteBatch">Контекст для отрисовки</param>
        /// <param name="snowflake">Объект снежинки</param>
        /// <param name="texture">Текстура снежинки</param>
        public static void Draw(
            SpriteBatch spriteBatch,
            Snowflake snowflake,
            Texture2D texture) => spriteBatch.Draw(
                texture,
                snowflake.Position,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                snowflake.Radius / texture.Width,
                SpriteEffects.None,
                0f);
    }
}
