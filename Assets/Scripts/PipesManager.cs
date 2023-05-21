using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Pipes;

    private float positionCameraRight;

    void Start()
    {
        StartCoroutine( Spawner() );

        Vector3 sizePrefab = Pipes.GetComponent<BoxCollider2D>().bounds.size;
        Vector2 positionCameraLeft = Camera.main.ViewportToWorldPoint ( new Vector2( 0, Screen.height ) );
        positionCameraRight = (positionCameraLeft.x * -1f) + (sizePrefab.x / 1.8f);
    }

    IEnumerator Spawner () {
        while ( true ) {
            yield return new WaitForSeconds( Random.Range(1f, 2f) );
            Instantiate(Pipes, new Vector3( positionCameraRight, Random.Range(-1f, 1f), 0), Quaternion.identity );
        } 
    }
}
