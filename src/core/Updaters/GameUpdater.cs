namespace CyanDevelopers.GMCX12.Core.Updaters;

// TODO Double buffer drawing
// Every object should have "book" of rules of arranging draw delegates

public class GameUpdater : Updater {
	bool firstUpdate = true;

	public required Player plr;
	public required TileMap tilemap;

	public override void Update(float dt)
	{
		base.Update(dt);
		if (firstUpdate) {
			firstUpdate = false;
			plr.Init();
		}
		plr.Update(dt);
	}
	public override void Draw(float dt)
	{
		base.Draw(dt);
		for (int lr = 0;lr < tilemap.layers.Length;lr++)
		{
			tilemap.DrawLayer(tilemap.layers[lr]);
			if (lr == 0) plr.Draw();
		}
	}
}
