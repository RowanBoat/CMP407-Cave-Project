using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour
{
    private bool isUnderwater;
    private bool tempUnderwater;
    private Color normalColor;
    private Color underwaterColor;

    // Use this for initialization
    void Start()
    {
        normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        underwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            isUnderwater = false;
        }
    }

    void SetUnderwater(bool Underwater)
    {
        if (Underwater)
        {
            RenderSettings.fogColor = underwaterColor;
            RenderSettings.fogDensity = 0.1f;
        }
        else 
        {
            RenderSettings.fogColor = normalColor;
            RenderSettings.fogDensity = 0.005f;
        }
    }
}