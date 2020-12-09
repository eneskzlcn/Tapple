using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class BubbleTappingControlComponent : MonoBehaviour
{
    [SerializeField] private GameObject scoreText;
    [SerializeField] private LayerMask bubbleLayerMask;
    [SerializeField] private PlayingStateControlComponent playingStateControlComponent;
    [SerializeField] private AudioManagementComponent audioManagementComponent;

    private TextMeshProUGUI scoreTMP;
    private Tween DOScaleTween;
    
    private void Awake()
    {
        scoreTMP = scoreText.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        KillBubbleIfTapped();
    }
    private void KillBubbleIfTapped(){

        if(Input.GetMouseButtonDown(0) && (ResourceManager.isGameOnPlayingState()))//if not game is paused
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero,bubbleLayerMask);
            if (hit.collider != null)
            {
                Vector3 scaleVector = scoreText.transform.localScale;
                scoreText.transform.localScale = Vector3.zero;
                DOScaleTween?.Kill();
                DOScaleTween = scoreText.transform.DOScale(
                   scaleVector,
                   Random.Range(0.5f,1.5f)
                ).SetEase(Ease.OutElastic).OnKill(()=>
                {
                    scoreText.transform.localScale = scaleVector;
                }).OnComplete(()=>
                {
                    scoreText.transform.localScale = scaleVector;
                });
                Destroy(hit.collider.gameObject);  
                audioManagementComponent.Play("BubblePop");   
                ResourceManager.increaseScore();
                scoreTMP.text = ResourceManager.getScore().ToString();          
           }
        }
    }
}
