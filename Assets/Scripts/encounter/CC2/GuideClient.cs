using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Microwise.Guide
{
    public class GuideClient : MonoBehaviour
    {
        private AudioSource audioSource;
        private bool isBusy = false;
        internal LinkedList<string> voices = new LinkedList<string>();
        internal VisitorInfo info;

#pragma warning disable 0414
        [SerializeField]
        private Vector3 position;
        [SerializeField]
        private Vector2 toward;
        [SerializeField]
        private VisitorInfo.Status status;
        [SerializeField]
        private List<string> voiceslist;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            //info.location = transform.position;
            //info.toward = new Vector2(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);
            showInfo();

            if (!audioSource.isPlaying)
            {
                if (isBusy)
                    voices.RemoveFirst();
                if (voices.Count > 0)
                {
                    string[] messages = voices.First.Value.Split(':');
                    switch (messages[0])
                    {
                        case "":
                            break;
                        case "play":
                            audioSource.clip = getAudioClip(messages[1]);
                            audioSource.Play();
                            break;
                        case "command":
                            SendMessage("command",messages[1]);
                            break;
                    }
                    isBusy = true;
                }
                else
                {
                    isBusy = false;
                }
            }
        }

        public void setVisitorInfo(float x, float y, float toward, VisitorInfo.Status status)
        {
            Vector3 p = new Vector3(x, 0, y);
            info.location = p;
            Vector2 t = new Vector2(0, toward);
            info.toward = t;
            info.status = status;
        }

        public LinkedList<string> getVoiceList()
        {
            return voices;
        }

        private AudioClip getAudioClip(string filePath)
        {
            AudioClip clip = (AudioClip)Resources.Load(filePath, typeof(AudioClip));
            return clip;
        }

        private void showInfo()
        {
            position = info.location;
            toward = info.toward;
            status = info.status;
            voiceslist = new List<string>(voices);
        }
    }
}