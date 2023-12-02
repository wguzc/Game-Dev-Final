using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCAT_AIWalk : MonoBehaviour
{

    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform[] moveSpot;
    private int randomSpot;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpot.Length);
        
    }

    void Update()
    {
    // Check if moveSpots array is not empty
    if (moveSpot.Length > 0)
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpot.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    else
    {
        Debug.LogWarning("No move spots defined. Please assign moveSpots in the Unity Editor.");
    }
    }
}