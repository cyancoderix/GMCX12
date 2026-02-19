function callable(t,func) setmetatable(t,{ __call = func }) end

function table.subtable(parent,child)
	if not child then child = {} end
	setmetatable(child, {__index = parent})
	return child
end

function table.subtableable(parent,ctor)
	setmetatable(parent, {__call = function(_,child,...)
		if not child then child = {} end
		setmetatable(child,{__index = parent})
		if ctor then ctor(child,...) end
		return child
	end })
	return parent
end
