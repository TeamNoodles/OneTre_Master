﻿using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    float speed = 2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, -speed / 10);

    }
}