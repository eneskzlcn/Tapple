using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingStateControlComponent : MonoBehaviour
{
    [SerializeField] private Button[] buttonsWhichPauseGame;
    [SerializeField] private Button[] buttonsWhichContinueGame;
    private void Awake()
    {
        foreach(Button pauseButton in buttonsWhichPauseGame)
        {
            pauseButton.onClick.AddListener(()=>
            {
            ResourceManager.setGamePlayingState(false);
            PauseIfTheTime();
            });
        }
        foreach(Button continueButton in buttonsWhichContinueGame)
        {
            continueButton.onClick.AddListener(()=>
            {
            ResourceManager.setGamePlayingState(true);
            ContinueIfTheTime();
            });
        }
    }
    private void Update()
    {
        ContinueIfTheTime();
        PauseIfTheTime();
    }
    public void setGameState(bool gameState)
    {
        ResourceManager.setGamePlayingState(gameState);
    }
    public void PauseIfTheTime()
    {
        if(Time.timeScale==0){return;}
        if(!ResourceManager.isGameOnPlayingState())
        {
            Time.timeScale = 0;
        }
    }
    public void ContinueIfTheTime()
    {
        if(Time.timeScale==1){return;}        
        if(ResourceManager.isGameOnPlayingState())
       {
           Time.timeScale = 1;
       }
    }
}
