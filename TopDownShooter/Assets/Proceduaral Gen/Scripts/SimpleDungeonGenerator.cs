using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleDungeonGenerator : AbstractDungeonGenerator
{


    [SerializeField]
    protected SimpleRandomWalkData randomWalkParameters;



    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tilemapvisualizer.Clear();
        tilemapvisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapvisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkData parameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProcedualGeneration.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPositions.UnionWith(path);
            if (randomWalkParameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }

    
}
