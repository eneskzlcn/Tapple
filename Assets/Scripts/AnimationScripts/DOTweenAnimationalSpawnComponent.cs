using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenAnimationalSpawnComponent : MonoBehaviour
{
    [SerializeField] private float minAnimationDuration;
    [SerializeField] private float maxAnimationDuration;
    [SerializeField] private float maxJiggle;
    [SerializeField] private float minJiggle;

    private void Awake()
    {
        
         DOScaleAnimate();

    }
    public void DOScaleAnimate()
    {
        Vector3 scaleVector = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(
           scaleVector,
           Random.Range(minAnimationDuration,maxAnimationDuration)
        ).SetEase(Ease.OutElastic);

    }
    public void DOPunchPosAnimate()
    {
         transform.DOPunchPosition(
         Vector3.one * Random.Range(minJiggle,maxJiggle),
         Random.Range(minAnimationDuration,maxAnimationDuration),
         1,1,false
         );

    }

}
