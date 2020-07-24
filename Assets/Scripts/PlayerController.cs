using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] float movementSpeed = 10f;
    [SerializeField, Range(0f, 100f)] float acc = 10f;
    public Rigidbody2D rb;
    public Animator anim;
    private Vector2 pos;
    private Vector2 velocity;

    // Update is called once per frame
    void Update()
    {
        pos.x = Input.GetAxis("Horizontal");
        pos.y = Input.GetAxis("Vertical");
        pos = Vector2.ClampMagnitude(pos, 1f);
        if(Health.isDead)
        {
            anim.SetTrigger("Explosion");
        }
    }

    private void FixedUpdate()
    {
        Vector2 dVel = new Vector2(pos.x, pos.y) * movementSpeed;
        float maxSpeedChange = acc * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, dVel.x, maxSpeedChange);
        velocity.y = Mathf.MoveTowards(velocity.y, dVel.y, maxSpeedChange);
        Vector2 displacement = velocity * Time.deltaTime;
        Vector2 newPos = rb.position + displacement;
        rb.MovePosition(newPos);
    }
}
