using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneComponent : MonoBehaviour
{
    [SerializeField] FadeOutAnimationScript fadeOutAnimationScript;
    int currentSceneIndex;
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void ControlGameModeAndLoadNextScene()
    {
        if(ResourceManager.getGameMode() == "Null"){return;}
        fadeOutAnimationScript.FadeToScene(currentSceneIndex+1);
    }
}
