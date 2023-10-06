using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource introSoure, loopSource;
    // Start is called before the first frame update
    void Start()
    {
        introSoure.Play();
        loopSource.PlayScheduled(AudioSettings.dspTime + introSoure.clip.length);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
