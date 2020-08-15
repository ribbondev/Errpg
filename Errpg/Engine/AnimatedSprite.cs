using System.Collections.Generic;
using System.Numerics;
using Errpg.Game.AnimatedSprites;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Errpg.Engine
{
    public class SpriteAnimation
    {
        public int Speed { get; set; }
        public bool Loop { get; set; }
        public List<Rectangle> Rectangles { get; set; }
    }

    public class AnimatedSprite<T>
    {
        public Vector2 Position { get; set; } = new Vector2(0, 0);

        private Texture2D _texture;
        private Dictionary<T, SpriteAnimation> _animations;
        private SpriteAnimation _currentAnimation;

        private int _animationIndex;
        private int _framesCounter;

        public AnimatedSprite(ISpriteData<T> spriteData)
        {
            _texture = LoadTexture(spriteData.TextureFileName);
            _animations = new Dictionary<T, SpriteAnimation>();
            spriteData.RegisterAnimations(this);
        }

        public void RegisterAnimation(T id, SpriteAnimation spriteAnimation)
        {
            _animations.Add(id, spriteAnimation);
        }

        public void Play(T animationId, int startIndex = 0)
        {
            if (_currentAnimation == _animations[animationId])
                return;
            _currentAnimation = _animations[animationId];
            _animationIndex = startIndex;
        }

        public void Render()
        {
            if (_currentAnimation == null)
                return;

            _framesCounter++;
            if (_framesCounter >= (60 / _currentAnimation.Speed))
            {
                _framesCounter = 0;
                if (_currentAnimation.Rectangles.Count > 0)
                    ReframeAnimation();
            }

            DrawTextureRec(
                _texture, 
                _currentAnimation.Rectangles[_animationIndex], 
                Position, 
                Color.WHITE);
        }

        private void ReframeAnimation()
        {
            _animationIndex++;
            if (_animationIndex > (_currentAnimation.Rectangles.Count - 1))
            {
                if (_currentAnimation.Loop)
                    _animationIndex = 0;
                else
                    _animationIndex--;
            }
        }

        public void Destroy()
        {
            UnloadTexture(_texture);
        }
    }
}
