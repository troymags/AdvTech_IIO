using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string answerInput;

    public GameObject questionCanvas;

    public void readStringInput(string answer)
    {
        answerInput = answer;
        Debug.Log("Input Received: " + answerInput);

        if (!string.IsNullOrWhiteSpace(answerInput))
        {
            HoldToLoadLevel.TriggerAnswerSubmitted();
            questionCanvas.SetActive(false);
        }
    }
}