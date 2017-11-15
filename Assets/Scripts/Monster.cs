using UnityEngine;
using System.Collections;

public class Monster : Unit {
    protected virtual void Awake() {

    }

    protected virtual void Start() {

    }

    protected virtual void Update() {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collider) {
        var bullet = collider.GetComponent<Bullet>();
        
        if (bullet != null) {
            ReceiveDamage();
        }

        var character = collider.GetComponent<Character>();
        if (character) {
            character.ReceiveDamage();
        }
    }
}
