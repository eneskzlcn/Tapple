using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOverControlComponent : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gotHighScoreText;
    [SerializeField] private GameObject highScoreValueText;
    [SerializeField] private GameObject scoreText;
    private TextMeshProUGUI highScoreValueTMP;
    private TextMeshProUGUI scoreTMP;
    

    private void Awake()
    {
        highScoreValueTMP = highScoreValueText.GetComponent<TextMeshProUGUI>();
        scoreTMP = scoreText.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(ResourceManager.getNaturallyDiedBubbleNumber()>= ResourceManager.getNaturallyDiedBubbleLimit())
        {
            ResourceManager.setGameOverState(true);
            ResourceManager.setGamePlayingState(false);
            OpenAndFillGameOverMenu(); 
        }
    }
    private void OpenAndFillGameOverMenu()
    {
        gameOverPanel.SetActive(true);
        scoreTMP.text = "Score: "+ResourceManager.getScore().ToString();
        if(ResourceManager.getScore()> PlayerPrefs.GetInt(ResourceManager.getGameMode()))
        {
            gotHighScoreText.SetActive(true);
            highScoreValueText.SetActive(false);
            //Save the highscore for each game mode
            // independent from game. --> PlayerPrefs...("Easy","Normal" etc.);
            PlayerPrefs.SetInt(ResourceManager.getGameMode(),ResourceManager.getScore());
            
        }
        else
        {
            highScoreValueText.SetActive(true);
            gotHighScoreText.SetActive(false);  
            highScoreValueTMP.text = "Highscore: "+PlayerPrefs.GetInt(ResourceManager.getGameMode()).ToString();             
        }
    }
}
