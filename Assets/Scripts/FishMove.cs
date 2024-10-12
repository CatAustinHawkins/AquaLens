using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FishMove : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;
    public GameObject[] Locations;

    public string GOtag;

    public GameObject CameraCheckGB;
    public CameraButton CBScript;

    public int random;

    public void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Locations = GameObject.FindGameObjectsWithTag(GOtag);
        random = Random.Range(0, 11);
        target = Locations[random].transform;
        
        CameraCheckGB = GameObject.FindWithTag("CameraCheck"); //find the player setup script
        CBScript = CameraCheckGB.GetComponent<CameraButton>();
        StartCoroutine(Delay());
    }

    public void Update()
    {
        agent.SetDestination(target.position);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == GOtag)
        {
            random = Random.Range(0, 4);
            target = Locations[random].transform;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(7.5f);
        random = Random.Range(0, 11);
        target = Locations[random].transform;
        StartCoroutine(Delay());
    }
}


