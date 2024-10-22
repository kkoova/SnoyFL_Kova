using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace SnoyFL_Kova
{
    public class Snowflake
    {
        public Vector2 Position;
        public float Speed;
        public float Radius;

        private static readonly Random random = new Random();

        /// <summary>
        /// Случайное начальное положение и скорость
        /// </summary>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        public Snowflake(int screenWidth, int screenHeight)
        {
            Position = new Vector2(random.Next(screenWidth), random.Next(-screenHeight, 0));
            Speed = (float)random.NextDouble() * 2 + 1;
            Radius = (float)random.NextDouble() * 3 + 2;
        }

        /// <summary>
        /// Обновление снежинок
        /// </summary>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        public void Update(int screenWidth, int screenHeight)
        {
            Position.Y += Speed;

            if (Position.Y > screenHeight)
            {
                Position.Y = 0;
                Position.X = random.Next(screenWidth);
            }
        }

        /// <summary>
        /// Рисуем снежинку
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="texture"></param>
        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, 
                Position, null, Color.White, 
                0f, Vector2.Zero, Radius / texture.Width, 
                SpriteEffects.None, 0f);
        }
    }
}
