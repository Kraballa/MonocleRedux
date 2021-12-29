// See https://aka.ms/new-console-template for more information

namespace Demo
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using (var core = new Core(1280, 920, 1280, 920, "Monocle Redux Demo", false))
            {
                core.Run();
            }
        }
    }
}