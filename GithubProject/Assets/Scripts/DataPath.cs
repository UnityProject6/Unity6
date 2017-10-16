using UnityEngine;
using System.Collections;

public class DataPath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (Application.dataPath);
		Debug.Log (Application.persistentDataPath);
		Debug.Log (Application.streamingAssetsPath);
		Debug.Log (Application.temporaryCachePath);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
