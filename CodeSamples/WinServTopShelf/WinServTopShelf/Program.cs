using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WinServTopShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(r =>
            {
                r.Service<WinTopShelf>
                          (service =>
                                  {
                                      service.ConstructUsing(instance => new WinTopShelf());
                                      service.WhenStarted(instance => instance.Start());
                                      service.WhenStopped(instance => instance.Stop());
                                  });


                r.RunAsLocalService();

                r.SetDisplayName("Topshelf facilitated service");

                r.SetDescription("This service has been created using a TopShelf open source framework for creating a windows serviecs.");
            }
            );

        }
    }
}
