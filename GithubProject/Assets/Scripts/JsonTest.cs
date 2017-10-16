using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;
using System.IO;

public class Player1{
	public bool IsLock{ get; set;}
	public string Name {
		get;
		set;
	}
	public string Sex {
		get;
		set;
	}
}

public class JsonTest : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
		//CreateJson ();
		//EasyParse ();
		//ParsePlayer ();
		//ReadRTF ();
		//ParseArray ();
		ReadJson ();
	}

	void ReadJson(){
	 //1:Read Direct
//		string path = Application.dataPath+"/Test.txt";
//		string content = File.ReadAllText (path);
//		Debug.Log (content);
//		text.text = content;

		//2:Use Resource.Load
//		TextAsset ass = Resources.Load ("Test") as TextAsset;
//		print (ass.text);
//		text.text = ass.text;

		//3:
//		string path2 = Application.streamingAssetsPath+"/Test.txt";
//		string content2 = File.ReadAllText (path2);
//		Debug.Log (content2);
//		text.text = content2;

		//4
		string path3 = Application.persistentDataPath + "/Test.txt";
		string content3 = File.ReadAllText (path3);
		Debug.Log (content3);
		text.text = content3;
	}

	void ParseArray(){
		string str = "{'name':'taotao','id':10,'items':[" + 
			"{'itemid':1001,'itemname':'dtao'}," + 
			"{'itemid':1002,'itemname':'test_2'}" + "]}";
		//这里是json解析
		JsonData jd = JsonMapper.ToObject (str);
		Debug.Log ("name="+jd["name"]);
		Debug.Log ("id="+jd["id"]);
		JsonData jdItems = jd ["items"];
		Debug.Log (jdItems.Count);
		for(int i = 0; i<jdItems.Count;i++){
			Debug.Log ("itemid="+jdItems[i]["itemid"]);
			Debug.Log ("itemname="+jdItems[i]["itemname"]);
		}
		Debug.Log ("items is or not array, it's"+jdItems.IsArray);
	}

	void ReadRTF(){
		TextAsset ass = Resources.Load ("Test") as TextAsset;
		print (ass.text);

		JsonData dataObj = JsonMapper.ToObject (ass.text);
	}

	void ParsePlayer(){
		Player1 player = new Player1 ();
		player.Name = "aaa";
		player.IsLock = false;
		player.Sex = "male";
		string str = JsonMapper.ToJson (player);
		print (str);

		Player1 player2 = JsonMapper.ToObject<Player1> (str);
		print (player2.Name);
		print (player2.Sex);
	}

	void CreateJson(){
		JsonData data = new JsonData ();
		data["name"] = "zhangsan";
		data ["age"] = 20;
		data["sex"]= "male";
		data["options"] = new JsonData();
		data ["options"] ["age"] = 20;
		data ["options"] ["sex"] = "male";
		string jsonStr = data.ToString ();
		print (jsonStr);

		JsonData obj = JsonMapper.ToObject (jsonStr);
		print (data["name"]);
		print (data["options"]["age"]);
	}

	void EasyParse(){
		string str = "{'code':200,'message':'Success'}";
		JsonData obj = JsonMapper.ToObject (str);
		if((int)obj["code"]==200){
			print (obj["message"]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
