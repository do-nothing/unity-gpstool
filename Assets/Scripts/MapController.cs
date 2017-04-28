using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microwise.Guide;
using System.Text;

public class MapController : MonoBehaviour {

    private Material material;
	private Vector2 offset;
	private Vector2 tiling;
	private float lastDistance;
	private bool moveable = false;
    private Vector4 player;
    private GpsServer gpsServer;
    private Material btMaterial;
    private bool isPlayerInCenter = false;
    private Text text;
    
    private readonly Vector4 newPlayer = new Vector4(345, 81, 0, 0);
    public GameObject bt;
    public GuideClient guideClient;

	void Start () {
        text = GameObject.Find("Canvas/Text1").GetComponent<Text>();
        material = GetComponent<Image>().material;
        btMaterial = bt.GetComponent<Image>().material;
        btMaterial.SetTextureOffset("_MainTex", Vector2.zero);
        gpsServer = GetComponent<GpsServer>();
        offset = material.GetTextureOffset("_BgTex");
        tiling = material.GetTextureScale("_BgTex");
        Texture2D triggers = TiggersBuilder.getTexture();
        material.SetTexture("_triggers", triggers);
        material.SetVector("_Target", newPlayer);

        if (!Input.gyro.enabled)
            Input.gyro.enabled = true;

	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        player = material.GetVector("_Target");
        placePlayer();
        spinPlayer();
        material.SetVector("_Target", player);

        setGuideClient();

        screenControl();
        if (isPlayerInCenter)
        {
            playerInTheCenter();
        }

        printVoices();
	}

    private void printVoices()
    {
        StringBuilder stringBuilder = new StringBuilder();
        LinkedList<string> voices = guideClient.getVoiceList();
        foreach (string voice in voices)
        {
            stringBuilder.Append("\n" + voice);
        }

        text.text = stringBuilder.ToString();
    }

    private void setGuideClient()
    {
        Vector4 clientOffset = player - newPlayer;
        VisitorInfo.Status status = gpsServer.getStatus();
        guideClient.setVisitorInfo(clientOffset.x, clientOffset.y, clientOffset.w, status);
    }

    private void playerInTheCenter()
    {
        offset.x = player.x * 0.004f - 1;
        offset.y = player.y * 0.004f - 1;
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
        if (Input.location.status != LocationServiceStatus.Running)
            return;
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

                if (isPlayerInCenter)
                {
                    isPlayerInCenter = false;
                    btMaterial.SetTextureOffset("_MainTex", Vector2.zero);
                }
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

    public void putPlayerInCenter()
    {
        isPlayerInCenter = true;
        btMaterial.SetTextureOffset("_MainTex", new Vector2(0.5f, 0));
    }
}