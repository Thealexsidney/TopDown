using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProcedualGeneration
{
   
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        var previousposition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousposition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousposition = newPosition;

        }
        return path;
    }

    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPosition = startPosition;
        corridor.Add(currentPosition);

        for (int i = 0;i < corridorLength;i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }
        return corridor;
    }

}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0,1),
        new Vector2Int(1,0),
        new Vector2Int(0,-1),
        new Vector2Int(-1,0)
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
    }
}
