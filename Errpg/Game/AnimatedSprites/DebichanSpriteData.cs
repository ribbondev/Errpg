using Errpg.Engine;
using Errpg.Game.AnimatedSprites;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Errpg.Game.SpriteAnimations
{
    public enum DebichanAnimation
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

    public class DebichanSpriteData : ISpriteData<DebichanAnimation>
    {
        public string TextureFileName { get; } = "Data/debichan.png";

        public void RegisterAnimations(AnimatedSprite<DebichanAnimation> debichan)
        {
            debichan.RegisterAnimation(DebichanAnimation.DebichanFrontStill, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 0, y = 0, width = 48, height = 64 },
                },
                Loop = false,
                Speed = 1
            });

            debichan.RegisterAnimation(DebichanAnimation.DebichanRightSideStill, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 144, y = 0, width = 48, height = 64 },
                },
                Loop = false,
                Speed = 1
            });

            debichan.RegisterAnimation(DebichanAnimation.DebichanLeftSideStill, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 144, y = 0, width = -48, height = 64 },
                },
                Loop = false,
                Speed = 1
            });

            debichan.RegisterAnimation(DebichanAnimation.DebichanBackStill, new SpriteAnimation
            {
                Rectangles = new List<Rectangle>
                {
                    new Rectangle { x = 288, y = 0, width = 48, height = 64 },
                },
                Loop = false,
                Speed = 1
            });

            debichan.RegisterAnimation(DebichanAnimation.DebichanFrontWalk, new SpriteAnimation
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

            debichan.RegisterAnimation(DebichanAnimation.DebichanRightSideWalk, new SpriteAnimation
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

            debichan.RegisterAnimation(DebichanAnimation.DebichanLeftSideWalk, new SpriteAnimation
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

            debichan.RegisterAnimation(DebichanAnimation.DebichanBackWalk, new SpriteAnimation
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
        }
    }
}
