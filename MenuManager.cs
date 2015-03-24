using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour {

    public static MenuManager instance = null;

    private GameObject mainMenu;
    private GameObject gameOverMenu;
    private GameObject gameGui;
    private GameObject scoreObject;

    private Animator mainMenuAnimator;
    private Animator gameOverAnimator;

    private CanvasGroup mainMenuCanvas;
    private CanvasGroup gameOverCanvas;

    private Text scoreText;
    
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        // Find and load a reference to the mainmenu animator so we can control its states
        mainMenu = GameObject.Find("MainMenu");
        mainMenuAnimator = mainMenu.GetComponent<Animator>();
        mainMenuCanvas = mainMenu.GetComponent<CanvasGroup>();

        gameOverMenu = GameObject.Find("GameOverUI");
        gameOverAnimator = gameOverMenu.GetComponent<Animator>();
        gameOverCanvas = gameOverMenu.GetComponent<CanvasGroup>();

        gameGui = GameObject.Find("GameUI");
        scoreObject = GameObject.Find("ScoreText");
        scoreText = scoreObject.GetComponent<Text>();
        gameGui.SetActive(false);
        gameOverCanvas.interactable = false;
	}
	
	
	void Update () {
        
	}

    public void LoadMainMenu()
    {
        
    }
    public void ShowMainMenu()
    {
        mainMenuCanvas.interactable = true;
        mainMenuAnimator.SetTrigger("ShowMenu");
    }
    public void HideMainMenu()
    {
        mainMenuCanvas.interactable = false;
        mainMenuAnimator.SetTrigger("HideMenu");
    }
    public void ShowGui()
    {
        gameGui.SetActive(true);
    }

    public void HideGui()
    {
        gameGui.SetActive(false);
    }
    public void ShowGameOverMenu()
    {
        gameGui.SetActive(false);
        gameOverCanvas.interactable = true;
        gameOverAnimator.SetTrigger("ShowMenu");
    }
    public void HideGameOverMenu()
    {
        gameOverAnimator.SetTrigger("HideMenu");
        gameOverCanvas.interactable = false;
    }
    public void UpdateScore()
    {
       scoreText.text  = (GameManager.instance.Score.ToString());
    }
}
