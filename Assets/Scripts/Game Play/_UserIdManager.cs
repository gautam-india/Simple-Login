using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _UserIdManager : MonoBehaviour
{

    public static _UserIdManager Instance;



    public string email;
    public string username;
    public string City;
    public string phonenumber;


    public string id;
    public string password;

    public int coinValue;
    public int playerNumber;

    void Awake()
    {
        Screen.SetResolution(480, 800, true, 60);
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        playerNumber = 2;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        coinValue = 9000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
