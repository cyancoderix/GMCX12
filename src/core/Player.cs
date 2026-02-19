using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace CyanDevelopers.GMCX12.Core;
// State may be helpful here in the future
public class Player {
	public required float scale;
	public required Texture2D texture;
	Rectangle sourceRec;
	Rectangle rec;
	public void Init() {
		sourceRec = new(Vector2.Zero,texture.Width, texture.Height);
		rec = new(Vector2.Zero,sourceRec.Size * scale);
	}
	public void Update(float dt) {
		Vector2 input = new(
					x: (IsKeyDown(KeyboardKey.A) ? -1 : 0) + (IsKeyDown(KeyboardKey.D) ? 1 : 0),
					y: (IsKeyDown(KeyboardKey.W) ? -1 : 0) + (IsKeyDown(KeyboardKey.S) ? 1 : 0)
				);
		if (input.Length() != 0) input /= input.Length();
		rec.Position += input * dt * 360;
	}
	public void Draw() { 
		DrawTexturePro(texture, sourceRec,rec, Vector2.Zero, 0, Color.White); 
	}

}
