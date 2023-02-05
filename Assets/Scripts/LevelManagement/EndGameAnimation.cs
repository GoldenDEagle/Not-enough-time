using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class EndGameAnimation : MonoBehaviour
{
    [SerializeField] private UnityEvent OnComplete;

    private Light _light;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    public void Play()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(transform.position.y + 1, 2f))
            .Insert(0, transform.DORotate(new Vector3(0, 1080, 0), 4f, RotateMode.FastBeyond360))
            .Insert(0, _light.DOIntensity(100f, 4f).SetEase(Ease.InOutBounce))
            .OnComplete(OnAnimationCompleted);
    }

    private void OnAnimationCompleted()
    {
        OnComplete?.Invoke();
    }
}
