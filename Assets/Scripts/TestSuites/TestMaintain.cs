using UnityEngine;
using System.Collections;

public class TestMaintain : MonoBehaviour {

    MainTainService service;

    void Awake()
    {
        service = GetComponent<MainTainService>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            InitToken();
        }
	}

    public void InitToken()
    {
        long id = service.SessionGenerate();
        Debug.Log(id);
    }
}
