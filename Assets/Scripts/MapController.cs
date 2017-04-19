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
    private Vector4 player;
    private GpsServer gpsServer;

	void Start () {
        material = GetComponent<Image>().material;
        gpsServer = GetComponent<GpsServer>();
        offset = material.GetTextureOffset("_BgTex");
        tiling = material.GetTextureScale("_BgTex");

        if (!Input.gyro.enabled)
            Input.gyro.enabled = true;

	}
	
	void Update () {
        player = material.GetVector("_Target");
        spinPlayer();
        placePlayer();
        material.SetVector("_Target", player);

        screenControl();

	}

    private void playerInTheCenter()
    {
        offset.x = player.x * 0.004f;
        offset.y = player.y * 0.004f;
        material.SetTextureOffset("_BgTex", offset);
    }

    private void placePlayer()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            player = gpsServer.getHorizontal();
        }
    }

    private void spinPlayer()
    {
        float compass;
        Quaternion quaternion = Input.gyro.attitude;
        quaternion.z *= -1;
        quaternion.w *= -1;

        Vector3 zforward = quaternion * new Vector3(0, 0, 1);
        float az = getRfromXY(zforward.y, zforward.x);

        Vector3 yforward = quaternion * new Vector3(0, 1, 0);
        float ay = getRfromXY(yforward.y, yforward.x);

        float g = Vector3.Dot(zforward, new Vector3(0, 0, 1));
        g = Mathf.Acos(g);

        compass = g > Mathf.PI / 4 ? az : ay;
        compass *= Mathf.Rad2Deg;
        player.w = compass;
    }

    private float getRfromXY(float y, float x)
    {
        float r = Mathf.Atan2(y, x);
        r -= Mathf.PI / 2;
        r = r < 0 ? r + 2 * Mathf.PI : r;
        return r;
    }

    private void screenControl()
    {
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
                material.SetTextureOffset("_BgTex", offset);
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
                    material.SetTextureScale("_BgTex", tiling);
					lastDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch (1).position);
				}
			}
		}
    }
}