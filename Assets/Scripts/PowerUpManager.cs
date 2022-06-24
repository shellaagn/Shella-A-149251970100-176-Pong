using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // PowerUp Spawn
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    // PowerUp Timer
    public int spawnInterval;
    public int unusedSpawnTimer;
    private float timer;
    private float deleteTimer;

    // PowerUp Lists
    private List<GameObject> powerUpList;
    public List<GameObject> powerUpTemplateList;

    // PowerUp Status
    public bool activeStatusBallSpeedUp = false;
    public bool activeStatusLeftPaddleSpeedUp = false;
    public bool activeStatusRightPaddleSpeedUp = false;
    public bool activeStatusLeftPaddleScaleUp = false;
    public bool activeStatusRightPaddleScaleUp = false;

    // PowerUp Durations
    private float durationBallSpeedUp;
    private float durationLeftPaddleSpeedUp;
    private float durationRightPaddleSpeedUp;
    private float durationLeftPaddleScaleUp;
    private float durationRightPaddleScaleUp;

    // objects affected by powerups
    public GameObject ball;
    public float ballMagnitude;
    public GameObject LeftPaddle;
    public GameObject RightPaddle;
    
    void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        deleteTimer += Time.deltaTime;

        if(timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;

            // delete powerup if not claimed 
            if(deleteTimer > unusedSpawnTimer)
            {
                RemovePowerUp(powerUpList[0]);
                deleteTimer -= unusedSpawnTimer;
            }
        }

        // buff ball speed up duration
        if (activeStatusBallSpeedUp == true)
        {
            if (durationBallSpeedUp >= 5)
            {
                ball.GetComponent<BallController>().DeactivatePUSpeedUp(ballMagnitude);
                durationBallSpeedUp = 0;
                activeStatusBallSpeedUp = false;
                Debug.Log("Ball Speed DOWN!");
            }
            durationBallSpeedUp += Time.deltaTime;
        }

        // buff paddle-kiri speed up duration
        if (activeStatusLeftPaddleSpeedUp == true)
        {
            if (durationLeftPaddleSpeedUp >= 5)
            {
                LeftPaddle.GetComponent<PaddleController>().DeactivatePaddleSpeedUp(LeftPaddle);
                durationLeftPaddleSpeedUp = 0;
                activeStatusLeftPaddleSpeedUp = false;
                Debug.Log("Left Paddle Speed DOWN!");
            }
            durationLeftPaddleSpeedUp += Time.deltaTime;
        }

        // buff paddle-kanan speed up duration
        if (activeStatusRightPaddleSpeedUp == true)
        {
            if (durationRightPaddleSpeedUp >= 5)
            {
                RightPaddle.GetComponent<PaddleController>().DeactivatePaddleSpeedUp(RightPaddle);
                durationRightPaddleSpeedUp = 0;
                activeStatusRightPaddleSpeedUp = false;
                Debug.Log("Right Paddle Speed DOWN!");
            }
            durationRightPaddleSpeedUp += Time.deltaTime;
        }

        // buff paddle-kiri scale up duration
        if (activeStatusLeftPaddleScaleUp == true)
        {
            if (durationLeftPaddleScaleUp >= 5)
            {
                LeftPaddle.GetComponent<PaddleController>().DeactivatePaddleScaleUp(LeftPaddle);
                durationLeftPaddleScaleUp = 0;
                activeStatusLeftPaddleScaleUp = false;
                Debug.Log("Left Paddle Scale DOWN!");
            }
            durationLeftPaddleScaleUp += Time.deltaTime;
        }

        // buff paddle-kanan scale up duration
        if (activeStatusRightPaddleScaleUp == true)
        {
            if (durationRightPaddleScaleUp >= 5)
            {
                RightPaddle.GetComponent<PaddleController>().DeactivatePaddleScaleUp(RightPaddle);
                durationRightPaddleScaleUp = 0;
                activeStatusRightPaddleScaleUp = false;
                Debug.Log("Right Paddle Scale DOWN!");
            }
            durationRightPaddleScaleUp += Time.deltaTime;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), 
            Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }
        
        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], 
            new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), 
            Quaternion.identity, spawnArea);

        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while(powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
