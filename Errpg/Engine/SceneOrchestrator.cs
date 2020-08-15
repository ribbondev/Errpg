using Errpg.Game;
using System.Collections.Generic;

namespace Errpg.Engine
{
    public class SceneOrchestrator
    {
        public IScene CurrentScene {
            get => _currentScene;
            set
            {
                var initialScene = _currentScene == null;
                if (!initialScene) 
                    _currentScene.ExitStage();
                _currentScene = value;
                _currentScene.EnterStage();
                if (!initialScene)
                    _currentScene.Render();
            }
        }

        private IScene _currentScene;
        private Dictionary<SceneIdentifiers, IScene> _scenes;

        public SceneOrchestrator()
        {
            _scenes = new Dictionary<SceneIdentifiers, IScene>();
        }

        public void Switch(SceneIdentifiers sceneId)
        {
            CurrentScene = _scenes[sceneId];
        }

        public void Preload()
        {
            foreach (var scene in _scenes.Values)
            {
                scene.Preload();
            }
        }

        public void Register(IScene scene)
        {
            if (_scenes.ContainsKey(scene.SceneId))
                return;
            _scenes.Add(scene.SceneId, scene);
        }

        public void Destroy()
        {
            foreach (var scene in _scenes.Values)
            {
                scene.Destroy();
            }
        }
    }
}
