using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BubbleSpawnComponent : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private AudioManagementComponent audioManagementComponent;
    private float timer;//this is a timer to take control of bubble spawning
    private float passingTimeAfterStart;
    private float reappearTimeOfBubbles; //the time program waits to spawn another bubble on screen
    private float speedUpTime;//if game time is equal or greater than this speedUpTime, the spawning speed of bubbles will up
    private float speedUpValue; //speed up value makes the reappear time decreased ----> so it make speed up in different way...
    private float speedUpTimeGrowthValue;
    private float minPositionXToSpawnBubble;
    private float minPositionYToSpawnBubble;
    private float maxPositionXToSpawnBubble;
    private float maxPositionYToSpawnBubble;
    private System.Action<GameObject> onSpawn;
    public void AddOnSpawnListener(System.Action<GameObject> listener)
    {
        onSpawn+=listener;
    }
    public void ClearOnSpawnListeners()
    {
        onSpawn = null;
    }
    private void Awake()
    {
        createBubbleSpawnAreaPositions();
    }
    private void Update()
    {
        IfTimeThenSpawnABubble();
        IfTimeThenSpeedUp();
        
    }
    private void Spawn(){
        float randomXPositionInSpawnArea = Random.Range(minPositionXToSpawnBubble,maxPositionXToSpawnBubble);
        float randomYPositionInSpawnArea = Random.Range(minPositionYToSpawnBubble,maxPositionYToSpawnBubble);
        Vector3 bubbleSpawnPosition = new Vector3(randomXPositionInSpawnArea,randomYPositionInSpawnArea);
        GameObject bubble = Instantiate(bubblePrefab,bubbleSpawnPosition,Quaternion.identity);
        onSpawn?.Invoke(bubble);
        audioManagementComponent.Play("BubbleSpawnSound");
    }
    private void IfTimeThenSpeedUp()
    {
        passingTimeAfterStart+=Time.deltaTime;
        if(reappearTimeOfBubbles <= 0.3){return; }

        if(passingTimeAfterStart >= speedUpTime)
        {  
            reappearTimeOfBubbles -=speedUpValue;
            speedUpTime+=12;
        }
    }
    private void IfTimeThenSpawnABubble()
    {
        timer+=Time.deltaTime;
        if(timer>= reappearTimeOfBubbles)
        {
            Spawn();
            timer = timer-reappearTimeOfBubbles;
        }
    }
    public void setReappearTimeOfBubbles(float reaappearTime)
    {
        reappearTimeOfBubbles = reaappearTime;
    }
    public void setSpeedUpTimeOfBubbles(float speedTime)
    {
        speedUpTime = speedTime;
    }
    public void setSpeedUpValue(float speedValue)
    {
        speedUpValue = speedValue;
    }
    public void setSpeedUpTimeGrowthValue(float growthValue)
    {
        speedUpTimeGrowthValue = growthValue;
    }
    public void setPassingTimeAfterStart(float time)
    {
        passingTimeAfterStart = time;
    }
    public float getPassingTimeAfterStart()
    {
        return passingTimeAfterStart;
    }
    public void createBubbleSpawnAreaPositions()
    {
        //140.5pix --> spaces for right and left,bot
        //320px ---> space for top;
        //150.5f ---> space for bottom;
        Vector3 bottomLeftBoundScreenPosition = new Vector3(140.5f,150.5f,10);//+140.5f,150.5f --> tried and fixed
        Vector3 topRightBoundScreenPosition = new Vector3(cam.pixelWidth-140.5f,cam.pixelHeight-320f); //width-140.5f,height-320f;
        Vector3 bottomLeftBoundWorldPosition = cam.ScreenToWorldPoint(bottomLeftBoundScreenPosition);
        Vector3 topRightBoundWorldPosition = cam.ScreenToWorldPoint(topRightBoundScreenPosition);
        minPositionXToSpawnBubble = bottomLeftBoundWorldPosition.x;
        minPositionYToSpawnBubble = topRightBoundWorldPosition.y;
        maxPositionYToSpawnBubble = bottomLeftBoundWorldPosition.y;
        maxPositionXToSpawnBubble = topRightBoundWorldPosition.x;
    }
}
