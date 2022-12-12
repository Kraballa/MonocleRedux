using Demo.Components;
using Microsoft.Xna.Framework;
using Monocle;
using Monocle.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Scenes
{
    public class DemoScene : Scene
    {
        public DemoScene() : base()
        {
            Add(new SingleTagRenderer(BitTag.Get("ui")));

            Entity ent = new Entity() { Tag = BitTag.Get("ui") };
            ent.Add(new ScreenMeasurer());
            Add(ent);



            Manager.Mouse = new VirtualButton(new VirtualButton.MouseLeftButton());

            Manager ui = new Manager();
            ui.Tag = BitTag.Get("ui");
            Add(ui);

            StackPanel panel = new StackPanel();
            panel.Border = 0;
            panel.ExpandElements = true;
            StackPanel panel2 = new StackPanel(Orientation.Horizontal) { Border = 0 };
            StackPanel panel3 = new StackPanel(Orientation.Horizontal) { Border = 0 };
            StackPanel panel4 = new StackPanel(Orientation.Horizontal) { Border = 0 };
            StackPanel panel5 = new StackPanel(Orientation.Horizontal) { Border = 0 };

            for (int i = 0; i < 2; i++)
            {
                panel2.Add(new Button($"test{i}"));
            }
            for (int i = 0; i < 4; i++)
            {
                panel3.Add(new Button($"test{i}"));
            }
            for (int i = 0; i < 3; i++)
            {
                panel4.Add(new Button($"test{i}"));
            }
            panel5.Add(new Button($"very very very big test bingus"));

            panel.Add(panel2);
            panel.Add(panel3);
            panel.Add(panel4);
            panel.Add(panel5);
            ui.Add(new Window(panel) { Width = 400, Height = 400, Position = new Vector2(Engine.Width / 2 - 400 / 2, Engine.Height / 2 - 400 / 2) });
        }
    }
}
