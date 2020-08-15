using Errpg.Engine;
using Errpg.Game;
using Errpg.Game.Scenes;
using Errpg.Support;
using Singularity;

namespace Errpg.Support
{
    public static class Ioc
    {
        public static Container Container = new Container(builder =>
        {
            builder.Register<ILogger, Logger>(x => x.With(Lifetimes.PerContainer));
            builder.Register<EngineOrchestrator, EngineOrchestrator>(x => x.With(Lifetimes.PerContainer));
            builder.Register<SceneOrchestrator, SceneOrchestrator>(x => x.With(Lifetimes.PerContainer));
            builder.Register<SceneConfiguration, SceneConfiguration>(x => x.With(Lifetimes.PerContainer));

            builder.Register<HelloWorldScene, HelloWorldScene>(x => x.With(Lifetimes.PerContainer));
            builder.Register<EnterScene, EnterScene>(x => x.With(Lifetimes.PerContainer));
            builder.Register<WorldScene, WorldScene>(x => x.With(Lifetimes.PerContainer));
        });
    }
}
