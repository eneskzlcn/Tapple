using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutAnimationScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button gameStarterButton;
    [SerializeField] private Button[] menuReturnerButtons;
    private int sceneToLoadIndex;
    
    private void Awake()
    {
      if(gameStarterButton != null){
        gameStarterButton.onClick.AddListener(delegate
        {
            FadeToScene(1);
        });
      }
      if(menuReturnerButtons.Length != 0)
      {
        foreach(Button b in menuReturnerButtons)
        {
            b.onClick.AddListener(delegate
              {
                  FadeToScene(0);
              });
        }
      }
        
    }   
    void Update()
    {

    }
    public void FadeToScene(int sceneIndex)
    {
        sceneToLoadIndex = sceneIndex;
        animator.SetTrigger("FadeOut");
    }
    private void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoadIndex);
    }
}
