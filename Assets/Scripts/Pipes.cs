using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    private double leftBreakpoint;

    void Start() {
        Vector2 positionCameraLeft = Camera.main.ViewportToWorldPoint ( new Vector2( 0, Screen.height ) );
        Vector3 sizePrefab = GetComponent<BoxCollider2D>().bounds.size;
        leftBreakpoint = positionCameraLeft.x + (( sizePrefab.x / 1.8 ) * -1);
    }

    void Update()
    {
        transform.Translate( -2 * Time.deltaTime, 0, 0 );
        // Удаляем объект если он вышел за пределы экрана
        
        if ( transform.position.x < leftBreakpoint ) {
            Destroy( gameObject );
        }
    }
}
