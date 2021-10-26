using System.ServiceProcess;
using System.Threading;

namespace YilDonumKutlama.WinServis
{
    static class Program
    {
              /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new BulutTahsilatService()
            //};
            //ServiceBase.Run(ServicesToRun);

#if DEBUG

            var main = new Service1();
            main.OnDebug();
            Thread.Sleep(Timeout.Infinite);
#else
             ServiceBase[] ServicesToRun;
             ServicesToRun = new ServiceBase[]
             {
                 new ClientControlService()
             };
             ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
