using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle
{
    public static class Extensions
    {
        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2(point.X, point.Y);
        }

        public static Point ToPoint(this Vector2 vec)
        {
            return new Point((int)vec.X, (int)vec.Y);
        }

        /// <summary>
        /// Expects HSV in 0-255 range and returns an RGB Color.
        /// 
        /// https://stackoverflow.com/a/14733008/8952915
        /// </summary>
        public static Color FromHsv(int h, int s, int v)
        {
            int region, rem, p, q, t;
            if (s == 0)
            {
                return new Color(v, v, v);
            }
            region = h / 43;
            rem = (h - region * 43) * 6;

            p = v * (255 - s) >> 8;
            q = (v * (255 - ((s * rem) >> 8))) >> 8;
            t = (v * (255 - ((s * (255 - rem)) >> 8))) >> 8;
            switch (region)
            {
                case 0:
                    return new Color(v, t, p);
                case 1:
                    return new Color(q, v, p);
                case 2:
                    return new Color(p, v, t);
                case 3:
                    return new Color(p, q, v);
                case 4:
                    return new Color(t, p, v);
                default:
                    return new Color(v, p, q);
            }
        }
    }
}
