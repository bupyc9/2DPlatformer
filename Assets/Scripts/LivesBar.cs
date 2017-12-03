﻿using UnityEngine;
using System.Collections;

public class LivesBar : MonoBehaviour {
    [SerializeField] private Character character;

    private Transform[] hearts = new Transform[5];

    private void Awake() {
        for (int i = 0; i < hearts.Length; i++) {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh() {
        for (int i = 0; i < hearts.Length; i++) {
            if(i < character.Lives) {
                hearts[i].gameObject.SetActive(true);
            } else {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
