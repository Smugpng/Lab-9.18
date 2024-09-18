using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : Meteor
{
    private int hitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = .5f;
        health = 5;
    }
    private void Update()
    {
        if (hitCount >= health)
        {
            CameraBehavior cb = FindAnyObjectByType<CameraBehavior>();
            cb.Shake();
        }
    }
}
