using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input & move object
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        // get input
        if (Input.GetKey(upKey))
        {
            // move up
            return Vector2.up * speed;
        }

        if (Input.GetKey(downKey))
        {
            // move down
            return Vector2.down * speed;
        }

        // reset speed
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        // check speed
        // Debug.Log("Paddle Speed: " + movement);

        // move object
        rig.velocity = movement;
    }

    public void ActivatePaddleSpeedUp(GameObject paddle)
    {
        speed *= 2;
    }

    public void DeactivatePaddleSpeedUp(GameObject paddle)
    {
        speed /= 2;
    }

    public void ActivatePaddleScaleUp(GameObject paddle)
    {
        paddle.transform.localScale += new Vector3(0, paddle.transform.localScale.y, 0);
    }

    public void DeactivatePaddleScaleUp(GameObject paddle)
    {
        paddle.transform.localScale -= new Vector3(0, paddle.transform.localScale.y/2, 0);
    }
}
