using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string answerInput;

    public GameObject questionCanvas;
    public GameManager gameManager; 

   public void readStringInput(string answer)
{
    answerInput = answer;
    Debug.Log("Input Received: " + answerInput);

    if (!string.IsNullOrWhiteSpace(answerInput))
    {
        StartCoroutine(TransitionAfterDelay(1.5f));
    }
}

private System.Collections.IEnumerator TransitionAfterDelay(float seconds)
{
    yield return new WaitForSeconds(seconds);
    questionCanvas.SetActive(false);
    gameManager.LoadNextLevelFromAnswer();
}
}