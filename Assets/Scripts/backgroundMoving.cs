using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class backgroundMoving : MonoBehaviour
{
	float Min_Position_Y = 0.0f;
	float Max_Position_Y = 0.0f;
    public float velocity = 1.0f;
	private bool isMovingDown;
	public GameObject mesh;
	int currentLevel;
	public List<GameObject> levels;
	bool levelChangeRequested;

	void Awake()
	{
		EventManager.RockMovement += functionTrigger;
		EventManager.levelChanger += triggerLevelChange;
	}

	// Use this for initialization
	void Start ()
    {		
		Max_Position_Y = mesh.GetComponent<MeshRenderer> ().bounds.size.y - mesh.GetComponent<MeshRenderer> ().bounds.size.y*.1f;
		Min_Position_Y = -Max_Position_Y;
		transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
		isMovingDown = false;
		currentLevel = 1;
    }

	// Update is called once per frame
	void Update ()
    {
		if (isMovingDown) {
			transform.Translate (velocity * Vector3.up * Time.deltaTime);

			if (transform.localPosition.y >= Max_Position_Y) {
				if (levelChangeRequested) {
					levelChangeRequested = false;
					changeLevel ();
				}
				transform.localPosition = new Vector3 (gameObject.transform.localPosition.x, Min_Position_Y, gameObject.transform.localPosition.z);
			}
		} else {
			transform.Translate (velocity * Vector3.down * Time.deltaTime);

			if (transform.localPosition.y <= Min_Position_Y) {
				transform.localPosition = new Vector3 (gameObject.transform.localPosition.x, Max_Position_Y, gameObject.transform.localPosition.z);
			}
		}
    }

	public void functionTrigger(int option)
	{
		switch (option) {
		case 0:
			velocity -= velocity*.002f;
			break;
		case 1:
			velocity = 0;
			break;
		case 3:
			velocity = 3;
			break;
		}
		isMovingDown = true;
	}

	public void changeLevel(){
		currentLevel++;
		if (currentLevel == 2) {
			levels [0].SetActive (false);
			levels [1].SetActive (true);
			levels [2].SetActive (false);
		} else {
			levels [0].SetActive (false);
			levels [1].SetActive (false);
			levels [2].SetActive (true);
		}
	}

	public void triggerLevelChange(){
		levelChangeRequested = true;
	}
}
