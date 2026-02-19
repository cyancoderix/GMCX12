using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Newtonsoft.Json;

namespace CyanDevelopers.GMCX12.Core;

public class TileMap { 
	[JsonRequired] public Layer[] layers = [];
	[JsonRequired] public uint width;
	[JsonRequired] public TileSet[] tilesets = [];
	[JsonRequired] public uint tilewidth;
	[JsonRequired] public uint tileheight;

	[JsonIgnore] public float scale = 1;
	[JsonIgnore] public Dictionary<string,Texture2D> textures = [];

	public void DrawLayer(Layer lr) {
	
		for (int i = 0; i < lr.data.Length ; i++)
		{
			TileSet set = GetTileSetOf(lr.data[i]);
			if (set.image == null) continue;
			DrawTexturePro(textures[set.image],
	
					source: new Rectangle((lr.data[i] - set.firstgid) % set.columns * tilewidth, (int)((lr.data[i] - set.firstgid) / set.columns * tileheight), tilewidth, tileheight),
	
					dest: new Rectangle(i % width * tilewidth * scale, (int)(i / width) * tileheight * scale, tilewidth * scale, tileheight * scale ),
	
				Vector2.Zero,0,Color.White);
		}
	}
	TileSet GetTileSetOf(uint data) {
		if (data == 0) return new TileSet();
		for (int i=0; i < tilesets.Length - 1; i++)
			if (tilesets[i].firstgid <= data && data < tilesets[i+1].firstgid)
				return tilesets[i];
		return tilesets[^1];
	}
	
}

public struct Layer {
	[JsonRequired] public uint[] data;
	[JsonRequired] public bool visible;
	[JsonRequired] public uint id;
	[JsonRequired] public string name;
}

public struct TileSet {
	[JsonRequired] public string image;

	[JsonRequired] public uint columns;
	[JsonRequired] public uint tilecount;
	[JsonRequired] public uint firstgid;
}
