using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreLeft;
    public Text scoreRight;
    public ScoreManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLeft.text = manager.leftScore.ToString();
        scoreRight.text = manager.rightScore.ToString();
    }
}
