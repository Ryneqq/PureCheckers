﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//accept a draw
public class Accept : MonoBehaviour {

    public void Clicked()
    {
        Variables.WhiteDraw = true;
        if (Variables.BlackDraw == true && Variables.WhiteDraw == true)
        {
            GameObject.Find("Main Camera").GetComponent<Draw>().Spawn();
        }
    }
}
