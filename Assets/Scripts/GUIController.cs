using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GUIController : MonoBehaviour {
    public void Fire() {
        CrossPlatformInputManager.SetButtonDown("Fire1");
    }
}
