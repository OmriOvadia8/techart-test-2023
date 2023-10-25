using UnityEngine;
using DG.Tweening;

public class ScalePulse : MonoBehaviour
{
    [SerializeField] private Vector3 scaleUp = new Vector3(1.2f, 1.2f, 1.2f); 
    [SerializeField] private Vector3 scaleDown; 
    [SerializeField] private float duration = 0.5f; 

    private void Start()
    {
        scaleDown = transform.localScale; 

        PulseScale();
    }

    void PulseScale()
    {
        transform.DOScale(scaleUp, duration)
        .OnComplete(() =>
        {
            transform.DOScale(scaleDown, duration)
            .OnComplete(PulseScale); 
        });
    }
}
