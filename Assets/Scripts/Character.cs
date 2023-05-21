using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float force;

    Rigidbody2D characterRigidbody;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) ) {
            characterRigidbody.velocity = Vector2.up * force;
        }
    }

    private void OnCollisionEnter2D ( Collision2D collision ) {
        switch( collision.collider.tag ) {
            case "Enemy":
                Death();
                break;
        }
    }

    private void Death () {
        Destroy( gameObject );
        Time.timeScale = 0;
    }
}
