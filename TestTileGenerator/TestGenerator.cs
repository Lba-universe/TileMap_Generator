using System;

namespace TestGenerator {


    /*** 
     modify erel test
     
     
     */
    class Program {

        static int gridSize = 10;

        static void print(int[,] data) {
            for (int x=0; x < gridSize; ++x) {
                for (int y = 0; y<gridSize; ++y) {
                    Console.Write(data[x,y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // check for 5 tiles
        static void Main(string[] args) {
            TilesGenerator Generator = new TilesGenerator(10, 5);
            TilesGenerator.RandomizeMap();
            for (int i=0; i<10; ++i) {
                print(Generator.GetMap());
                Console.ReadKey();
                Generator.SmoothMap();
            }

            Console.WriteLine("End Generator Test");
        }
    }
}
