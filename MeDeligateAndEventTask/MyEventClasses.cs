using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDeligateAndEventTask
{
    public class MyEventClassPublisher
    {
        public delegate void MyEventHandler (object sender, FileArgs e);
        public event MyEventHandler? MyEvent;

        public void ScanDirecory(string directory, string fileName)
        {
            try
            {
                var allFiles = Directory.GetFiles(directory, fileName, SearchOption.AllDirectories);

                foreach (var file in allFiles)
                {
                    MyEvent?.Invoke(this, new FileArgs(directory, file));
                    var isContinue = Console.ReadLine();

                    if (isContinue.ToLower() == "n")
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Во время обработки переданных данных произошло следующее");
                Console.WriteLine(ex.Message.ToString());
            }

        }
    }

    public class MyEventClassSubscriber
    {
        public void DisplayMessage(object sender, FileArgs args)
        {
            Console.WriteLine($"\nВ директории ({args.Directory}) найден файл - ({args.FileName})");
            Console.WriteLine("Продолжить поиск? (N - нет)");
        }
    }
}
