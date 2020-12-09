using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager
{
    private static int naturallyDiedBubbleNumber = 0;
    private static int score = 0;
    private static string gameMode = "Null";
    private static bool isThereAMusic = true;
    private static int naturallyDiedBubbleLimit = 0;
    private static bool gamePlayingState = true;
    private static bool gameOverState = false;

    public static void setScore(int newScore)
    {
        score=newScore;
    }
    public static void setNaturallyDiedBubbleNumber(int bubbleNumber)
    {
        naturallyDiedBubbleNumber = bubbleNumber;
    }
    public static void setNaturallyDiedBubbleLimit(int limit)
    {
        naturallyDiedBubbleLimit = limit;
    }
    public static int getNaturallyDiedBubbleLimit()
    {
        return naturallyDiedBubbleLimit;
    }
    public static int getNaturallyDiedBubbleNumber()
    {
        return naturallyDiedBubbleNumber;
    }
    public static  void increaseDeadBubbleNumber()
    {
        naturallyDiedBubbleNumber++;
    }
    public static void increaseScore()
    {
        int gainedScore = Random.Range(200,800);
        score+=gainedScore;
    }
    public static int getScore(){
        return score;
    }
    public static void setGameMode(string chosenGameMode)
    {
        gameMode = chosenGameMode;
    }
    public static string getGameMode()
    {
        return gameMode;
    }
    public static void setMusicMode(bool isMusicOn)
    {
        isThereAMusic = isMusicOn;
    }
    public static bool getMusicMode() 
    {
        return  isThereAMusic;
    }
    public static bool isGameOnPlayingState()
    {
        return gamePlayingState;
    }
    public static void setGamePlayingState(bool isGameOnPlay)
    {
        gamePlayingState = isGameOnPlay;
    }
    public static bool getGameOverState()
    {
        return gameOverState;
    }
    public static void setGameOverState(bool newGameOverState)
    {
        gameOverState = newGameOverState;
    }
}
