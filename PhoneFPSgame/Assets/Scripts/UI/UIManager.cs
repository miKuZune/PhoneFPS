using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GameObject movementJoystick;
	public GameObject turnJoyStick;
	public GameObject fireButton;
    public GameObject damageIndicator;
    public GameObject GameOverGO;
    public Scrollbar Health;
    public Text round;
    public Text eneLeft;
    public Text eneKilled;

    HealthHandler playerHealth;

    float timeActiveDmg;
    const float dmgIndicatorActiveTime = 0.45f;
	// Use this for initialization
	void Start ()
    {
        Hide();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthHandler>();
		if (Application.isEditor)
        {
			HidePhoneUI ();	
			//if game = boring
			//inject code.fun
			//just fucking do it
		}
	}

    public void UpdateRound(int newRound)
    {
        round.text = "Round: " + newRound;
    }
    public void UpdateEnemiesLeft(int enemiesLeft)
    {
        eneLeft.text = "Enemies left: " + enemiesLeft;
    }
    public void UpdateEnemiesKilled(int enemiesKilled)
    {
        eneKilled.text = "Enemies killed: " + enemiesKilled;
    }

    public void HideDamageIndicator()
    {
        damageIndicator.SetActive(false);
    }

    public void ShowDamageIndicator()
    {
        damageIndicator.SetActive(true);
    }

    public void Hide()
    {
        damageIndicator.SetActive(false);
        GameOverGO.SetActive(false);
    }

	public void HidePhoneUI()
	{
        
		movementJoystick.SetActive (false);
		turnJoyStick.SetActive (false);
		fireButton.SetActive (false);
	}

    public void Restart()
    {
        Scene thisScene = new Scene();
        thisScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(thisScene.name);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        GameOverGO.SetActive(true);
        if (Application.isEditor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        GameObject.Find("EndGameScore").GetComponent<Text>().text = "Score: " + GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>().GetScore();

        Time.timeScale = 0;
    }

    private void Update()
    {
        if(damageIndicator.active)
        {
            timeActiveDmg += Time.deltaTime;
            if(timeActiveDmg > dmgIndicatorActiveTime)
            {
                HideDamageIndicator();
                timeActiveDmg = 0;
            }
        }

        float health = playerHealth.health;
        Health.size = health / 100;
    }
}
