using System;


/**
 * This class demonstrates matrix Generator for int in given range.
 */
public class TilesGenerator
{


    //The height and length of the grid
    protected int gridSize;

    //The double buffer
    private int[,] bufferOld;
    private int[,] bufferNew;

    // **** my change ****
    // number of tiles in scene
    private int numOfTiles;


    private System.Random random;

    // **** my change ****
    public TilesGenerator(int gridSize = 100, int numOfTiles=1)
    {
        this.gridSize = gridSize;
        this.numOfTiles = numOfTiles;
        this.bufferOld = new int[gridSize, gridSize];
        this.bufferNew = new int[gridSize, gridSize];

        random = new System.Random();
    }

    public int[,] GetMap()
    {
        return bufferOld;
    }



    /**
     * Generate a random map.
     * The map is not smoothed; call Smooth several times in order to smooth it.
     */
    public void RandomizeMap()
    {
        //Init the old values so we can calculate the new values
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                if (x == 0 || x == gridSize - 1 || y == 0 || y == gridSize - 1)
                {
                    //We dont want holes in our walls, so the border is always a wall
                    bufferOld[x, y] = 0;
                }
                else
                {
                    // **** my change ****
                    //Random Tiles represent as indexes
                    bufferOld[x, y] = random.Next(1, numOfTiles);
                }
            }
        }
    }


    /**
     * Generate tiles by smoothing the data
     * Remember to always put the new results in bufferNew and use bufferOld to do the calculations
     */
    public void SmoothMap()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                //Border is always wall
                if (x == 0 || x == gridSize - 1 || y == 0 || y == gridSize - 1)
                {
                    bufferNew[x, y] = 0;
                    continue;
                }

                //Uses bufferOld to get the max tile count and his index that represent that tile
                // **** my change ****
                Tuple<int, int> surroundingtiles = GetSurroundingCount(x, y);

                //Use some smoothing rules to generate caves
                if (surroundingtiles.Item2 > 4)
                {
                    bufferNew[x, y] = surroundingtiles.Item1;
                }
                else
                {
                    bufferNew[x, y] = bufferOld[x, y];
                }
            }
        }

        //Swap the pointers to the buffers
        (bufferOld, bufferNew) = (bufferNew, bufferOld);
    }


    //Given a cell, how many of the 8 surrounding cells are walls?
    private Tuple<int, int> GetSurroundingCount(int cellX, int cellY)
    {
        // **** my change ****
        // array that each index represnt a tile and for each tile showing for given cell 
        // and calculate the number of occurents for each tile
        // index start from 0 - numOfTiles
        int[] tilesCounter = new int[numOfTiles];

        for (int neighborX = cellX - 1; neighborX <= cellX + 1; neighborX++)
        {
            for (int neighborY = cellY - 1; neighborY <= cellY + 1; neighborY++)
            {
                //We dont need to care about being outside of the grid because we are never looking at the border
                //This is the cell itself and no neighbor!
                if (neighborX == cellX && neighborY == cellY)
                {
                    continue;
                }

                //This neighbor is a wall
                int tile = bufferOld[neighborX, neighborY];
                tilesCounter[tile]++;
            }
        }

        // **** my change ****
        //find max 
        return findMax(tilesCounter);
    }

    // **** my change ****
    // finding the max value in array
    // return max value and his index as a size 2 tuple
    // (index, max value)
    private Tuple<int, int> findMax(int[] arr) {
        int index = 0;
        int maxValue = 0;

        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] > maxValue) {
                index = i;
                maxValue = arr[i];
            }
        }
        return Tuple.Create(index, maxValue);
    }
}
