using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip RuningSound, JumpSound, DeathSound, SlidSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        RuningSound = Resources.Load<AudioClip>("PlayerRun");
        JumpSound = Resources.Load<AudioClip>("PlayerJump");
        DeathSound = Resources.Load<AudioClip>("PlayerDie");
        SlidSound = Resources.Load<AudioClip>("PlayerSlid");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "PlayerRun":
                audioSrc.PlayOneShot(RuningSound);
                break;
            case "PlayerJump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "PlayerDie":
                audioSrc.PlayOneShot(DeathSound);
                break;
            case "PlayerSlid":
                audioSrc.PlayOneShot(SlidSound);
                break;
        }
    }
}
