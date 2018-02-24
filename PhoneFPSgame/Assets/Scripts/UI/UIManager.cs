using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject movementJoystick;
	public GameObject turnJoyStick;
	public GameObject fireButton;
    public GameObject damageIndicator;
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
    }

	public void HidePhoneUI()
	{
        
		movementJoystick.SetActive (false);
		turnJoyStick.SetActive (false);
		fireButton.SetActive (false);
	}
    private void Update()
    {
        if(damageIndicator.active)
        {
            timeActiveDmg += Time.deltaTime;
            if(timeActiveDmg > dmgIndicatorActiveTime)
            {
                HideDamageIndicator();
            }
        }

        float health = playerHealth.health;
        Health.size = health / 100;
    }
}
