using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleScaleUpController : MonoBehaviour
{
    public Collider2D ball;
    public BallController controller;

    public PowerUpManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == ball)
        {
            if (controller.hitPaddleLeft && manager.activeStatusLeftPaddleScaleUp == false)
            {
                manager.activeStatusLeftPaddleScaleUp = true;
                manager.LeftPaddle.GetComponent<PaddleController>().ActivatePaddleScaleUp(manager.LeftPaddle);
                
                manager.RemovePowerUp(gameObject);
                Debug.Log("Left Paddle Scale UP!");
            }
            else if (controller.hitPaddleLeft == false && manager.activeStatusRightPaddleScaleUp == false)
            {
                manager.activeStatusRightPaddleScaleUp = true;
                manager.RightPaddle.GetComponent<PaddleController>().ActivatePaddleScaleUp(manager.RightPaddle);
                
                manager.RemovePowerUp(gameObject);
                Debug.Log("Right Paddle Scale UP!");
            }
        }
    }
}
