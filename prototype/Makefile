run: src/main.lua
	@cd src && love .

build/game.love: build/ src/main.lua
	@cd src && zip -9 -r ../build/game.love .

bin/game-linux: bin/ src/main.lua build/game.love
	@cat "$$(which love)" build/game.love > bin/game-linux && chmod +x bin/game-linux
