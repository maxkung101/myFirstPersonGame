using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToYou : MonoBehaviour
{
    public AudioSource tickSource;

    // Start is called before the first frame update
    private void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tickSource.Play();
        }
    }
}
