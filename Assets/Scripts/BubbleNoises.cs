using System.Collections;
using UnityEngine;

public class BubbleNoises : MonoBehaviour
{
    public AudioSource[] Bubbles;

    public void Start()
    {
        StartCoroutine(BubbleNoise());
    }

    IEnumerator BubbleNoise()
    {
        int random = Random.Range(0, 4);
        Bubbles[random].Play();
        int random2 = Random.Range(10, 25);
        yield return new WaitForSecondsRealtime(random2);
        StartCoroutine(BubbleNoise());
    }
}