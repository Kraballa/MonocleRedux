using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Monocle
{
    public class BitmapFont
    {
        public Dictionary<int, MTexture> CharacterMap = new Dictionary<int, MTexture>();
        public int CharWidth { get; private set; }
        public int CharHeight { get; private set; }
        public int NewlineOffset { get; private set; } = 4;

        /// <summary>
        /// Bitmap font wrapper. Maps chars onto their ascii equivalent, depending on the image source.
        /// 
        /// I can recommend using tilemaps from "https://dwarffortresswiki.org/index.php/Tileset_repository"
        /// as they mostly work with all keys on common keyboards. You just have to remove the pink background.
        /// </summary>
        /// <param name="source">An image</param>
        /// <param name="charWidth">with of a character</param>
        /// <param name="charHeight">height of a character</param>
        /// <param name="xChars">number of characters per row</param>
        public BitmapFont(MTexture source, int charWidth, int charHeight, int xChars = 16)
        {
            CharWidth = charWidth;
            CharHeight = charHeight;
            int index = 0;

            int y = 0;
            while (y * CharHeight < source.Height)
            {
                for (int x = 0; x < xChars; x++)
                {
                    CharacterMap.Add(index, new MTexture(source, x * CharWidth, y * CharHeight, charWidth, charHeight));
                    index++;
                }
                y++;
            }
        }

        public void DrawString(string text, int x, int y)
        {
            string[] split = text.Split('\n');
            for (int line = 0; line < split.Length; line++)
            {
                for (int i = 0; i < split[line].Length; i++)
                {
                    CharacterMap[split[line][i]].Draw(new Vector2(x + i * CharWidth, y + line * (CharHeight + 1)));
                }
            }
        }

        public void DrawString(string text, Vector2 pos)
        {
            DrawString(text, (int)pos.X, (int)pos.Y);
        }

        public void DrawString(string text, int x, int y, Color color)
        {
            string[] split = text.Split('\n');
            for (int line = 0; line < split.Length; line++)
            {
                for (int i = 0; i < split[line].Length; i++)
                {
                    CharacterMap[split[line][i]].Draw(new Vector2(x + i * CharWidth, y + line * (CharHeight + NewlineOffset)), Vector2.Zero, color);
                }
            }
        }

        public void DrawString(string text, Vector2 pos, Color c)
        {
            DrawString(text, (int)pos.X, (int)pos.Y, c);
        }

        public void DrawStringFmt(string text, int x, int y, params Color[] c)
        {
            Color currentColor = Color.White;
            bool inside = false;
            int colorIndex = 0;
            string[] split = text.Split('\n');
            for (int line = 0; line < split.Length; line++)
            {
                int charCount = 0;
                for (int i = 0; i < split[line].Length; i++)
                {
                    if (split[line][i] == '|')
                    {
                        if (!inside)
                        {
                            currentColor = c[colorIndex];
                            inside = true;
                        }
                        else
                        {
                            colorIndex++;
                            currentColor = Color.White;
                            inside = false;
                        }
                    }
                    else
                    {
                        CharacterMap[split[line][i]].Draw(new Vector2(x + charCount * CharWidth, y + line * (CharHeight + 1)), Vector2.Zero, currentColor);
                        charCount++;
                    }
                }
            }
        }

        public Vector2 MeasureString(string text)
        {
            string[] split = text.Split('\n');
            int width = 0;
            int height = CharHeight * split.Length;
            for (int i = 0; i < split.Length; i++)
            {
                int other = split[i].Length * CharWidth;
                width = other > width ? other : width;
            }
            return new Vector2(width, height);
        }

        public Rectangle MeasureStringRect(string text)
        {
            string[] split = text.Split('\n');
            int width = 0;
            int height = CharHeight * split.Length;
            for (int i = 0; i < split.Length; i++)
            {
                int other = split[i].Length * CharWidth;
                width = other > width ? other : width;
            }
            return new Rectangle(0, 0, width, height);
        }
    }
}
