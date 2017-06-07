using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnManager : MonoBehaviour {

	public GameObject[] clouds;
	public float minSpawnTime;
	public float maxSpawnTime;

	private float lastSpawnTimeTop, lastSpawnTimeBottom;
	private float nextSpawnTimeTop, nextSpawnTimeBottom;

	private float offScreenX;

	public float maxHeight;
	public float minHeight;
	private float height;

	public float maxSpeed;
	public float minSpeed;

	void Start () {
		lastSpawnTimeTop = 0;
		lastSpawnTimeBottom = 0;
		nextSpawnTimeTop = Random.Range(minSpawnTime, maxSpawnTime);
		nextSpawnTimeBottom = Random.Range(minSpawnTime, maxSpawnTime);
		height = Random.Range(minHeight, maxHeight);

		offScreenX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x + 2;
	}
	
	void Update () {
		if (lastSpawnTimeTop + nextSpawnTimeTop < Time.time) {
			GameObject go =
				Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector3(offScreenX, height, 0), Quaternion.identity);

			go.GetComponent<SimpleMover>().speed = Random.Range(minSpeed, maxSpeed);

			lastSpawnTimeTop = Time.time;
			nextSpawnTimeTop = Random.Range(minSpawnTime, maxSpawnTime);
			height = Random.Range(minHeight, maxHeight);
		}


		if (lastSpawnTimeBottom + nextSpawnTimeBottom < Time.time) {
			GameObject go =
				Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector3(offScreenX, -height, 0), Quaternion.identity);

			Vector3 theScale = go.transform.localScale;
			theScale.y *= -1;
			go.transform.localScale = theScale;

			go.GetComponent<SimpleMover>().speed = Random.Range(minSpeed, maxSpeed);

			lastSpawnTimeBottom = Time.time;
			nextSpawnTimeBottom = Random.Range(minSpawnTime, maxSpawnTime);
			height = Random.Range(minHeight, maxHeight);
		}
	}
}
