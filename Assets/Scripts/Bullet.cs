using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private float speed = 10.0f;
    private Vector3 direction;
    public Vector3 Direction { set { direction = value; } }

    public Color Color {
        set {
            sprite.color = value;
        }
    }
    private SpriteRenderer sprite;

    private GameObject parent;
    public GameObject Parent { set { parent = value; } get { return parent; } }

    private void Awake() {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    private void Start() {
        Destroy(gameObject, 1.4f);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        var unit = collider.GetComponent<Unit>();

        if (unit != null && unit.gameObject != parent) {
            Destroy(gameObject);
        }
    }
}
