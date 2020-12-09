using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagement : MonoBehaviour
{
    public void ControlMusicBeing(bool isThereAMusic)
    {
        ResourceManager.setMusicMode(isThereAMusic); 
    }
}
