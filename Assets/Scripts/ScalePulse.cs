using UnityEngine;
using DG.Tweening;

public class ScalePulse : MonoBehaviour
{
    [SerializeField] private Vector3 scaleUp = new(1.2f, 1.2f, 1.2f);
    [SerializeField] private float duration = 0.5f;

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
        StartPulsing();
    }

    private void StartPulsing()
    {
        ScaleUp().OnComplete(ScaleDown);
    }

    private Tweener ScaleUp()
    {
        return transform.DOScale(scaleUp, duration);
    }

    private void ScaleDown()
    {
        transform.DOScale(initialScale, duration).OnComplete(StartPulsing);
    }
}
