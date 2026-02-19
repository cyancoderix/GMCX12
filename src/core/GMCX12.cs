using static Raylib_cs.Raylib;
using Raylib_cs;
using Newtonsoft.Json;
using CyanDevelopers.GMCX12.Core.Updaters;

namespace CyanDevelopers.GMCX12.Core;

public class GMCX12 {
	int width;
	int height;
	const int SCALE = 5;

	//readonly Dictionary<string,Texture2D> textureCache = [];
	string baseDir = "./";

#pragma warning disable CA1859
	Updater? updater;
#pragma warning restore CA1859

	/// <summary>
	/// Runs the game.
	/// </summary>
	public void Run() {
		
#if DEBUG
		SetTraceLogLevel(TraceLogLevel.All);
#else
		SetTraceLogLevel(TraceLogLevel.None);
#endif
		
		InitWindow(1920,1080,"GMCX12");
		SetWindowState(ConfigFlags.ResizableWindow | ConfigFlags.MaximizedWindow);
		SetExitKey(KeyboardKey.Null);
		
		Init();

		width = GetScreenWidth();
		height = GetScreenHeight();

		while (!WindowShouldClose()) {
			PollInputEvents();
			Tick();
		}
		
		CloseWindow();
	}

	/// <summary>
	/// Initialize properties
	/// </summary>
	void Init() {
		baseDir = AppDomain.CurrentDomain.BaseDirectory;
		
		TileMap tilemap = JsonConvert.DeserializeObject<TileMap>(new StreamReader(baseDir + "assets/maps/TestingCastle.json").ReadToEnd())!;
		tilemap.scale = SCALE;
		foreach (TileSet set in tilemap.tilesets)
			tilemap.textures[set.image] = LoadTexture($"{baseDir}assets/maps/{set.image}");

		updater = new GameUpdater() {
			plr = new() {
				texture = LoadTexture( baseDir + "assets/kenney/links/player.png"),
				scale = SCALE,},
			tilemap = tilemap,
			Children = [new ServiceUpdater()],
		};
	}

	double timeBeforeTicks = GetTime();
	const double MS_PER_TICK = 100;

	void Tick()
	{
		double currentTime = GetTime();
		double catchUpTicks = (currentTime - timeBeforeTicks)/MS_PER_TICK;
		timeBeforeTicks = currentTime;
		if (catchUpTicks <= 0) return;
		while (catchUpTicks >= 0)
		{
			Update(GetFrameTime());
			BeginDrawing();
			ClearBackground(Color.Black);
			Draw(GetFrameTime());
			EndDrawing();
			catchUpTicks--;
		}
	}
	
	void Update(float dt) { if (updater != null && updater.Enabled) updater?.Update(dt);}

	void Draw(float dt) => updater?.Draw(dt);
}
