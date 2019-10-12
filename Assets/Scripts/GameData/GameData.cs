﻿using System.Collections;
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

    public float PosX { get => posX; set => posX = value; }
    public float PosY { get => posY; set => posY = value; }

    public GameData(float posX, float posY)
    {
        this.posX = posX;
        this.posY = posY;
    }

    public GameData(){}
}