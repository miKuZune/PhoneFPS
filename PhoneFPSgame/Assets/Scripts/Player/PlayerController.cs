using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float sensitivity = 25.0f;

    public VirtualJoystick movementJoyStick;
    public VirtualJoystick turningJoyStick;

    public GameObject bullet;
    public Transform bulletSpawnPos;

    public float GunFireRate;
    float timeSinceLastFire = 0;

    bool isShooting = false;

    Vector3 forwardDir = Vector3.zero;
    Vector3 sidewaysDir = Vector3.zero;
    Vector3 turner = Vector3.zero;

    Rigidbody RB;
	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();

		if (Application.isEditor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
	
    void Shoot()
    {
        if(timeSinceLastFire > GunFireRate)
        {
            Instantiate(bullet, bulletSpawnPos.position, Quaternion.identity);
            timeSinceLastFire = 0;
        }
    }

    public void SetToShooting()
    {
        isShooting = true;
    }

    public void SetToNotShooting()
    {
        isShooting = false;
    }

	void EditorTurn()
	{
		float xRot = 0, yRot = 0;

		xRot = Input.GetAxis ("Mouse Y");
		yRot = Input.GetAxis ("Mouse X");

		Vector3 bodyRot = new Vector3 (0, yRot, 0);
		Vector3 camRot = new Vector3(-xRot,0,0);

		transform.Rotate (bodyRot * Time.deltaTime * 75);
		Camera.main.transform.Rotate (camRot * Time.deltaTime * 75);
	}

	void EditorMove()
	{
		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
		float z = Input.GetAxis ("Vertical") * Time.deltaTime * moveSpeed;
		transform.Translate (-z, 0, x);
	}

	void PhoneMove()
	{
		if (movementJoyStick.InputDirection != Vector3.zero)
		{
			forwardDir = transform.forward * movementJoyStick.InputDirection.x;
			sidewaysDir = -transform.right * movementJoyStick.InputDirection.z;

		}
		else
		{
			forwardDir = Vector3.zero;

			sidewaysDir = Vector3.zero;
		}

		if(isShooting)
		{
			Shoot();
		}

		Vector3 overallDir = forwardDir + sidewaysDir;

		overallDir *= moveSpeed;

		Vector3 newVel = RB.velocity;
		newVel.x = overallDir.x;
		newVel.z = overallDir.z;
		RB.velocity = newVel;
	}

    void PhoneTurn()
    {
        if (turningJoyStick.InputDirection != Vector3.zero)
        {
            turner.x = -turningJoyStick.InputDirection.z;
            turner.y = turningJoyStick.InputDirection.x;
        }
        else
        {
            turner = Vector3.zero;
        }

        float camRotate = turner.x;
        turner.x = 0;
        transform.Rotate(turner * Time.deltaTime * sensitivity);
        Camera.main.transform.Rotate(new Vector3(camRotate, 0, 0));
    }

	// Update is called once per frame
	void Update () {
        timeSinceLastFire += Time.deltaTime;

		if (!Application.isEditor) {
			PhoneTurn ();
			PhoneMove ();
		} else {
			
			EditorTurn ();
			EditorMove ();
			if (Input.GetKey(KeyCode.Mouse0)) {
				Shoot ();
			}
		}

	}
}
