local draggable = {
}

table.subtableable(draggable,function(self)
	self.position = Vector()
	self.size = Vector()
end)

return draggable
