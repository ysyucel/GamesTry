using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour {
    public AudioClip startClip,correctClip,wrongClip,timerClip;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playStartSound()
    {
        audioSource.PlayOneShot(startClip, 0.7F);
    }
    public void playCorrectSound() {
        audioSource.PlayOneShot(correctClip, 0.7F);
    }
    public void playWrongSound()
    {
        audioSource.PlayOneShot(wrongClip, 0.7F);
    }
    public void playTimerSound()
    {
        audioSource.PlayOneShot(timerClip, 0.7F);
    }
    public void pauseTimerSound()
    {
        audioSource.Pause();
    }
    public void resumeTimerSound()
    {
        audioSource.UnPause();
    }
}
