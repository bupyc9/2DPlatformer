﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {
    public void Reload () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
