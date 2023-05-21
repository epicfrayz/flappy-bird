using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float force;

    [SerializeField]
    private TextMeshProUGUI textScore;

    [SerializeField]
    private GameObject gameover;
    [SerializeField]
    private TextMeshProUGUI textScoreFinal;
    [SerializeField]
    private TextMeshProUGUI textScoreBestFinal;

    Rigidbody2D characterRigidbody;
    private int score;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        score = 0;
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

    private void OnTriggerEnter2D(Collider2D collision) {
        switch( collision.tag ) {
            case "Score":
                AddScore();
                break;
        }
    }

    private void Death () {
        Time.timeScale = 0;
        int scoreBest = 0;

        if ( PlayerPrefs.GetInt("scoreBest") > score ) {
            scoreBest = PlayerPrefs.GetInt("scoreBest");
        } else {
            PlayerPrefs.SetInt("scoreBest", score);
            scoreBest = score;
        }

        textScoreFinal.text = score.ToString();
        textScoreBestFinal.text = scoreBest.ToString();
        gameover.SetActive(true);
    }

    private void AddScore () {
        score++;
        textScore.text = score.ToString();
    }
}
