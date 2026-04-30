using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject questionCanvas;
    public List<GameObject> levels;
    private int currentLevelIndex = 0;

    public coupleQuestion coupleQuestion;
    public QuestionDatabase questionDatabase;
    public Text questionText;
    public InputField answerInputField; // NEW — drag the InputField here

    private bool questionDisplayed = false;

    void Start()
    {
        HoldToLoadLevel.OnLevelLoad += LoadNextLevel;
        HoldToLoadLevel.OnAnswerSubmitted += EnablePlayerMovement;

        questionCanvas.SetActive(false);
        coupleQuestion = FindFirstObjectByType<coupleQuestion>();
    }

    void Update()
    {
        if (coupleQuestion.coupleDetected && !questionDisplayed)
        {
            ShowQuestion(); // moved into its own method
        }
        else if (!coupleQuestion.coupleDetected && questionDisplayed)
        {
            questionCanvas.SetActive(false);
            questionDisplayed = false;
            SetPlayerMovement(true);
        }
    }

    private void ShowQuestion()
    {
        questionText.text = questionDatabase.GetRandomQuestion();
        questionCanvas.SetActive(true);
        questionDisplayed = true;

        answerInputField.text = "";          
        answerInputField.Select();           
        answerInputField.ActivateInputField(); 

        SetPlayerMovement(false);
    }

   private void SetPlayerMovement(bool enabled)
{
    PlayerMovement[] allPlayers = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
    foreach (PlayerMovement p in allPlayers)
    {
        p.canMove = enabled;
    }
}

    private void EnablePlayerMovement()
    {
        SetPlayerMovement(true);
    }

    void LoadNextLevel()
    {
        int nextlevelIndex = (currentLevelIndex == levels.Count - 1) ? 0 : currentLevelIndex + 1;

        levels[currentLevelIndex].gameObject.SetActive(false);
        levels[nextlevelIndex].gameObject.SetActive(true);

        player.transform.position = new Vector3(-8.5f, -1.5f, 0f);

        currentLevelIndex = nextlevelIndex;

        questionCanvas.SetActive(false);
        questionDisplayed = false;

        coupleQuestion = FindFirstObjectByType<coupleQuestion>(); // NEW
        if (coupleQuestion != null) coupleQuestion.coupleDetected = false;

        Debug.Log("Level Loaded: " + currentLevelIndex);
    }
}