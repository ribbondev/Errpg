using Errpg.Game;

namespace Errpg.Engine
{
    public interface IScene
    {
        public SceneIdentifiers SceneId { get; }
        public void Render();

        // optional
        public void Preload() {}
        public void EnterStage() {}
        public void ExitStage() {}
        public void Destroy() {}
    }
}
