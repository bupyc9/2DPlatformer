using UnityEngine;
using System.Collections;

public class Obstracle : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collider) {
        var unit = collider.GetComponent<Unit>();
        if (unit && unit is Character) {
            unit.ReceiveDamage();
        }
    }
}
