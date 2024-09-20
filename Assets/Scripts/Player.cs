using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private float moveSpeed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
        CheckIfInBounds();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            StartCoroutine("Cooldown");
        }
    }

    void CheckIfInBounds()
    {
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit) //horizontal bounds checks
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        
        else if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit) //vertical bounds checks
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
