using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    public GameObject[] Fish;

    public int RandomValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnPause());
    }

    IEnumerator EnemySpawnPause()
    {
        Instantiate(Fish[Random.Range(0, 6)], transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(Random.Range(1f, 4f));
        StartCoroutine(EnemySpawnPause());
    }

}