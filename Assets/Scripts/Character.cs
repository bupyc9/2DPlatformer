using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Character : Unit {
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private int lives = 5;

    public int Lives {
        get { return lives; }
        set {
            if(value < 5) lives = value;
            livesBar.Refresh();
        }
    }

    [SerializeField] private float jumpForce = 15.0f;

    private LivesBar livesBar;
    private bool isGrounded = false;
    private CharState State {
        get { return (CharState) animator.GetInteger("State");  }
        set { animator.SetInteger("State", (int) value);  }
    }

    private new Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private Bullet bullet;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
        livesBar = FindObjectOfType<LivesBar>();
    }

    private void FixedUpdate() {
        CheckGround();
    }

    private void Update() {
        if(isGrounded) State = CharState.Idle;

        if(CrossPlatformInputManager.GetAxis("Horizontal") != 0) {
            Run();
        }

        if (isGrounded && CrossPlatformInputManager.GetButtonDown("Jump")) {
            Jump();
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Run() {
        var direction = transform.right * CrossPlatformInputManager.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;
        if (isGrounded) State = CharState.Run;
    }

    private void Jump() {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot() {
        var position = transform.position;
        position.y += 0.8f;
        var newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0f : 1.0f);
    }

    public override void ReceiveDamage() {
        Lives--;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 5.0f, ForceMode2D.Impulse);

        Debug.Log(Lives);
    }

    private void CheckGround() {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        isGrounded = colliders.Length > 1;
        if (!isGrounded) State = CharState.Jump;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        var bullet = collider.gameObject.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject) {
            ReceiveDamage();
        }
    }
}
