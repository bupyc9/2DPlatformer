﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableMonster : Monster {
    [SerializeField] private float rate = 2.0f;
    [SerializeField] private Color bulletColor = Color.white;

    private Bullet bullet;

    protected override void Awake() {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start() {
        InvokeRepeating("Shoot", rate, rate);
    }

    private void Shoot() {
        var position = transform.position;
        position.y += 0.9f;

        var newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = this.gameObject;
        newBullet.Direction = -newBullet.transform.right;
        newBullet.Color = bulletColor;
    }

    protected override void OnTriggerEnter2D(Collider2D collider) {
        var unit = collider.GetComponent<Unit>();

        if(unit && unit is Character) {
            if(Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.5f) {
                ReceiveDamage();
            } else {
                unit.ReceiveDamage();
            }
        }
    }
}