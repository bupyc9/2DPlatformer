using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Character))]
public class CameraController : MonoBehaviour {
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject respawn;

    private void Update() {
        var position = target.position;
        position.z = -10f;
        position.y = 0;

        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
