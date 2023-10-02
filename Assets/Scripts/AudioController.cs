using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioController : MonoBehaviour
{

    private AudioSource audioSource;

    [SerializeField] 
    private AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
    }
}
