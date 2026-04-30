using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject loadCanvas;
    public List<GameObject> levels;
    private int currentLevelIndex = 0;

    public coupleQuestion coupleQuestion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HoldToLoadLevel.OnLevelLoad += LoadNextLevel;
        loadCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (coupleQuestion.coupleDetected)
        {
            loadCanvas.SetActive(true);
        }
        else
        {
            loadCanvas.SetActive(false);
        }
    }

    void LoadNextLevel()
    {
        int nextlevelIndex = (currentLevelIndex == levels.Count - 1) ? 0 : currentLevelIndex + 1;
        //loadCanvas.SetActive(false);

        levels[currentLevelIndex].gameObject.SetActive(false);
        levels[nextlevelIndex].gameObject.SetActive(true);


        player.transform.position = new Vector3(-8.5f, -1.5f, 0f);

        currentLevelIndex = nextlevelIndex;

        Debug.Log("Level Loaded: " + currentLevelIndex);
    }
}
