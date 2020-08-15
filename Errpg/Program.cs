using Errpg.Engine;
using Errpg.Support;
using System;
using static Errpg.Support.Ioc;

namespace Errpg
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = Container.GetInstance<ILogger>();
            try
            {
                var engine = Container.GetInstance<EngineOrchestrator>();
                engine.StartEngine();
            }
            catch (Exception e)
            {
                log.Write(e);
            }
        }
    }
}
