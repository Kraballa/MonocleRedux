using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monocle.UI
{
    public delegate void TextBoxSelected();
    public delegate void TextBoxChanged();

    public class TextBox : Element
    {
        public string Text { get; set; }
        public bool Selected { get; set; }

        public int TextPadding = 6;

        private static List<TextBox> Boxes = new List<TextBox>();

        private int MaxTextLength => (int)(Width / Manager.DefaultFont.CharWidth) - 1;

        public event TextBoxSelected OnSelected;
        public event TextBoxChanged OnChanged;

        public TextBox(string text = "") : base()
        {
            Text = text;
            Boxes.Add(this);
            OnClick += () =>
            {
                Boxes.ForEach((b) => b.Selected = false);
                Selected = true;
                OnSelected?.Invoke();
            };
        }

        ~TextBox()
        {
            Boxes.Remove(this);
        }

        public override void Update()
        {
            base.Update();
            if (!Selected)
                return;

            bool changed = false;
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (MInput.Keyboard.Pressed(key))
                {
                    if (key == Keys.Back)
                    {
                        if (Text.Length > 0)
                        {
                            if (MInput.Keyboard.Check(Keys.LeftControl))
                            {
                                int currentIndex = Text.Length - 1;
                                while (currentIndex > 0 && Text[currentIndex] != ' ')
                                {
                                    currentIndex--;
                                }
                                Text = Text.Substring(0, currentIndex);
                            }
                            else
                            {
                                Text = Text.Substring(0, Text.Length - 1);
                            }
                        }
                    }
                    else if (Text.Length < MaxTextLength)
                    {
                        //all keys that add characters here
                        switch (key)
                        {
                            default:
                                if (key.ToString().Length == 1)
                                {
                                    if (MInput.Keyboard.Check(Keys.LeftShift) || MInput.Keyboard.Check(Keys.RightShift))
                                        Text += key.ToString();
                                    else
                                        Text += key.ToString().ToLower();
                                }
                                break;
                            case Keys.Back:

                                break;
                            case Keys.Space:
                                Text += " ";
                                break;
                        }
                    }
                    changed = true;
                }
            }
            if (changed)
            {
                OnChanged?.Invoke();
            }

            if (MInput.Keyboard.Pressed(Keys.Escape))
            {
                Selected = false;
            }
        }

        public override void Render()
        {
            base.Render();
            Draw.Rect(Position, Width, Height, Color.White);
            if (Selected)
            {
                Draw.HollowRect(Position, Width, Height, Color.DarkBlue);
                Draw.HollowRect(Position + Vector2.One, Width - 2, Height - 2, Color.CadetBlue);
            }
            else
            {
                Draw.HollowRect(Position, Width, Height, Color.Gray);
            }
            Vector2 textPos = Position + new Vector2(TextPadding, Height / 2);
            Vector2 justify = new Vector2(0, 0.5f);
            Draw.TextJustify(Manager.DefaultFont, Text, textPos, justify, Color.Black);

            float width = Manager.DefaultFont.MeasureString(Text).X + TextPadding + 1;
            if (Selected)
            {
                Draw.Line(Position + new Vector2(width, 4), Position + new Vector2(width, Height - 4), Color.Black);
            }
        }
    }
}
