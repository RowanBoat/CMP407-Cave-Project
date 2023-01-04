using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private AudioSource source;
    private Animator anim;
    private float waitTimeCountdown = -1f;

    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float minPitch = -3f;
    public float maxPitch = 3f;

    void Start()
    {
        // Insert Change
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.Play("Base Layer.SBird2_Look_Anim", 0, Random.Range(0f, 0.8f));
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
