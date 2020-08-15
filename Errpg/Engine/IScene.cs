using Errpg.Game;

namespace Errpg.Engine
{
    public interface IScene
    {
        public SceneIdentifiers SceneId { get; }
        public void Preload();
        public void EnterStage();
        public void ExitStage();
        public void Render();
        public void Destroy();
    }
}
