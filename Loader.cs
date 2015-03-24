using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject soundManager;
    public GameObject menuManager;
    public GameObject aiManager;
    public GameObject objectSpawner;
	// Use this for initialization
	void Awake () {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        if (MenuManager.instance == null)
            Instantiate(menuManager);
        if (AIManager.instance == null)
            Instantiate(aiManager);
        if (ObjectSpawner.instance == null)
            Instantiate(objectSpawner);
	}
    public void PlayButtonClicked()
    {
        MenuManager.instance.HideMainMenu();
        GameManager.instance.StartGame();
    }
    public void RestartGameButtonClickeD()
    {
        MenuManager.instance.HideGameOverMenu();
        
        GameManager.instance.RestartGame();
    }
    public void BackButtonClicked()
    {
        MenuManager.instance.HideGui();
        MenuManager.instance.HideGameOverMenu();
        MenuManager.instance.ShowMainMenu();
    }
    public void RateButtonClicked()
    {

    }
    public void LeaderboardButtonClicked()
    {

    }
}
