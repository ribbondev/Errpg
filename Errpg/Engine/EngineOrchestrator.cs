using Errpg.Game;
using Errpg.Support;
using Raylib_cs;
using System.Collections.Generic;
using static Raylib_cs.Raylib;

namespace Errpg.Engine
{
    public class EngineOrchestrator
    {
        private ILogger _log;
        private SceneOrchestrator _sceneOrchestrator;
        private SceneConfiguration _sceneConfiguration;

        public EngineOrchestrator(
            ILogger log, 
            SceneOrchestrator sceneOrchestrator,
            SceneConfiguration sceneConfiguration)
        {
            _log = log;
            _sceneOrchestrator = sceneOrchestrator;
            _sceneConfiguration = sceneConfiguration;
        }

        public void StartEngine()
        {
            _log.Write("Initialising engine");
            _log.Write("Configuring scenes");
            _sceneConfiguration.Run();

            InitWindow(800, 400, "Errpg");
            SetTargetFPS(60);

            _log.Write("Loading resources");
            _sceneOrchestrator.Preload();

            while (!WindowShouldClose())
            {
                BeginDrawing();
                ClearBackground(Color.BLACK);
                _sceneOrchestrator.CurrentScene.Render();
                EndDrawing();
            }

            CloseWindow();
        }
    }
}
