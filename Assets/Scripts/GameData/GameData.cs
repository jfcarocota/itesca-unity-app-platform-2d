using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    [SerializeField]
    float posX;
    [SerializeField]
    float posY;

    public GameData(float posX, float posY)
    {
        this.posX = posX;
        this.posY = posY;
    }
}
