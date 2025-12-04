using UnityEngine;

public class ModeToggleUI : MonoBehaviour
{
    public GameObject additionYellow;
    public GameObject additionGrey;

    public GameObject subtractionYellow;
    public GameObject subtractionGrey;

    public GameObject multiplicationYellow;
    public GameObject multiplicationGrey;

    private void OnEnable()
    {
        // Standard: Addition aktiv
        SelectAddition();
    }

    public void SelectAddition()
    {
        additionYellow.SetActive(true);
        additionGrey.SetActive(false);

        subtractionYellow.SetActive(false);
        subtractionGrey.SetActive(true);

        multiplicationYellow.SetActive(false);
        multiplicationGrey.SetActive(true);

        GameModeManager.CurrentMode = GameMode.Addition;
    }

    public void SelectSubtraction()
    {
        additionYellow.SetActive(false);
        additionGrey.SetActive(true);

        subtractionYellow.SetActive(true);
        subtractionGrey.SetActive(false);

        multiplicationYellow.SetActive(false);
        multiplicationGrey.SetActive(true);

        GameModeManager.CurrentMode = GameMode.Subtraction;

    }

    public void SelectMultiplication()
    {
        additionYellow.SetActive(false);
        additionGrey.SetActive(true);

        subtractionYellow.SetActive(false);
        subtractionGrey.SetActive(true);

        multiplicationYellow.SetActive(true);
        multiplicationGrey.SetActive(false);

        GameModeManager.CurrentMode = GameMode.Multiplication;

    }
}
