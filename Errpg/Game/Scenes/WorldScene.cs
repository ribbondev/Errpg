using Errpg.Engine;
using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace Errpg.Game.Scenes
{
    public enum AnimationIndexes
    {
        DebichanFrontStill,
        DebichanFrontWalk,
        DebichanRightSideStill,
        DebichanRightSideWalk,
        DebichanLeftSideStill,
        DebichanLeftSideWalk,
        DebichanBackStill,
        DebichanBackWalk
    }

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
        private AnimatedSprite _debichan;

        public WorldScene()
        {
        }

        public void Destroy()
        {
            _debichan.Destroy();
        }

        public void EnterStage()
        {
        }

        public void ExitStage()
        {
        }

        public void Preload()
        {
            _debichan = new AnimatedSprite("Data/debichan.png");

            _debichan.RegisterAnimation((int)AnimationIndexes.DebichanFrontStill, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 0, y = 0, width = 48, height = 64 },
                },
                Loop = false,
                Speed = 1
            });

            _debichan.RegisterAnimation((int)AnimationIndexes.DebichanRightSideStill, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 144, y = 0, width = 48, height = 64 },
                },
                Loop = false,
                Speed = 1
            });

            _debichan.RegisterAnimation((int)AnimationIndexes.DebichanLeftSideStill, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 144, y = 0, width = -48, height = 64 },
                },
                Loop = false,
                Speed = 1
            });

            _debichan.RegisterAnimation((int)AnimationIndexes.DebichanBackStill, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 288, y = 0, width = 48, height = 64 },
                },
                Loop = false,
                Speed = 1
            });

            _debichan.RegisterAnimation((int)AnimationIndexes.DebichanFrontWalk, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 0, y = 0, width = 48, height = 64 },
                    new Rectangle { x = 48, y = 0, width = 48, height = 64 },
                    new Rectangle { x = 96, y = 0, width = 48, height = 64 }
                },
                Loop = true,
                Speed = 8
            });

            _debichan.RegisterAnimation((int)AnimationIndexes.DebichanRightSideWalk, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 144, y = 0, width = 48, height = 64 },
                    new Rectangle { x = 192, y = 0, width = 48, height = 64 },
                    new Rectangle { x = 240, y = 0, width = 48, height = 64 }
                },
                Loop = true,
                Speed = 8
            });

            _debichan.RegisterAnimation((int)AnimationIndexes.DebichanLeftSideWalk, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 144, y = 0, width = -48, height = 64 },
                    new Rectangle { x = 192, y = 0, width = -48, height = 64 },
                    new Rectangle { x = 240, y = 0, width = -48, height = 64 }
                },
                Loop = true,
                Speed = 8
            });

            _debichan.RegisterAnimation((int)AnimationIndexes.DebichanBackWalk, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 288, y = 0, width = 48, height = 64 },
                    new Rectangle { x = 336, y = 0, width = 48, height = 64 },
                    new Rectangle { x = 384, y = 0, width = 48, height = 64 }
                },
                Loop = true,
                Speed = 8
            });

            _debichan.Position = new Vector2(100f, 100f);

            _debichan.Play((int)AnimationIndexes.DebichanFrontStill);
        }

        public Directional Direction { get; set; } = Directional.Down;
        public void Render()
        {
            Direction = Directional.Down;
            
            if (IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                _debichan.Position = new Vector2(_debichan.Position.X - 2.0f, _debichan.Position.Y);
                _debichan.Play((int)AnimationIndexes.DebichanLeftSideWalk);
                Direction = Directional.Left;
            }
            else if (IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                _debichan.Position = new Vector2(_debichan.Position.X + 2.0f, _debichan.Position.Y);
                _debichan.Play((int)AnimationIndexes.DebichanRightSideWalk);
                Direction = Directional.Right;
            }
            else if (IsKeyDown(KeyboardKey.KEY_UP))
            {
                _debichan.Position = new Vector2(_debichan.Position.X, _debichan.Position.Y - 2.0f);
                _debichan.Play((int)AnimationIndexes.DebichanBackWalk);
                Direction = Directional.Up;
            }
            else if (IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                _debichan.Position = new Vector2(_debichan.Position.X, _debichan.Position.Y + 2.0f);
                _debichan.Play((int)AnimationIndexes.DebichanFrontWalk);
                Direction = Directional.Down;
            }
            else
            {
                if (Direction == Directional.Up)
                    _debichan.Play((int)AnimationIndexes.DebichanBackStill);
                else if (Direction == Directional.Left)
                    _debichan.Play((int)AnimationIndexes.DebichanLeftSideStill);
                else if (Direction == Directional.Right)
                    _debichan.Play((int)AnimationIndexes.DebichanRightSideStill);
                else _debichan.Play((int)AnimationIndexes.DebichanFrontStill);
            }

            _debichan.Render();
        }
    }
}
