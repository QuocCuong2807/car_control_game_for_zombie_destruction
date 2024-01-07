using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    private float currentTime;
    private const float startingTime = 60.0f;
    public GameObject countDownText;
    public TextMesh endText;
    public TextMesh sceneText;
    public Button btnPlayAgain;
    public Button btnLoadNexScene;
    private int score;
    private int targetScore;
    private LoadScene scene;
    public float getCurrentTime()
    {
        return currentTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        endText.gameObject.SetActive(false);

        btnPlayAgain.gameObject.SetActive(false);
        btnLoadNexScene.gameObject.SetActive(false);
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        //back to menu if press 'esc' key
        if (Input.GetKeyDown(KeyCode.Escape))
            scene.backToMenu();

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
            countDownText.GetComponent<TextMesh>().text = "Countdown: " + currentTime + " s";
        }

        else 
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.GetComponent<TextMesh>().text = "Countdown: " + currentTime + " s";
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

        //get current score and target score from Car object
        score = FindObjectOfType<Car>().getScore();
        targetScore = FindObjectOfType<Car>().getTargetScore();

        //enable end game text and disable count down, score text, scene text
        endText.gameObject.SetActive(true);
        sceneText.gameObject.SetActive(false);
        countDownText.gameObject.SetActive(false);
        FindObjectOfType<Car>().getScoreText().SetActive(false);
        //check win or lose base on score/target score (display notification text)
        if (score < targetScore) 
        {   
            endText.text = "Misson Fail";
            endText.color = Color.red;
            
            return false;
        }
        else 
        {   
            endText.text = "Misson Success";
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
                btnLoadNexScene.gameObject.SetActive(true);
            else
                btnPlayAgain.gameObject.SetActive(true);
        }
    }

}
