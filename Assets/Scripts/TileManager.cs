using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private List<GameObject> activeTiles;

	private float spawnZ = 0f;
	private float spawnY = -0.5f;
	private float tileLenght = 10.0f;
	private float safeZone = 20f;
	private int tilesOnScreen = 7;
	private int lastPrefabIndex = 0;


	private Transform playerTransform;


	// Use this for initialization
	void Start () {

		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < tilesOnScreen; i++) 
		{
			if (i < 2)
				SpawnTile (0);
			else
				SpawnTile ();

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLenght)) 
		{
			SpawnTile ();
			DeleteTile ();
		}


		
	}

	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject createTile;

		if (prefabIndex == -1) {
			createTile = Instantiate (tilePrefabs [RandomPrefabIndex ()]) as GameObject;
		} else {
			createTile = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		}

		createTile.transform.SetParent (transform);
		createTile.transform.position = (Vector3.forward * spawnZ) + new Vector3(0f,-0.5f,0f);
		spawnZ += tileLenght;
		activeTiles.Add (createTile);
	}

	private void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}

	private int RandomPrefabIndex()
	{
		//programare defensiva
		if (tilePrefabs.Length <= 1)
			return 0;
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex)
		{
			randomIndex = Random.Range (0, tilePrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
