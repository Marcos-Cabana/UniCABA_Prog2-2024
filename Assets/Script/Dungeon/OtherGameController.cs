using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class OtherGameController : MonoBehaviour
{
    public static OtherGameController gameController;

    [SerializeField] TextMeshProUGUI _goldValue;
    [SerializeField] TextMeshProUGUI _healthValue;

    
    //Part of SceneManager
    public int actualScene = 1;
    public int prevScene = 0;

    //Player Statistis
    public int _playerHealth = 100;
    private int _tempPlayerHealth = 0;
    public int _playerGold = 0;
    private int _tempPlayerGold = 1;

    private Vector3 _playerPosition;

    void Awake()
    {
        if(gameController == null)
        {
            DontDestroyOnLoad(gameObject);
            gameController = this;
        }
        else if(gameController != this)
        {
            Destroy(gameObject);
        }
        _playerPosition = Vector3.one;

        

    }

    private void Start() 
    {
        LoadGameData();
    }

    private void OnApplicationQuit() 
    {
        SaveGameData();
    } 
    
    // Update is called once per frame
    void Update()
    {
        if(_playerHealth != _tempPlayerHealth)
        {
            _tempPlayerHealth = _playerHealth;
            _healthValue.text = _playerHealth.ToString();
        }
        
        if(_playerGold != _tempPlayerGold)
        {
            _tempPlayerGold = _playerGold;
            _goldValue.text = _playerGold.ToString();
        }
    }

    public void ActiveKey(int levelKey)
    {

    }

    public void SaveGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

        GameData data = new GameData();
        data.health = _playerHealth;
        data.gold = _playerGold;
        data.playerPosition_x = _playerPosition.x;
        data.playerPosition_y = _playerPosition.y;
        data.playerPosition_z = _playerPosition.z;

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Data Saved");
    }
    public void LoadGameData()
    {
       if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
       {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);

            GameData data = (GameData)bf.Deserialize(file);

            _playerHealth = data.health;
            _playerGold = data.gold;
            _playerPosition.x = data.playerPosition_x;
            _playerPosition.y = data.playerPosition_y;
            _playerPosition.z = data.playerPosition_z;

            file.Close();

            Debug.Log("Data Loaded");
       }
    }
  
    
}

[Serializable]
class GameData
{
    public int health;
    public int gold;
    public float playerPosition_x;
    public float playerPosition_y;
    public float playerPosition_z;
}
