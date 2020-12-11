# TileMap_Generator 

## based on [This GitHub Repo](https://github.com/gamedev-at-ariel/05-tilemap-pathfinding)

###

### I'm modified the generator from 2 tiles to userInput Tiles, just drag ur tiles to Tiles in the script
### example pic

![](https://github.com/Lba-universe/TileMap_Generator/blob/main/pics/tilemap2.png)

###

there are 2 scripts 
1. generate matrix of random ints - between 0 and num of tiles given,
also it has smoothing method that attach smilar tiles togther to make realistic tilemap.
[Script-MatrixGenerator](https://github.com/Lba-universe/TileMap_Generator/blob/main/Assets/Scripts/TilesGenerator.cs)

2. is to convert the matrix of ints - to tiles each number has index of uniqe tile in the scene
[Script-TileMapGenerator](https://github.com/Lba-universe/TileMap_Generator/blob/main/Assets/Scripts/TileMapGenerator.cs)

every changed line commented with "my change".

###
### in this example there is 5 diffrent tiles

![](https://github.com/Lba-universe/TileMap_Generator/blob/main/pics/tilemap1.png)

![](https://github.com/Lba-universe/TileMap_Generator/blob/main/pics/tilemap3.png)


