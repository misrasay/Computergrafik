using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrickNumber : MonoBehaviour
{

    [SerializeField] private TMP_Text numberText;

    public int Number { get; private set; }

    public void SetNumber(int value)
    {
        Number = value;
        if (numberText != null)
            numberText.text = value.ToString();

    }


}
