using Errpg.Engine;
using Errpg.Game.Scenes;
using static Errpg.Support.Ioc;

namespace Errpg.Game
{
    public class SceneConfiguration
    {
        private SceneOrchestrator _sceneOrchestrator;
        public SceneConfiguration(SceneOrchestrator sceneOrchestrator)
        {
            _sceneOrchestrator = sceneOrchestrator;
        }

        public void Run()
        {
            var initialScene = Container.GetInstance<HelloWorldScene>();
            _sceneOrchestrator.Register(initialScene);
            _sceneOrchestrator.Register(Container.GetInstance<EnterScene>());
            _sceneOrchestrator.Register(Container.GetInstance<WorldScene>());
            _sceneOrchestrator.CurrentScene = initialScene;
        }
    }
}
