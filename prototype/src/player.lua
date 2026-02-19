local player = {
	size = {},
	scale = { w = 5, h = 5 },
	speed = 30,
}

function player:load()
end

function player:update(dt)
	local input = { y = (love.keyboard.isDown("w") and -1) or (love.keyboard.isDown("s") and 1) or 0, x = (love.keyboard.isDown("a") and -1) or (love.keyboard.isDown("d") and 1) or 0 }
	Vector.normalize(input)

	self.position.x = self.position.x + self.speed * dt * 10 * input.x
	self.position.y = self.position.y + self.speed * dt * 10 * input.y
end

function player:draw()
	love.graphics.draw(self.texture, self.position.x,self.position.y,0,self.scale.w, self.scale.h)
end

table.subtableable(player, function(self)
	self.position = Vector()
	self.texture = love.graphics.newImage("assets/kenney/links/player.png")
	self.size.w, self.size.h = self.scale.w * self.texture:getWidth(), self.scale.h * self.texture:getHeight()
end)

return player
