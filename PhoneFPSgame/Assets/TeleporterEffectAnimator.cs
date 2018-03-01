using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterEffectAnimator : MonoBehaviour {

    public Sprite[] teleporterSprites;

    SpriteRenderer SR;

    float timeSinceLastSpriteChange;
    public float timeBetweenSpriteChanges;

    int currentSpriteId;

	// Use this for initialization
	void Start () {
        currentSpriteId = 1;

        //Setup sprite render and set first sprite to load.
        SR = GetComponent<SpriteRenderer>();
        SR.sprite = teleporterSprites[currentSpriteId];
	}
	
	// Update is called once per frame
	void Update () {

        if(timeSinceLastSpriteChange >= timeBetweenSpriteChanges)
        {
            currentSpriteId++;
            if (currentSpriteId >= teleporterSprites.Length)
            {
                currentSpriteId = 0;
            }

            Debug.Log("Swapped");

            GetComponent<SpriteRenderer>().sprite = teleporterSprites[currentSpriteId];
            timeSinceLastSpriteChange = 0;
        }
        timeSinceLastSpriteChange += Time.deltaTime;
	}
}
