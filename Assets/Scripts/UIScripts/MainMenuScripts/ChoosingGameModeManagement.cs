using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingGameModeManagement : MonoBehaviour
{
   

   public void ChooseGameMode(string gameMode)
   {
       if(gameMode != "EASY" && gameMode != "NORMAL" && gameMode!= "HARD" && gameMode != "EXPERT"){return;}
       ResourceManager.setGameMode(gameMode);
   }
}
