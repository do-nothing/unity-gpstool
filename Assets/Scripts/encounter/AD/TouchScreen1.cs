using UnityEngine;
using System.Collections;

public class TouchScreen1 : MonoBehaviour
{
    private static TouchScreen1 instance; 
#if UNITY_EDITOR
    public MovieTexture mt;
#endif
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
#if UNITY_EDITOR
        mt.Stop();
        mt.Play();
#endif
        audioSource.Stop();
        audioSource.Play();
    }
}
