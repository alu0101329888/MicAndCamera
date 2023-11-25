using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    public List<AudioSource> speakers;
    private AudioClip recorded;
    // Start is called before the first frame update
    void Start()
    {
        recorded = Microphone.Start(null, true, 3, 44100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (AudioSource speaker in speakers)
            {
                speaker.clip = recorded;
                speaker.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            print("Finished recording");
            Microphone.End(null);
        }
    }
}
