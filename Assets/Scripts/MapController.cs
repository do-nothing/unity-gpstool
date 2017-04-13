using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour {

    private Material material;
	void Start () {
        material = GetComponent<Image>().material;
	}
	
	void Update () {
        if (Input.touchCount == 1) {
            Vector2 offset = material.GetTextureOffset("_MainTex");
            offset.x += 0.1f;
            material.SetTextureOffset("_MainTex", offset);
        }
	}
}
