using Errpg.Engine;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Errpg.Game.Scenes
{
    public class EnterScene : IScene
    {
        private SceneOrchestrator _sceneOrchestrator;
        public SceneIdentifiers SceneId => SceneIdentifiers.EnterScene;

        public EnterScene(SceneOrchestrator sceneOrchestrator)
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
            if (IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
            {
                _sceneOrchestrator.Switch(SceneIdentifiers.WorldScene);
                return;
            }

            DrawText("In a perfect world, games like me would not exist", 10, 10, 20, Color.PURPLE);
        }
    }
}
