using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microwise.Guide
{
    public class GuideServer : MonoBehaviour
    {
        public GuideClient client;

        private TriggersController trigersController = TriggersController.controller;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                checkClients();
            }
        }

        private void checkClients()
        {
            trigersController.computeVoices(client.info, client.voices);
        }
    }
}
