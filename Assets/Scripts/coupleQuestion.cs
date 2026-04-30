using System.Collections.Generic;
using UnityEngine;

public class coupleQuestion : MonoBehaviour
{
    private List<GameObject> playersInZone = new List<GameObject>();
    public int playerCount = 0;
    public bool coupleDetected = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coupleDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!playersInZone.Contains(collision.gameObject))
            {
                playerCount++;
                Debug.Log("Player Entered Zone. Current Count: " + playerCount);
                playersInZone.Add(collision.gameObject);
                CheckforCouple();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playersInZone.Contains(collision.gameObject))
            {
                playerCount--;
                Debug.Log("Player Exited Zone. Current Count: " + playerCount);
                playersInZone.Remove(collision.gameObject);
            }
        }
    }

    private void CheckforCouple()
    {
        if (playersInZone.Count >= 2)
        {
            playerCount++;
            Debug.Log("Current Count: " + playerCount);

            Debug.Log("Couple Detected!");
            coupleDetected = true;
        }
    }
}
