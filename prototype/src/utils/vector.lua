local vector = {
	normalize = function(v)
		if v.x == 0 and v.y == 0 then return v end
		local l = math.sqrt(v.x^2+v.y^2)
		v.x = v.x/l
		v.y = v.y/l
		return v
	end,
}
callable(vector, function(_,x,y) return { x = x or 0, y = y or 0 } end)

return vector
