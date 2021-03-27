using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class _LoadScene : MonoBehaviour
{



    [SerializeField] GameObject PreLoad;
    [SerializeField] GameObject SignUp;
    [SerializeField] GameObject LogIn;


    
    [SerializeField] InputField emailAddress;
    [SerializeField] InputField userName;
    [SerializeField] InputField city;
    [SerializeField] InputField phoneNumber;


    [SerializeField] InputField Id;
    [SerializeField] InputField Password;

    [SerializeField] GameObject loginErrorPanel;
    [SerializeField] GameObject newUserPanel;


    public string email;
    public string username;
    public string City;
    public string phonenumber;


    public string id;
    public string password;




    // Start is called before the first frame update
    void Start()
    {
        loginErrorPanel.SetActive(false);
        newUserPanel.SetActive(false);
        LogIn.SetActive(false);
        SignUp.SetActive(false);
        PreLoad.SetActive(true);
        StartCoroutine(preLoad());
    }


    IEnumerator preLoad()
    {

        yield return new WaitForSeconds(1f);
        PreLoad.SetActive(false);
        SignUp.SetActive(true);

    }


    public void LoginOrSignUp()
    {

        string name = EventSystem.current.currentSelectedGameObject.name;
        

        switch (name)
        {

            case "Join":
                LogIn.SetActive(true);
                SignUp.SetActive(false);
                loginErrorPanel.SetActive(false);
                newUserPanel.SetActive(false);
                break;

            case "Create":
                LogIn.SetActive(false);
                SignUp.SetActive(true);
                loginErrorPanel.SetActive(false);
                newUserPanel.SetActive(false);
                break;


            default:
                break;


        }


    }




    public void signUp()
    {
        _UserIdManager.Instance.email = emailAddress.text;
        _UserIdManager.Instance.username = userName.text;
        _UserIdManager.Instance.City = city.text;
        _UserIdManager.Instance.phonenumber = phoneNumber.text;


        SceneManager.LoadScene("Game Play");
        PlayerPrefs.SetString("userNames", _UserIdManager.Instance.username);
        PlayerPrefs.SetString("email", _UserIdManager.Instance.email);
        PlayerPrefs.SetString("city", _UserIdManager.Instance.City);
        PlayerPrefs.SetString("phoneNumber", _UserIdManager.Instance.phonenumber);

        PlayerPrefs.SetString("id", _UserIdManager.Instance.username);
        PlayerPrefs.SetString("password", _UserIdManager.Instance.phonenumber);
        
    }


    public void Login()
    {


        _UserIdManager.Instance.id = Id.text;
        _UserIdManager.Instance.password = Password.text;


        string localid = PlayerPrefs.GetString("userNames");
        string localPassword = PlayerPrefs.GetString("password");

        if (string.Compare(_UserIdManager.Instance.id, "") == 0)
        {
            if (string.Compare(_UserIdManager.Instance.password, "") == 0)
            {
                newUserPanel.SetActive(true);
            }
           
        }
        else if (string.Compare(Id.text, localid)   == 0)
        {
            if(string.Compare(Password.text, localPassword)   == 0)
            {
                SceneManager.LoadScene("Game Play");
            }
            else
            {
                loginErrorPanel.SetActive(true);
            }
        }
        else if (string.Compare(Id.text, localid) != 0 || string.Compare(Password.text, localPassword) != 0)
        {
            
             loginErrorPanel.SetActive(true);
            Debug.Log("3");
            
        }
        
    }

    public void closeLoginErrorpanel()
    {
        loginErrorPanel.SetActive(false);
    }

    public void closenewuserpanel()
    {
        newUserPanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
