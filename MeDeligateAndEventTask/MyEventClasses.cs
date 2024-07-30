using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDeligateAndEventTask
{
    public class MyEventClassPublisher
    {
        public delegate bool MyEventHandler (object sender, FileArgs e);
        public event MyEventHandler? MyEvent;

        public void ScanDirectory(string directory, string fileName)
        {
            try
            {
                var allFiles = Directory.GetFiles(directory, fileName, SearchOption.AllDirectories);

                foreach (var file in allFiles)
                {
					IAsyncResult? resultObj = MyEvent?.BeginInvoke(this, new FileArgs(directory, file), null, null);
					bool? result = MyEvent?.EndInvoke(resultObj);
					if (result.GetValueOrDefault())
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
        public bool DisplayMessage(object sender, FileArgs args)
        {
            Console.WriteLine($"\nВ директории ({args.Directory}) найден файл - ({args.FileName})");
            Console.WriteLine("Продолжить поиск? (N - нет)");
            return Console.ReadLine()?.ToLower() == "n";
		}
    }
}
