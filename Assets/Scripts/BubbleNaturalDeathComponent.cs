using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleNaturalDeathComponent : MonoBehaviour
{
    private float lifeTime = 2.0f;
    private float bornTime;
    private Text naturallyDeadBubbleNumber;
    private System.Action onDeath;
    public void AddOnDeathListener(System.Action listener)
    {
        onDeath+=listener;
    }
    public void ClearOnDeathListener()
    {
        onDeath=null;
    }
    void Awake()
    {
        bornTime = Time.time;
    }
    void Update()
    {
        IfTimeDieNaturelly();  
    }
    private void IfTimeDieNaturelly()
    {
        if(bornTime + lifeTime <= Time.time)
        {
            Destroy(gameObject);
            onDeath?.Invoke();
        }
    }

}
