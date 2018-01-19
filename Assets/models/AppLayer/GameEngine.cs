﻿using System;
using DomainLayer;
using UnityEngine;

namespace AppLayer
{
    public class GameEngine : MonoBehaviour
    {
        //public GameObject[] PiecesObjects;

        private LevelManager levelManager;
        private IBoard board;

        void Awake()
        {
            levelManager = new LevelManager();
        }

        // Use this for initialization
        void Start()
        {
            PieceService.PiecesObjects = Resources.LoadAll<GameObject>("Prefabs/Pieces/");
            board = new BoardDefault();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
