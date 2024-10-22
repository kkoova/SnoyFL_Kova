using Microsoft.Xna.Framework;
using System;

namespace SnoyFL_Kova
{
    /// <summary>
    /// Класс, представляющий данные о снежинке.
    /// </summary>
    public class Snowflake
    {
        /// <summary>
        /// Позиция снежинки на экране.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Скорость падения снежинки.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Радиус снежинки.
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Статический генератор случайных чисел для снежинок.
        /// </summary>
        public readonly static Random Random = new Random();
    }
}
