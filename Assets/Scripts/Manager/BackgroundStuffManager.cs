using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStuffManager : MonoBehaviour {

	public GameObject[] grass;
	public GameObject[] trees;

	public float moveSpeed;


	public float minTimeGrass, maxTimeGrass;
	public float minTimeTrees, maxTimeTrees;

	private float lastTimeGrassTop, lastTimeGrassBottom;
	private float lastTimeTreesTop, lastTimeTreesBottom;

	private float nextTimeGrassTop, nextTimeGrassBottom;
	private float nextTimeTreesTop, nextTimeTreesBottom;


	private float offScreenX;
	private float height;


	void Start () {
		lastTimeGrassTop = 0;
		lastTimeGrassBottom = 0;
		lastTimeTreesTop = 0;
		lastTimeTreesBottom = 0;

		nextTimeGrassTop = Random.Range(minTimeGrass, maxTimeGrass);
		nextTimeGrassBottom = Random.Range(minTimeGrass, maxTimeGrass);
		nextTimeTreesTop = Random.Range(minTimeTrees, maxTimeTrees);
		nextTimeTreesBottom = Random.Range(minTimeTrees, maxTimeTrees);

		offScreenX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x + 2;
		height = 2;
	}
	
	void Update () {
		DoGrass();
		DoTrees();
	}



	private void DoGrass() {
		if (lastTimeGrassTop + nextTimeGrassTop < Time.time) {
			GameObject go = grass[Random.Range(0, grass.Length)];
			go = Instantiate(go, new Vector3(offScreenX, height, 0), Quaternion.identity);
			go.GetComponent<SideMover>().speed = moveSpeed;

			lastTimeGrassTop = Time.time;
			nextTimeGrassTop = Random.Range(minTimeGrass, maxTimeGrass);
		}

		if (lastTimeGrassBottom + nextTimeGrassBottom < Time.time) {
			GameObject go = grass[Random.Range(0, grass.Length)];
			go = Instantiate(go, new Vector3(offScreenX, -height, 0), Quaternion.identity);
			go.GetComponent<SideMover>().speed = moveSpeed;

			go.GetComponent<Rigidbody2D>().gravityScale = -1;
			Vector3 theScale = go.transform.localScale;
			theScale.y *= -1;
			go.transform.localScale = theScale;

			lastTimeGrassBottom = Time.time;
			nextTimeGrassBottom = Random.Range(minTimeGrass, maxTimeGrass);
		}
	}

	private void DoTrees() {
		if (lastTimeTreesTop + nextTimeTreesTop < Time.time) {
			GameObject go = trees[Random.Range(0, grass.Length)];
			go = Instantiate(go, new Vector3(offScreenX, height, 0), Quaternion.identity);
			go.GetComponent<SideMover>().speed = moveSpeed;

			if (height < 0) {
				go.GetComponent<Rigidbody2D>().gravityScale = -1;
				Vector3 theScale = go.transform.localScale;
				theScale.y *= -1;
				go.transform.localScale = theScale;
			}

			lastTimeTreesTop = Time.time;
			nextTimeTreesTop = Random.Range(minTimeTrees, maxTimeTrees);;
		}

		if (lastTimeTreesBottom + nextTimeTreesBottom < Time.time) {
			GameObject go = trees[Random.Range(0, grass.Length)];
			go = Instantiate(go, new Vector3(offScreenX, -height, 0), Quaternion.identity);
			go.GetComponent<SideMover>().speed = moveSpeed;

			go.GetComponent<Rigidbody2D>().gravityScale = -1;
			Vector3 theScale = go.transform.localScale;
			theScale.y *= -1;
			go.transform.localScale = theScale;

			lastTimeTreesBottom = Time.time;
			nextTimeTreesBottom = Random.Range(minTimeTrees, maxTimeTrees); ;
		}
	}
}
