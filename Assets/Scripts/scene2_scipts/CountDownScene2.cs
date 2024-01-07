using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownScene2 : MonoBehaviour
{
    private float currentTime;
    private const float startingTime = 50.0f;
    public GameObject countDownText;
    public TextMesh endText;
    public TextMesh sceneText;
    public Button btnPlayAgain;
    public Button btnLoadNextScene;
    public LoadScene scene;
    private int score;
    private int targetScore;


    public float getCurrentTime()
    {
        return currentTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        endText.gameObject.SetActive(false);
        btnPlayAgain.gameObject.SetActive(false);
        btnLoadNextScene.gameObject.SetActive(false);
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        //decrese time and print to monitor
        decreaseTime();
        
        //load next scene if win game and restart game if lose game
        NotifyEndScene();

    }

    //decrese time function
    void decreaseTime()
    {
        if (isTimeUp())
        {
            currentTime = 0;
            countDownText.GetComponent<TextMesh>().text = "Countdown: " + currentTime;
        }
        else
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.GetComponent<TextMesh>().text = "Countdown: " + currentTime;
        }
    }

    //check time function
    public bool isTimeUp()
    {
        if (currentTime <= 0)
            return true;
        return false;
    }

    //check the game is won or not and print message to monitor
    bool isWinGame()
    {
        //get current score and target score
        score = FindObjectOfType<CarScene2>().getScore();
        targetScore = FindObjectOfType<CarScene2>().getTargetScore();

        //enable end game text and disable count down, score text and scene text
        endText.gameObject.SetActive(true);
        countDownText.gameObject.SetActive(false);
        sceneText.gameObject.SetActive(false);
        FindObjectOfType<CarScene2>().getScoreText().SetActive(false);
        if (score < targetScore)
        {
            endText.text = "Misson Fail";
            endText.color = Color.red;
            return false;
        }
        else
        {
            endText.text = "You win";
            endText.color = Color.green;
            return true;
        }

    }


    //notify play again button if game was lose or notify continue button if game was win
    void NotifyEndScene()
    {
        if (isTimeUp())
        {
            if (isWinGame())
                btnLoadNextScene.gameObject.SetActive(true);
            else
                btnPlayAgain.gameObject.SetActive(true);
        }
    }
}
