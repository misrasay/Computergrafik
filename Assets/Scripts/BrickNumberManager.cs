using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrickNumberManager : MonoBehaviour
{

    private int minValue = 0;
    private int maxValue = 200;
    private int columns = 6;

    public void AssignNumbers()
    {
        BrickNumber[] bricks = FindObjectsOfType<BrickNumber>();

        if (bricks.Length == 0)
            return;

        int correctAnswer = EquationAnswer.currentAnswer;

        float minX = Mathf.Infinity;
        float maxX = -Mathf.Infinity;

        foreach (var brick in bricks)
        {
            float x = brick.transform.position.x;
            if (x < minX) minX = x;
            if (x > maxX) maxX = x;
        }

        float totalWidth = maxX - minX;
        if (totalWidth <= 0f)
        {
            totalWidth = 1f;
        }

        List<BrickNumber>[] columnsList = new List<BrickNumber>[columns];
        for (int i = 0; i < columns; i++)
        {
            columnsList[i] = new List<BrickNumber>();
        }

        foreach (var brick in bricks)
        {
            float x = brick.transform.position.x;

            float t = (x - minX) / totalWidth;   
            int colIndex = Mathf.FloorToInt(t * columns);   
            colIndex = Mathf.Clamp(colIndex, 0, columns - 1);

            columnsList[colIndex].Add(brick);
        }

        List<BrickNumber> reachableBricks = new List<BrickNumber>();

        for (int c = 0; c < columns; c++)
        {
            if (columnsList[c].Count == 0)
                continue;

            BrickNumber lowest = columnsList[c][0];
            float lowestY = lowest.transform.position.y;

            foreach (var brick in columnsList[c])
            {
                float y = brick.transform.position.y;
                if (y < lowestY)
                {
                    lowestY = y;
                    lowest = brick;
                }
            }

            reachableBricks.Add(lowest);
        }


        BrickNumber correctBrick = reachableBricks[Random.Range(0, reachableBricks.Count)];
        correctBrick.SetNumber(correctAnswer);

        HashSet<int> used = new HashSet<int> { correctAnswer };

        foreach (var brick in bricks)
        {
            if (brick == correctBrick)
                continue;

            int value;
            do
            {
                value = Random.Range(minValue, maxValue + 1);
            }
            while (used.Contains(value));

            used.Add(value);
            brick.SetNumber(value);
        }
    }
}

