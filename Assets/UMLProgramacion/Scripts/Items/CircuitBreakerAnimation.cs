using DG.Tweening;
using UnityEngine;

namespace Items
{
    public class CircuitBreakerAnimation : MonoBehaviour
    {
        [Header("Turn On Tween animation")] 
        [SerializeField] private Transform pivotPoint;
        [SerializeField] private Vector3 newPivotRotation;
        [Space]
        [SerializeField] private Ease turnOnEase;
        [SerializeField] private float turnOnTweenDuration;
    
        [Header("Turn off Tween animation")]
        [SerializeField] private Ease turnOffEase;
        [SerializeField] private float turnOffTweenDuration;

        private Tween _rotateAroundPivotTween;
        private Quaternion _initialRotation;
        
        private void Awake()
        {
            _initialRotation = pivotPoint.localRotation;
        }
        
        public void PlayTurnOnAnimation()
        {
            RotateAroundPivot(newPivotRotation, turnOnTweenDuration,turnOnEase);
        }

        public void PlayTurnOffAnimation()
        {
            RotateAroundPivot(_initialRotation.eulerAngles, turnOffTweenDuration,turnOffEase);
        }

        private void RotateAroundPivot(Vector3 newRotation, float tweenDuration, Ease ease)
        {
            if(_rotateAroundPivotTween != null)
                _rotateAroundPivotTween.Kill();
        
            _rotateAroundPivotTween = pivotPoint.DOLocalRotate(newRotation, tweenDuration).SetEase(ease);
            _rotateAroundPivotTween.Play();
        }
    }
}