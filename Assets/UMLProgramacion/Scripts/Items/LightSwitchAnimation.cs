using DG.Tweening;
using UnityEngine;

namespace Items
{
    public class LightSwitchAnimation : MonoBehaviour
    {
        [Header("Open Tween animation")] 
        [SerializeField] private Transform pivotPoint;
        [SerializeField] private Vector3 newPivotRotation;
        [Space]
        [SerializeField] private Ease openEase;
        [SerializeField] private float openTweenDuration;
    
        [Header("Close Tween animation")]
        [SerializeField] private Ease closeEase;
        [SerializeField] private float closeTweenDuration;

        private Tween _rotateAroundPivotTween;
        private Quaternion _initialRotation;
        
        private void Awake()
        {
            _initialRotation = pivotPoint.localRotation;
        }
        
        public void PlayTurnOnAnimation()
        {
            RotateAroundPivot(newPivotRotation, openTweenDuration,openEase);
        }

        public void PlayTurnOffAnimation()
        {
            RotateAroundPivot(_initialRotation.eulerAngles, closeTweenDuration,closeEase);
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