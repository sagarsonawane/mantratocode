using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace WinServTopShelf
{
    public class WinTopShelf
    {
        Timer timer;

        public WinTopShelf()
        {
            timer = new Timer();            
        }

        private void DoWork(object sender, ElapsedEventArgs e)
        {
            using (var writer = new StreamWriter(@"C:\TopShelf\task.txt", true))
            {
                writer.WriteLine(DateTime.Now + " Topshelf has made windows service development very easy");
            }
        }

        public void Start()
        {
            timer.Interval = 60000;
            timer.Elapsed += new ElapsedEventHandler(DoWork);
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }        
    }
}
