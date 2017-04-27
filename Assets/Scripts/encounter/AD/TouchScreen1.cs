using UnityEngine;
using System.Collections;

public class TouchScreen1 : MonoBehaviour
{
    private static TouchScreen1 instance; 
    public MovieTexture mt;
    private AudioSource audioSource;

    public static TouchScreen1 getInstance()
    {
        return instance;
    }

	void Start () {
        audioSource = GetComponent<AudioSource>();
        //playVideo();
        instance = this;
    }

    public void playVideo()
    {
        mt.Stop();
        audioSource.Stop();
        mt.Play();
        audioSource.Play();
    }
}
