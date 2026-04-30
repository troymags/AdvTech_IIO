using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class HoldToLoadLevel : MonoBehaviour
{
    public float holdDuration = 1f;
    public Image fillImage;
    public GameObject loadCanvas; 

    private float holdTimer = 0f;
    private bool isHolding = false;

    public static event Action OnLevelLoad;
    public static event Action OnAnswerSubmitted;

    void OnEnable()
    {
        OnAnswerSubmitted += EnableLoadCanvas;
    }

    void OnDisable()
    {
        OnAnswerSubmitted -= EnableLoadCanvas;
    }

    void Start()
    {
        if (loadCanvas != null) loadCanvas.SetActive(false);
    }

    void Update()
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            fillImage.fillAmount = holdTimer / holdDuration;

            if (holdTimer >= holdDuration)
            {
                OnLevelLoad.Invoke();
                ResetHold();
            }
        }
        else
        {
            holdTimer = 0f;
            fillImage.fillAmount = 0f;
        }
    }

    public static void TriggerAnswerSubmitted()
    {
    OnAnswerSubmitted?.Invoke();
    }

    private void EnableLoadCanvas()
    {
        if (loadCanvas != null) loadCanvas.SetActive(true);
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started) isHolding = true;
        else if (context.canceled) ResetHold();
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0;
        fillImage.fillAmount = 0;
    }
}