using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelayScript : MonoBehaviour
{
    private AudioSource source;
    private float waitTimeCountdown = -1f;

    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float minPitch = -3f;
    public float maxPitch = 3f;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!source.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                source.pitch = Random.Range(minPitch, maxPitch);
                source.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}
