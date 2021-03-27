using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class _GameManager : MonoBehaviour
{


    [SerializeField] Sprite demoTable;
    [SerializeField] Sprite classicTable;
    [SerializeField] Sprite privateTable;



    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject tableMenu;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject join;
    [SerializeField] GameObject create;
    [SerializeField] GameObject coinPanel;
    [SerializeField] GameObject playerSelectPanel;
    [SerializeField] GameObject lobbyPanel;


    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject settingPanel;

    
    [SerializeField] Text playernumberText;
    public int playedCoins;
    [SerializeField] Text coinText;
    [SerializeField] GameObject playersProfile;

   

    [SerializeField] Image[] tableImages;
    [SerializeField] Text[] tableNames;
    [SerializeField] Text[] userNames;


    [SerializeField] Animator tableAnim;
    [SerializeField] Animator createAnim;
    [SerializeField] Animator joinAnim;
    [SerializeField] Animator gameAnim;
    [SerializeField] Animator selectedPlayerAnim;
    [SerializeField] Animator lobbyAnim;

    [SerializeField] InputField gameIdField;
    public string gameId;
    [SerializeField] Text gameIdDisplayText;
    [SerializeField] InputField gameIdCheckField;
    [SerializeField] GameObject checkGameIdErrorPanel;
 
    // Start is called before the first frame update
    void Start()
    {
        foreach(var username in userNames)
        {
            username.text = _UserIdManager.Instance.username;
        }
        playedCoins = _UserIdManager.Instance.coinValue;
        coinText.text = playedCoins.ToString()+"$";
        
        playernumberText.text = _UserIdManager.Instance.playerNumber.ToString();

        lobbyPanel.SetActive(true);

        

    }




    public void tableSelected()
    {

        string tableName = EventSystem.current.currentSelectedGameObject.name;
        
        switch (tableName)
        {
            case "Demo Table":
                foreach(var tableimage in tableImages)
                {
                    tableimage.sprite = demoTable;
                }
                foreach(var tablename in tableNames)
                {
                    tablename.text = tableName;
                }
                break;

            case "Classic Table":
                foreach (var tableimage in tableImages)
                {
                    tableimage.sprite = classicTable;
                }
                foreach (var tablename in tableNames)
                {
                    tablename.text = tableName;
                }
                break;

            case "Private Table":
                foreach (var tableimage in tableImages)
                {
                    tableimage.sprite = privateTable;
                }
                foreach (var tablename in tableNames)
                {
                    tablename.text = tableName;
                }
                break;

            default:
                break;
        }
        if (tableMenu.activeSelf == false)
        {
            tableMenu.SetActive(true);
            tableAnim.SetBool("Table", true);
        }
        else
        {
            tableAnim.SetBool("Table", true);
        }
        

    }


    public void backToMain()
    {
        tableAnim.SetBool("Table", false);
    }






    public void createTable()
    {
        if (create.activeSelf == false)
        {
            create.SetActive(true);
            createAnim.SetBool("Create", true);
        }
        else
            createAnim.SetBool("Create", true);
    }

    public void createBackToTable()
    {
        createAnim.SetBool("Create", false);
    }

    public void joinTable()
    {
        if (join.activeSelf == false)
        {
            join.SetActive(true);
            joinAnim.SetBool("Join", true);
        }
        else
            joinAnim.SetBool("Join", true);

    }
    public void joinBackToTable()
    {
        joinAnim.SetBool("Join", false);
        checkGameIdErrorPanel.SetActive(false);
    }


    public void selectedplayer()
    {
        if (playerSelectPanel.activeSelf == false)
        {
            playerSelectPanel.SetActive(true);
            selectedPlayerAnim.SetBool("Select", true);
        }
        else
            selectedPlayerAnim.SetBool("Select", true);


        gameId = gameIdField.text;
        gameIdDisplayText.text = "Game id : " + gameId;
        PlayerPrefs.SetString("gameId", gameId);
    }
    public void joinBackToCreate()
    {
        selectedPlayerAnim.SetBool("Select", false);
    }

    public void lobby()
    {
        if (lobbyPanel.activeSelf == false)
        {
            lobbyPanel.SetActive(true);
            lobbyAnim.SetBool("Lobby", true);
        }
        else
            lobbyAnim.SetBool("Lobby", true);

    }

    public void joinBackToSelected()
    {
        lobbyAnim.SetBool("Lobby", false);
    }

    public void enoughCoin()
    {
        if (coinPanel.activeSelf == false)
            coinPanel.SetActive(true);
        else
            coinPanel.SetActive(false);

    }


    public void startGame()
    {


        string startgame= EventSystem.current.currentSelectedGameObject.name;

        switch (startgame)
        {
            case "Start":
                if (gameMenu.activeSelf == false)
                {
                    gameMenu.SetActive(true);
                    gameAnim.SetBool("Game", true);
                }
                else
                    gameAnim.SetBool("Game", true);
                break;


            case "Join":
                if (string.Compare(PlayerPrefs.GetString("gameId"), gameIdCheckField.text) == 0)
                {
                    if (gameMenu.activeSelf == false)
                    {
                        gameMenu.SetActive(true);
                        gameAnim.SetBool("Game", true);
                    }
                    else
                        gameAnim.SetBool("Game", true);
                }
                else
                {
                    checkGameIdErrorPanel.SetActive(true);
                }
                break;


            default:
                break;
        }



        

    }
    public void closecheckGameIdErrorPanel()
    {
        checkGameIdErrorPanel.SetActive(false);
    }

    public void setting()
    {
        if (settingPanel.activeSelf == false)
            settingPanel.SetActive(true);
        else
            settingPanel.SetActive(false);


    }

    public void menu()
    {
        if (menuPanel.activeSelf == false)
            menuPanel.SetActive(true);
        else
            menuPanel.SetActive(false);
    }

    public void backToLobby()
    {
        menuPanel.SetActive(false);
        createAnim.SetBool("Create", false);
        joinAnim.SetBool("Join", false);
        gameAnim.SetBool("Game", false);
        selectedPlayerAnim.SetBool("Select", false);
    }

    public void switchTable()
    {
        menuPanel.SetActive(false);
        tableAnim.SetBool("Table", false);
        createAnim.SetBool("Create", false);
        joinAnim.SetBool("Join", false);
        gameAnim.SetBool("Game", false);
        lobbyAnim.SetBool("Lobby", false);
        selectedPlayerAnim.SetBool("Select", false);
    }

    public void Logout()
    {
        SceneManager.LoadScene("LoadScene");
        
       
    }


    public void addCoin()
    {
        if (playedCoins < _UserIdManager.Instance.coinValue)
        {
            playedCoins += 100;
        }
        coinText.text = playedCoins.ToString() + "$";
    }

    public void removeCoin()
    {

        playedCoins -= 100;
        coinText.text = playedCoins.ToString() + "$";
    }


    public void addPlayer()
    {
        if (_UserIdManager.Instance.playerNumber < 5)
        {
            _UserIdManager.Instance.playerNumber += 1;
        }
        playernumberText.text = _UserIdManager.Instance.playerNumber.ToString();


    }

    public void removePlayer()
    {
        if (_UserIdManager.Instance.playerNumber > 2)
        {
            _UserIdManager.Instance.playerNumber -= 1;
        }
        playernumberText.text = _UserIdManager.Instance.playerNumber.ToString();



    }


    

    // Update is called once per frame
    void Update()
    {
        foreach(var user in userNames)
        {
            user.text = _UserIdManager.Instance.username;
        }
    }
}
