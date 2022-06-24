using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public BallController controller;

    public PowerUpManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == ball)
        {
            if (controller.hitPaddleLeft && manager.activeStatusLeftPaddleSpeedUp == false)
            {
                manager.activeStatusLeftPaddleSpeedUp = true;
                manager.LeftPaddle.GetComponent<PaddleController>().ActivatePaddleSpeedUp(manager.LeftPaddle);
                
                manager.RemovePowerUp(gameObject);
                Debug.Log("Left Paddle Speed UP!");
            }
            else if (controller.hitPaddleLeft == false && manager.activeStatusRightPaddleSpeedUp == false)
            {
                manager.activeStatusRightPaddleSpeedUp = true;
                manager.RightPaddle.GetComponent<PaddleController>().ActivatePaddleSpeedUp(manager.RightPaddle);
                
                manager.RemovePowerUp(gameObject);
                Debug.Log("Right Paddle Speed UP!");
            }
        }
    }
}
