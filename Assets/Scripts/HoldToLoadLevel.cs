using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class HoldToLoadLevel : MonoBehaviour
{

    public float holdDuration = 1f;
    public Image fillImage;

    private float holdTimer = 0f;
    private bool isHolding = false;

    public static event Action OnLevelLoad;
    // Update is called once per frame
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

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
        }
        else if (context.canceled)
        {
            ResetHold();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0;
        fillImage.fillAmount = 0;
    }
}
