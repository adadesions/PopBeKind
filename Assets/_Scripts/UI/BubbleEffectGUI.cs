using UnityEngine;
using DG.Tweening; // Import DoTween namespace

public class BubbleEffectGUI : MonoBehaviour
{
    public float floatDistance = 20f; // How far the button moves
    public float floatDuration = 2f; // How long the movement takes
    public float scaleAmount = 1.1f; // Bubble scale size
    public float scaleDuration = 1f; // Scaling duration

    private Vector3 originalPosition;
    private Vector3 originalScale;

    void Start()
    {
        // Save the original position and scale
        originalPosition = transform.localPosition;
        originalScale = transform.localScale;

        // Start the floating effect
        StartFloating();
    }

    void StartFloating()
    {
        // Move up and down
        transform.DOLocalMoveY(originalPosition.y + floatDistance, floatDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo); // Infinite loop (Yoyo: back and forth)

        // Scale up and down for bubble effect
        transform.DOScale(originalScale * scaleAmount, scaleDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo); // Infinite loop
    }
}