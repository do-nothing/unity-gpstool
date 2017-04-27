using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule1Controller : MonoBehaviour {
    private static Capsule1Controller instance;

    private void Start()
    {
        instance = this;
    }

    public static Capsule1Controller getInstance()
    {
        return instance;
    }

    public void glisten()
    {
        print("I am Glistenning");
    }

    //private 
}
