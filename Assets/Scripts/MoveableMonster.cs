using UnityEngine;
using System.Collections;
using System.Linq;

public class MoveableMonster : Monster {
    [SerializeField] private float speed = 2.0f;

    private Vector3 direction;
    private SpriteRenderer sprite;
    private Animator animator;

    private MoveableMonsterState State {
        get { return (MoveableMonsterState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    protected override void Awake() {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void Start() {
        State = MoveableMonsterState.Run;
        direction = transform.right;
    }

    protected override void Update() {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collider) {
        var unit = collider.GetComponent<Unit>();

        if (unit && unit is Character) {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.5f) {
                ReceiveDamage();
            } else {
                unit.ReceiveDamage();
            }
        }
    }

    private void Move() {
        var colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * direction.x * 0.5f, 0.1f);
        
        if(colliders.Length > 0 && colliders.All(x => !x.GetComponent<Character>()) && colliders.All(x => !x.GetComponent<Bullet>())) {
            direction *= -1.0f;
        }

        sprite.flipX = direction.x >= 0.0f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
