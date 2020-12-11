using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;


/**
 * This class demonstrates the Generator on a Tilemap.
 */

public class TileMapGenerator : MonoBehaviour
{
    [SerializeField] Tilemap tilemap = null;

    // *** my change ****
    [Tooltip("Tiles of the Scene")]
    [SerializeField] TileBase[] Tiles = null;

    [Tooltip("Length and height of the grid")]
    [SerializeField] int gridSize = 100;

    [Tooltip("How many steps do we want to simulate?")]
    [SerializeField] int simulationSteps = 20;

    [Tooltip("For how long will we pause between each simulation step so we can look at the result?")]
    [SerializeField] float pauseTime = 1f;

    private TilesGenerator Generator;

    void Start()
    {

        // *** my change ****

        Generator = new TilesGenerator(gridSize, Tiles.Length);

        Generator.RandomizeMap();

        //For testing that init is working
        GenerateAndDisplayTexture(Generator.GetMap());

        //Start the simulation
        StartCoroutine(SimulateCavePattern());
    }


    //Do the simulation in a coroutine so we can pause and see what's going on
    private IEnumerator SimulateCavePattern()
    {
        for (int i = 0; i < simulationSteps; i++)
        {
            yield return new WaitForSeconds(pauseTime);

            //Calculate the new values
            Generator.SmoothMap();

            //Generate texture and display it on the plane
            GenerateAndDisplayTexture(Generator.GetMap());
        }
        Debug.Log("Simulation completed!");
    }



    //Generate a tiles texture depending on if the index 
    // each index represent uniqe tile
    //Display the texture on a plane
    private void GenerateAndDisplayTexture(int[,] data)
    {
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                var position = new Vector3Int(x, y, 0);
                var indexOfTile = data[x, y];
                // *** my change ****

                var tile = Tiles[indexOfTile];
                tilemap.SetTile(position, tile);
            }
        }
    }
}
