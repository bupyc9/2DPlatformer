﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collider) {
        var character = collider.GetComponent<Character>();

        if (character) {
            Destroy(gameObject);
        }
    }
}