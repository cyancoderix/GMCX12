require("utils.subtables")
Vector = require("utils.vector")

Window = { size = {} }

local plr = {}

function love.load()
	Window.size.w, Window.size.h = love.graphics.getDimensions()

	love.graphics.setDefaultFilter("nearest")

	Player = require("player")
	plr = Player()
end

function love.update(dt)
	plr:update(dt)
end

function love.draw()
	love.graphics.push()
		love.graphics.translate(Window.size.w/2-plr.position.x-plr.size.w/2,Window.size.h/2-plr.position.y-plr.size.h/2)
		plr:draw()
	love.graphics.pop()
end
