using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConfiguratingComponent : MonoBehaviour
{
    [SerializeField] private BubbleSpawnComponent bubbleSpawnComponent;
    [SerializeField] private PlayingStateControlComponent playingStateControlComponent;
    [SerializeField] private Button[] mainMenuConnectorButtons;
    private void Awake()
    {
        ConfigureGamePropertiesByGameMode();
        ConfigureDefaultGameProperties();
        foreach(Button connecterButton in mainMenuConnectorButtons)
        {
            connecterButton.onClick.AddListener(ConfigureDefaultGameProperties);
            connecterButton.onClick.AddListener(ConfigureGamePropertiesByGameMode);
        }
    }
    private void Start()
    {
        // we can give a time to wait before sleep --> Screen.sleepTimeout = 15f; (will game sleep after 15f)
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //SleepTimeout.SystemSetting-> will synch sleep time of game
                                                            // with user phones sleep settings.    
    }                                                  
    private void ConfigureGamePropertiesByGameMode()
    {
        float reappearTimeOfBubbles;
        float speedUpValue;
        float speedUpTime;
        float speedUpTimeGrowthValue;
        int naturallyDiedBubbleLimit;
        string gameMode = ResourceManager.getGameMode();
        switch(gameMode)
        {
        case "EASY":
            reappearTimeOfBubbles = 3.0f;
            speedUpValue = 0.3f;
            speedUpTime = 4.0f;
            speedUpTimeGrowthValue = 15.0f;
            naturallyDiedBubbleLimit = 30;
            break;

        case "NORMAL":
            reappearTimeOfBubbles = 2.5f;
            speedUpValue = 0.2f;
            speedUpTime = 5.0f;
            speedUpTimeGrowthValue = 12.0f;
            naturallyDiedBubbleLimit = 25;
            break;

        case "HARD":
            reappearTimeOfBubbles = 2.0f;
            speedUpValue = 0.18f;
            speedUpTime = 6.0f;
            speedUpTimeGrowthValue = 10.0f;
            naturallyDiedBubbleLimit = 20;
            break;

        case "EXPERT":
            reappearTimeOfBubbles = 1.0f; 
            speedUpValue = 0.18f;
            speedUpTime = 4.0f;
            speedUpTimeGrowthValue = 8.0f;
            naturallyDiedBubbleLimit = 10;
            break;

        default:
            reappearTimeOfBubbles = 1.0f;
            speedUpValue = 0.7f;
            speedUpTime = 1.0f;
            speedUpTimeGrowthValue = 8.0f;
            naturallyDiedBubbleLimit = 2;
            break;
        }

        bubbleSpawnComponent.setReappearTimeOfBubbles(reappearTimeOfBubbles);
        bubbleSpawnComponent.setSpeedUpTimeOfBubbles(speedUpTime);
        bubbleSpawnComponent.setSpeedUpValue(speedUpValue);
        bubbleSpawnComponent.setSpeedUpTimeGrowthValue(speedUpTimeGrowthValue);
        ResourceManager.setNaturallyDiedBubbleLimit(naturallyDiedBubbleLimit);
    }
    private void ConfigureDefaultGameProperties()
    {
        // The HighScore kept in PlayerPrefs ---> need to take the value on configuration.So->
        /// control for easy-normal-hard-expert
        bubbleSpawnComponent.setPassingTimeAfterStart(0);
        ResourceManager.setGamePlayingState(true);
        ResourceManager.setGameOverState(false);
        ResourceManager.setScore(0);
        ResourceManager.setNaturallyDiedBubbleNumber(0);
        playingStateControlComponent.ContinueIfTheTime();//to provide game not stuck in pause mode
    }
}
