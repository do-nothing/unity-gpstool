using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour {

    private Material material;
	private Vector2 offset;
	private Vector2 tiling;
	private float lastDistance;
	private bool moveable = false;

	void Start () {
        material = GetComponent<Image>().material;
		offset = material.GetTextureOffset("_MainTex");
		tiling = material.GetTextureScale("_MainTex");
	}
	
	void Update () {
        if (Input.touchCount == 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				moveable = true;
			}
            if (moveable && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                float deltaX = Input.GetAxis("Mouse X") / 200;
                float deltaY = Input.GetAxis("Mouse Y") / 200;

				offset.x -= deltaX * tiling.x;
				offset.y -= deltaY * tiling.x;
                material.SetTextureOffset("_MainTex", offset);
            }
        }

		if (Input.touchCount == 2) {
			if (Input.GetTouch (1).phase == TouchPhase.Began) {
				moveable = false;
				lastDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch (1).position);
			}
			if (Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (1).phase == TouchPhase.Moved) {
				float distance = Vector2.Distance (Input.GetTouch (0).position, Input.GetTouch (1).position);
				if ((tiling.x >= 0.5f && distance > lastDistance) || (tiling.x < 5 && distance < lastDistance)) {
					tiling.x *= lastDistance / distance;					
					material.SetTextureScale ("_MainTex", tiling);
					lastDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch (1).position);
				}
			}
		}
	}
}