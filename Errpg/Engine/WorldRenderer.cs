using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using static Raylib_cs.Raylib;

namespace Errpg.Engine
{
    public class WorldRenderer
    {
        TiledMap _currentMap;
        Texture2D _currentTileset;
        List<Rectangle> _currentRectangles;

        public WorldRenderer()
        {

        }

        public void PreLoad()
        {
            _currentTileset = LoadTexture("Data/devtiles.png");
            _currentRectangles = new List<Rectangle>();
            var x = 0;
            for (var i = 0; i < 6; i++)
            {
                _currentRectangles.Add(new Rectangle { x = x, y = 0, width = 48, height = 48 });
                x += 48;
            }
            _currentMap = TiledImporter.Import("Data/devmap.json");
        }

        public void Render()
        {
            var w = _currentMap.Width;
            var y = 0;
            var x = 0;
            foreach (var t in _currentMap.Layers[0].Data)
            {
                DrawTextureRec(_currentTileset, _currentRectangles[t-1], new Vector2(x * 48.0f, y * 48.0f), Color.WHITE);
                if (x == w-1)
                {
                    y++;
                    x = 0;
                    continue;
                }
                x++;
            }
        }
    }
}
