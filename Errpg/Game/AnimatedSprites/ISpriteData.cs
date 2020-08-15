using Errpg.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Errpg.Game.AnimatedSprites
{
    public interface ISpriteData<T>
    {
        public string TextureFileName { get; }
        public void RegisterAnimations(AnimatedSprite<T> animatedSprite);
    }
}
