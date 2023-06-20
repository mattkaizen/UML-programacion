using DG.Tweening;
using UnityEngine;

namespace Repairables
{
    public class ElectricityPanelAnimation : MonoBehaviour
    {
        [Header("Close Panel Tween animation")] 
        [SerializeField] private Transform pivotPoint;
        [SerializeField] private Vector3 newPivotRotation;
        [Space]
        [SerializeField] private Ease turnOffEase;
        [SerializeField] private float turnOffTweenDuration;

        private Tween _rotateAroundPivotTween;

        public void PlayCloseAnimation()
        {
            RotateAroundPivot(newPivotRotation, turnOffTweenDuration,turnOffEase);
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