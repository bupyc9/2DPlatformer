using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {
    [SerializeField] private Character character;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
        character = FindObjectOfType<Character>();
    }

    private void Update() {
        if (character.Lives < 1) {
            anim.SetTrigger("GameOver");
        }
    }
}
