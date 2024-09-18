using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("Particle Stuff")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject smoke;
    [SerializeField]
    private CircleCollider2D circleCollider;
    public bool isBig;
    [Header("Meteor Properties")]
    private int hitCount = 0;
    [SerializeField]
    private int health;
    private float moveSpeed;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isBig)
        {
            moveSpeed = 2f;
            health = 1;
        }
        else
        {
            moveSpeed = .5f;
            health = 5;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
        if (hitCount >= health && !isDead)
        {
            isDead = true;
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            smoke.SetActive(true);
            if (isBig)
            {
                CameraBehavior cb = FindAnyObjectByType<CameraBehavior>();
                cb.Shake();
            }
                Invoke("KillThis", 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } 
        else if (whatIHit.tag == "Laser")
        {
            Debug.Log(health + name);
            Destroy(whatIHit.gameObject);
            hitCount++;
        }
    }
    private void KillThis()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount+=1;
        Destroy(this.gameObject);
    }
}
