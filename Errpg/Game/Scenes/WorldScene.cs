using Errpg.Engine;
using Errpg.Game.SpriteAnimations;
using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace Errpg.Game.Scenes
{

    public enum Directional
    {
        Left,
        Right,
        Up,
        Down
    }

    public class WorldScene : IScene
    {
        public SceneIdentifiers SceneId => SceneIdentifiers.WorldScene;
        private AnimatedSprite<DebichanAnimation> _debichan;
        private WorldRenderer _worldRenderer;
        private Camera2D _camera;

        public WorldScene()
        {
        }

        public void Destroy()
        {
            _debichan.Destroy();
        }

        public void Preload()
        {
            _debichan = new AnimatedSprite<DebichanAnimation>(new DebichanSpriteData());
            _debichan.Position = new Vector2(100f, 100f);
            _debichan.Play(DebichanAnimation.DebichanFrontStill);

            _worldRenderer = new WorldRenderer();
            _worldRenderer.PreLoad();

            _camera = new Camera2D(new Vector2(_debichan.Position.X + 10.0f, _debichan.Position.Y + 10.0f), _debichan.Position, 0.0f, 1.0f);
        }

        public Directional Direction { get; set; } = Directional.Down;
        public void Render()
        {
            BeginMode2D(_camera);

            _worldRenderer.Render();
            Direction = Directional.Down;
            
            if (IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                _debichan.Position = new Vector2(_debichan.Position.X - 2.0f, _debichan.Position.Y);
                _debichan.Play(DebichanAnimation.DebichanLeftSideWalk);
                Direction = Directional.Left;
            }
            else if (IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                _debichan.Position = new Vector2(_debichan.Position.X + 2.0f, _debichan.Position.Y);
                _debichan.Play(DebichanAnimation.DebichanRightSideWalk);
                Direction = Directional.Right;
            }
            else if (IsKeyDown(KeyboardKey.KEY_UP))
            {
                _debichan.Position = new Vector2(_debichan.Position.X, _debichan.Position.Y - 2.0f);
                _debichan.Play(DebichanAnimation.DebichanBackWalk);
                Direction = Directional.Up;
            }
            else if (IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                _debichan.Position = new Vector2(_debichan.Position.X, _debichan.Position.Y + 2.0f);
                _debichan.Play(DebichanAnimation.DebichanFrontWalk);
                Direction = Directional.Down;
            }
            else
            {
                if (Direction == Directional.Up)
                    _debichan.Play(DebichanAnimation.DebichanBackStill);
                else if (Direction == Directional.Left)
                    _debichan.Play(DebichanAnimation.DebichanLeftSideStill);
                else if (Direction == Directional.Right)
                    _debichan.Play(DebichanAnimation.DebichanRightSideStill);
                else _debichan.Play(DebichanAnimation.DebichanFrontStill);
            }

            _camera.target = _debichan.Position;

            _debichan.Render();

            EndMode2D();
        }
    }
}
