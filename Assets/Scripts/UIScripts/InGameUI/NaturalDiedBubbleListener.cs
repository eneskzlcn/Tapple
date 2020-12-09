using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaturalDiedBubbleListener : MonoBehaviour
{
    [SerializeField] BubbleSpawnComponent bubbleSpawnComponent;
    void Awake()
    {
        bubbleSpawnComponent.AddOnSpawnListener(OnBubbleSpawn);
    }
    private void OnBubbleSpawn(GameObject bubble)
    {
        bubble.GetComponent<BubbleNaturalDeathComponent>().
        AddOnDeathListener(increaseDeathCountAndSetText);
    }
    private void increaseDeathCountAndSetText()
    {
        ResourceManager.increaseDeadBubbleNumber();
        gameObject.GetComponent<Text>().text = 
        ResourceManager.getNaturallyDiedBubbleNumber().ToString();
    }
}
