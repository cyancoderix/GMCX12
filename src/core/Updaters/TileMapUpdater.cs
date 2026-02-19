namespace CyanDevelopers.GMCX12.Core.Updaters;

public class TileMapUpdater : Updater {
	public required TileMap tilemap;

	public override void Draw(float dt)
	{
		base.Draw(dt);
		for (int lr = 0;lr < tilemap.layers.Length;lr++)
		{
			tilemap.DrawLayer(tilemap.layers[lr]);
		}
	}
}
