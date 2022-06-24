using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rig;
    
    // reset posisi
    public Vector2 resetPosition;

    // reset speed
    public Vector2 resetSpeed;

    // lasthit paddle
    public bool hitPaddleLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        resetSpeed.x = speed.x;
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 1);
        
        if (rig.velocity.x < 0)
        {
            speed = resetSpeed;
            rig.velocity = new Vector2(speed.x * -1, speed.y);
        }
        else if (rig.velocity.x > 0)
        {
            speed = resetSpeed;
            rig.velocity = new Vector2(speed.x * 1, speed.y);
        }
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    public void DeactivatePUSpeedUp(float magnitude)
    {
        rig.velocity /= magnitude;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle_Left")
        {
            hitPaddleLeft = true;
        }
        else
        {
            hitPaddleLeft = false;
        }
    }
}
