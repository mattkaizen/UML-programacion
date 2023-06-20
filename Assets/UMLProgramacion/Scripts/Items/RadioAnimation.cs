using DG.Tweening;
using UnityEngine;

namespace Items
{
    public class RadioAnimation : MonoBehaviour
    {

        [Header("Scale Tween")] 
        [SerializeField] private GameObject objectToTween;
        [SerializeField] private float scaleTweenDuration;
        [SerializeField] private float scaleTweenStrength;
        [SerializeField] private Ease scaleTweenEase;

        private Tween _scaleTween;

        public void PlayOnAnimation()
        {
            if (objectToTween == null)
                return;

            _scaleTween = objectToTween.transform.DOShakeScale(scaleTweenDuration, scaleTweenStrength)
                .SetEase(scaleTweenEase)
                .SetLoops(-1);
        }

        public void StopOnAnimation()
        {
            if (_scaleTween != null)
                _scaleTween.PlayBackwards();
        }
    }
}