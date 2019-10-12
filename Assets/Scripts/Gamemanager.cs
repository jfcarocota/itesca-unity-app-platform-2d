﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    [SerializeField]
    Score score;

    [SerializeField]
    AudioClip sfxCoin;

    [SerializeField]
    Datamanager datamanager;

    [SerializeField]
    Player player;

    GameData gameData;

    void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Vector2 pos = player.transform.position;
        gameData = new GameData(pos.x, pos.y);
        datamanager.SaveData(gameData);
    }

    void OnLevelWasLoaded(int level)
    {
        score.ResetScore();
    }

    public Score GetScore
    {
        get => score;
    }

    public AudioClip CoinSound
    {
        get => sfxCoin;
    }
    public Player Player { get => player; set => player = value; }
}
