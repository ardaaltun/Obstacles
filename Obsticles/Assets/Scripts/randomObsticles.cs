using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomObsticles : MonoBehaviour
{
    Transform[] spawnPoints;
    public GameObject box;
    GameObject intedLeft;
    GameObject intedMid;
    GameObject intedRight;
    bool spawned = false;
    bool spawnedLeft;
    bool spawnedMid;
    bool spawnedRight;
    float movement = -5f;
    // Update is called once per frame

    private void Start()
    {

        spawnPoints = gameObject.GetComponentsInChildren<Transform>();
        Invoke("Spawner",0f);
    }
    void Update()
    {

        if (!spawned)
        {
            Invoke("Spawner", 5f);
            spawned = true;
        }
        if(intedLeft)
            intedLeft.transform.localPosition += new Vector3(0f, 0f, movement) * Time.deltaTime;
        if (intedMid)
            intedMid.transform.localPosition += new Vector3(0f, 0f, movement) * Time.deltaTime;
        if (intedRight)
            intedRight.transform.localPosition += new Vector3(0f, 0f, movement) * Time.deltaTime;

        /*
        if(intedMid && intedRight)
        {
            if (intedMid.transform.localPosition.z <= -15) Destroy(intedMid);
            if (intedRight.transform.localPosition.z <= -15) Destroy(intedRight);
        }
        if (intedLeft && intedRight)
        {
            if (intedLeft.transform.localPosition.z <= -15) Destroy(intedLeft);
            if (intedRight.transform.localPosition.z <= -15) Destroy(intedRight);
        }
        if (intedMid && intedLeft)
        {
            if (intedMid.transform.localPosition.z <= -15) Destroy(intedMid);
            if (intedLeft.transform.localPosition.z <= -15) Destroy(intedLeft);
        }
        */

    }

    private void Spawner()
    {
        spawned = false;
        // 1 = left
        // 2 = mid
        // 3 = right
        var selectUnSpawned = Random.Range(1, spawnPoints.Length);
       
        if (selectUnSpawned == 1) // do not spawn left
        {
            intedMid = Instantiate(box);
            intedMid.transform.localPosition = spawnPoints[2].position;
            intedRight = Instantiate(box);
            intedRight.transform.localPosition = spawnPoints[3].position;
        }

        if (selectUnSpawned == 2) //do not spawn mid
        {
            intedLeft = Instantiate(box);
            intedLeft.transform.localPosition = spawnPoints[1].position;
            intedRight = Instantiate(box);
            intedRight.transform.localPosition = spawnPoints[3].position;
        }

        if (selectUnSpawned == 3) //do not spawn right
        {
            intedLeft = Instantiate(box);
            intedLeft.transform.localPosition = spawnPoints[1].position;
            intedMid = Instantiate(box);
            intedMid.transform.localPosition = spawnPoints[2].position;
            
        }


        /*
    spawned = false;

    inted = Instantiate(box);
    inted.transform.localPosition = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
    */

    }
}
