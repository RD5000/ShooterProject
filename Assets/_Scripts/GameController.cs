using UnityEngine;
using System.Collections;
//For UI
using UnityEngine.UI;
//For Restarts
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    //Private Variables. Okay, this is top secret stuff. Don't look here
    private int livesValue;
    private int scoreValue;

    //Public Variables. Whatever, let the public read these.
    public int enemyCount = 3;
    public GameObject zombie;

    [Header("UI Objects")]
    public Text HealthLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    [Header("Game Objects")]
    public GameObject Player;
    public GameObject Food;
    public GameObject Enemy;

    //Public Properties
    public int LivesValue
    {
        get { return this.livesValue; }
        set
        {
            this.livesValue = value;
            if (this.livesValue <= 0)
            {
                this.endGame();
            }
            else
            {
                this.HealthLabel.text = "HP :" + this.livesValue;
            }
        }
    }
    public int ScoreValue
    {
        get { return this.scoreValue; }
        set
        {
            this.scoreValue = value;
            this.ScoreLabel.text = "Scavanged Food:" + this.scoreValue;
        }
    }


    // Use this for initialization
    void Start () {
        this.LivesValue = 10;
        this.ScoreValue = 0;

        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);

        for (int zombieCount = 0; zombieCount < this.enemyCount; zombieCount++)
        {
            Instantiate(this.zombie);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void endGame()
    {
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "Scavanged Food: " + this.ScoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.ScoreLabel.gameObject.SetActive(false);
        this.HealthLabel.gameObject.SetActive(false);
        this.Player.SetActive(false);
        this.Food.SetActive(false);
        this.Enemy.SetActive(false);
    }
    public void RestartButton_Click()
    {
        SceneManager.LoadScene("Main");
    }
}
