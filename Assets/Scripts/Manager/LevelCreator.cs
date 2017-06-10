using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

	public GameManager gm;

	public GameObject[] topPlatforms;
	public GameObject[] bottomPlatforms;

	public float minX, maxX;
	public float minY, maxY;
	private float minTime, maxTime;
	private float lastY;

	private Vector2 lastObjPos;
	private float levelSpeed;
	private bool nextTop;

	private float lastTimeSpawn, nextTimeSpawn;
	private float offScreenX;

	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		levelSpeed = gm.levelSpeed;

		lastTimeSpawn = 0;
		nextTimeSpawn = 1;


		minTime = DistanceToTime(minX);
		maxTime = DistanceToTime(maxX);
		lastY = 1.35f;

		offScreenX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x + 2;
	}

	void Update () {
		if(Time.time > lastTimeSpawn + nextTimeSpawn) {
			int index = GetRandomIndex();

			if (GetNegative() == 1) {
				float y = lastY + Random.Range(minY, maxY);
				if(y < 1f)
					y = 1f;

				GameObject go = Instantiate(topPlatforms[index], new Vector3(offScreenX, y, 0), Quaternion.identity);
				go.GetComponent<SideMover>().speed = levelSpeed;

				gm.blocks.Add(go.transform);

				for (int i = 0; i < go.transform.childCount; i++) {
					go.transform.GetChild(i).GetComponent<BlockSwitch>().isActive = gm.topActive;
				}
			}
			else {
				float y = lastY + Random.Range(minY, maxY);
				if (y < 1f)
					y = 1f;

				GameObject go = Instantiate(bottomPlatforms[index], new Vector3(offScreenX, -y, 0), Quaternion.identity);
				go.GetComponent<SideMover>().speed = levelSpeed;

				gm.blocks.Add(go.transform);

				for (int i = 0; i < go.transform.childCount; i++) {
					go.transform.GetChild(i).GetComponent<BlockSwitch>().isActive = !gm.topActive;
				}
			}

			lastTimeSpawn = Time.time;
			//nextTimeSpawn = DistanceToTime(topPlatforms[index].transform.GetChild(0).GetComponent<BoxCollider2D>().size.x / 2 + Random.Range(minTime, maxTime));
			nextTimeSpawn = DistanceToTime(index * 1.15f + Random.Range(minTime, maxTime));
			
		}
	}



	int GetRandomIndex() {
		float r = Random.value;
		if (r < 0.1f) { //10% chance
			return 0;
		}
		else if (r < 0.3f) { //20%
			return 1;
		}
		else if (r < 0.65f) { //35%
			return 2;
		}
		else if (r < 0.85f) { //20%
			return 3;
		}
		else return 4; //15%
	}

	float DistanceToTime(float distance) {
		//Debug.Log("Distance: " + distance + "   levelSpeed: " + levelSpeed + "   " + (1 / levelSpeed) * distance);
		return (1 / levelSpeed) * distance; 
	}

	int GetNegative() {
		float r = Random.value;
		if(r < 0.5f)
			return 1;
		else return -1;
	}
}
