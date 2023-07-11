using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class plane : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody;
    private Vector2 movementInput;
    private Animator anim;
    public int cash;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("vertical", movementInput.y);
        anim.SetFloat("sped", movementInput.sqrMagnitude);
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ammo = Instantiate(ammoprefab, ammospawn.position,Quaternion.identity);
            Rigidbody2D rb = ammo.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * ammosped;
        }
    }
    private void LateUpdate()
    {
        rigidBody.velocity = movementInput * speed;
    }
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();

    }
    private void FixedUpdate()
    {
        
    }

    public GameObject ammoprefab;
    public Transform ammospawn;
    public float ammosped;
}
