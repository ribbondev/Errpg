using Errpg.Engine;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Errpg.Game.Scenes
{
    public class HelloWorldScene : IScene
    {
        private SceneOrchestrator _sceneOrchestrator;
        public SceneIdentifiers SceneId => SceneIdentifiers.HelloWorldScene;

        public HelloWorldScene(SceneOrchestrator sceneOrchestrator)
        {
            _sceneOrchestrator = sceneOrchestrator;
        }

        public void Destroy()
        {
        }

        public void EnterStage()
        {
        }

        public void ExitStage()
        {
        }

        public void Preload()
        {
        }

        public void Render()
        {
            if (IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                _sceneOrchestrator.Switch(SceneIdentifiers.EnterScene);
                return;
            }

            DrawText("Hello, world!", 10, 10, 20, Color.PURPLE);
        }
    }
}
