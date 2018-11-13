using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftPaddle")
        {
            float y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;

            Vector2 direction = new Vector2(1, y).normalized;

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);

            rigidBody.velocity = direction * speed;
        }
        else if (collision.gameObject.name == "RightPaddle")
        {
            float y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;

            Vector2 direction = new Vector2(-1, y).normalized;

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);

            rigidBody.velocity = direction * speed;
        }

        if ((collision.gameObject.name == "TopWall") || (collision.gameObject.name == "BottomWall"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }

        if ((collision.gameObject.name == "LeftGoal") || (collision.gameObject.name == "RightGoal"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            transform.position = new Vector2(0, 0);
        }
    }
}
