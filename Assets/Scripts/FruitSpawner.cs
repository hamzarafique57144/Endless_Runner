using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruits;
    public Transform[] spawnPoints;
    public float minDelay = 0.1f;
    public float maxDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFruit()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
          GameObject unSlicedFruit= Instantiate(fruits,spawnPoint.position,spawnPoint.rotation);
            Destroy(unSlicedFruit, 3f);
        }
    }
}
