﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

    private Vector3 nextGen;
    public GameObject block;

    private void Start()
    {
        nextGen = transform.position + new Vector3(0, 0, 8);
    }

    private void GenerateBlock()
    {
        Instantiate(block, nextGen, Quaternion.identity);
        nextGen += new Vector3(0, 0, 8);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, nextGen) < 8)
        {
            GenerateBlock();
        }
    }
}