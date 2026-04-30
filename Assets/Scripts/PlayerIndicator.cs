using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color player1Color = new Color(0.75f, 0.65f, 0.85f); // lavender
    public Color player2Color = new Color(0.95f, 0.70f, 0.55f); // peach

    private static int playerIndex = 0;

    void Start()
    {
        if (playerIndex == 0) spriteRenderer.color = player1Color;
        else spriteRenderer.color = player2Color;

        playerIndex++;
    }

    void OnDestroy()
    {
        playerIndex = 0;
    }
}