#!/usr/bin/env lua
if not os.execute("bash --version $1>/dev/null $2>&1") then print("Build script can be executed only on Linux machine!"); os.exit(4); return end

local script_path = io.popen("dirname $(realpath "..debug.getinfo(1,"S").source:match("^@(.+)$")..")"):read()

-- TODO stderr handling
local project = {
	path = "",
	release = function(self,runtime)
		os.execute("dotnet publish "..self.path.." -c Release -r "..runtime)
	end,
	run = function(self)
		os.execute("dotnet run --project "..self.path)
	end,
}

project.path = script_path.."/../src/client/desktop"

local function run_build_tool()
os.execute("clear")

local help = "\27[1m\27[30;31mWelcome to GMCX12 build tool!\27[0m\27[30;36m\n"
for _,c in pairs(Commands) do
	help = help.."\n> "..c.char.." - "..c.description
end
help = help.."\n\n\27[30;96m\27[1mEnter commands:\27[0m"

print(help)
local user_commands = io.read()

os.execute("clear")

for i=0,#user_commands-1,1  do
	--os.execute("clear")
	print("\27[1m\27[30;34m"..tostring(i).."]===============================\27[0m")
	for _,command in pairs(Commands) do if command.char == user_commands:sub(i+1,i+1) then command.command() end end
end
end

-- TODO replace quit with clear
-- TODO categories
Commands = {
	{char = "q"  , description = "quit", command = function() os.execute("clear"); os.exit() end},
	{char = "r", description = "runs the project", command = function() project:run() end},
	{char = "b", description = "opens this build tool", command = run_build_tool},
	{char = "L", description = "build Linux executable", command = function() project:release("linux-x64") end},
	{char = "W", description = "build Windows executable", command = function() project:release("win-x64") end},
	{char = "d", description = "delete bin/ and obj/ of the desktop project", command = function() os.execute("rm -rf "..script_path.."/../src/client/desktop/bin; rm -rf "..script_path.."/../src/client/desktop/obj") end},
}


run_build_tool()
