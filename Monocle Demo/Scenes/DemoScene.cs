using Demo.Components;
using Monocle;
using Monocle.UI;

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
            Manager.DefaultFont = new BitmapFont(MTexture.FromFile(Path.Combine("Content", "windows.png")), 12, 20);

            Manager ui = new Manager();
            ui.Tag = BitTag.Get("ui");
            Add(ui);

            TabPanel tab = new TabPanel();

            StackPanel panel = new StackPanel();
            panel.Border = 0;
            StackPanel panel2 = new StackPanel(Orientation.Horizontal) { Border = 0 };
            StackPanel panel3 = new StackPanel(Orientation.Horizontal) { Border = 0 };
            StackPanel panel4 = new StackPanel(Orientation.Horizontal)
            {
                Border = 0,
                ExpandElements = false
            };

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
            Button b = new Button($"very very very big test bingus");
            b.OnClick += () => { b.Text = "clicked!"; };
            panel.Add(b);

            panel.Add(panel2);
            panel.Add(new Splitter(Orientation.Horizontal));
            panel.Add(panel3);

            Button button = new Button("Push Panel");
            button.OnClick += AddWindow;
            panel.Add(button);

            //panel.Add(panel4);
            StackPanel panel5 = new StackPanel();
            panel5.Add(panel4);
            panel5.Border = 0;
            tab.AddTab(panel, "Main Panel");

            TabPanel tab2 = new TabPanel();
            tab2.AddTab(new StackPanel(), "nested1");
            tab2.AddTab(new StackPanel(), "nested2");
            //tab.AddTab(tab2, "nestedtab");
            //tab.AddTab(panel5, "Other");

            SplitPanel split = new SplitPanel(tab, tab2, 0.5f, Orientation.Horizontal);

            ui.Add(new Window(split) { Width = 1000, Height = 900, Alignment = WindowAlignment.Center });
        }

        private void AddWindow()
        {
            StackPanel panel = new StackPanel();
            Button button = new Button("Push Panel");
            button.OnClick += () => AddWindow();

            Button button2 = new Button("Pop Panel");
            button2.OnClick += () => Manager.Instance.Pop();

            panel.Add(button);
            panel.Add(button2);
            Manager.Instance.Push(new Window(panel) { Width = 300 - Manager.Instance.Depth * 10, Height = 220 - Manager.Instance.Depth * 10, Alignment = WindowAlignment.Center });
        }
    }
}
