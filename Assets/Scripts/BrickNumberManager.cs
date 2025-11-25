using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickNumberManager : MonoBehaviour
{

     private int minValue = 0;

     private int maxValue = 200;

    public void AssignNumbers()
    {
        BrickNumber[] bricks = FindObjectsOfType<BrickNumber>();

        if (bricks.Length == 0)
            return;

        int correctAnswer = EquationAnswer.currentAnswer;

        float lowestY = Mathf.Infinity;
        foreach (var brick in bricks)
        {
            if (brick.transform.position.y < lowestY)
                lowestY = brick.transform.position.y;
        }

        List<BrickNumber> lowestRow = new List<BrickNumber>();
        foreach (var brick in bricks)
        {
            if (Mathf.Abs(brick.transform.position.y - lowestY) < 0.01f)
                lowestRow.Add(brick);
        }

        BrickNumber correctBrick = lowestRow[Random.Range(0, lowestRow.Count)];

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
