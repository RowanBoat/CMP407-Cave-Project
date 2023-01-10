using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour
{
    public GameObject player;
    public GameObject cave;

    private AudioSource ambience;
    private bool isUnderwater;
    private bool tempUnderwater;
    private Color normalColor;
    private Color underwaterColor;

    // Use this for initialization
    void Start()
    {
        normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        underwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
        ambience = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnderwater != tempUnderwater) 
        {        
            SetUnderwater(isUnderwater);
            tempUnderwater = isUnderwater;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            isUnderwater = true;
            ambience.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            isUnderwater = false;
            ambience.Stop();
        }
    }

    void SetUnderwater(bool isPlayerUnderwater)
    {
        if (isPlayerUnderwater)
        {
            cave.GetComponent<AudioSource>().pitch = 0.0f;
            RenderSettings.fogColor = underwaterColor;
            RenderSettings.fogDensity = 0.1f;
        }
        else 
        {
            cave.GetComponent<AudioSource>().pitch = 1f;
            RenderSettings.fogColor = normalColor;
            RenderSettings.fogDensity = 0.005f;
        }
        player.GetComponent<AudioSource>().mute = isPlayerUnderwater;
    }
}