build:
	mcs *.cs Tiles/*.cs Exception/*.cs -out:"Shoter.exe"
run:
	mono Shoter.exe