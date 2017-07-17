using Microwise.Guide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggersBuilder {
    private TiggersBuilder()
    {

    }
    private static int scale = 4;
    private static Texture2D texture;

    static TiggersBuilder()
    {
        texture = new Texture2D(60 * scale, 60 * scale);
        drawBG();
        drawTriggers();
        texture.Apply();
    }

    public static Texture2D getTexture()
    {
        return texture;
    }

    private static void drawBG()
    {
        Color[] cols = texture.GetPixels();
        //Debug.Log(cols.Length);
        for (int i = 0; i < cols.Length; i++)
        {
            cols[i] = new Color(1, 1, 1, 0);
        }
        texture.SetPixels(cols);
    }

    private static void drawTriggers()
    {
        List<Vector3> triggers = TriggersController.controller.getTriggers();

        foreach(Vector3 trigger in triggers){
            Vector3 v = trigger + new Vector3(1.2f, 19.2f, 0);
            drawTrigger(v);
        }
    }

    private static void drawTrigger(Vector3 trigger)
    {
        trigger *= scale;
        Vector2 center = new Vector2(trigger.x, trigger.y);
        float squareZ = trigger.z * trigger.z;
        for (int i = 0; i < trigger.z; i++)
        {
            float y = Mathf.Sqrt(squareZ - i*i);
            for (int j = 0; j < y; j++)
            {
                drawPixels(center, i, j);
            }
        }
    }

    private static void drawPixels(Vector2 center, int x, int y)
    {
        Color color = new Color(1, 0, 0, 0.2f);
        int _x = (int)center.x;
        int _y = (int)center.y;
        setPixel(_x + x, _y + y, color);
        setPixel(_x - x, _y + y, color);
        setPixel(_x - x, _y - y, color);
        setPixel(_x + x, _y - y, color);
    }

    private static void setPixel(int x, int y, Color color)
    {
        if (x < 0 || x > texture.width)
            return;
        if (y < 0 || y > texture.height)
            return;

        texture.SetPixel(x, y, color);
    }
}
