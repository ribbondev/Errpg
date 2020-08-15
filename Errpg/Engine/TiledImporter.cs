using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Errpg.Engine
{
    public class TiledLayers
    {
        public int[] Data { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class TiledTileSets
    {
        public int FirstGid { get; set; }
        public string Source { get; set; }
    }

    public class TiledMap
    {
        public string FileName { get; set; }
        public List<TiledLayers> Layers { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<TiledTileSets> TileSets { get; set; }
        public int TileHeight { get; set; }
        public int TileWidth { get; set; }
    }

    public static class TiledImporter
    {
        public static TiledMap Import(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var map = JsonSerializer.Deserialize<TiledMap>(File.ReadAllBytes(fileName), options);
            return map;
        }
    }
}
