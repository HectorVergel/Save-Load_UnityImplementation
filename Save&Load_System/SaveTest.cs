using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SaveTest : MonoBehaviour, ISaveData
{

    Dictionary<string, bool> coin = new Dictionary<string, bool>();
    public int deathCount;
    public string scene;

    

    private void Start()
    {
        coin = GameDataManager.Load<Dictionary<string, bool>>("coinsCollected");
        Debug.Log(deathCount);
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            coin.TryAdd("pepe" + deathCount, true);
            deathCount++;

            
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(scene);
        }

    }

    public void SaveData()
    {
        GameDataManager.Save("coinsCollected", coin);
    }

    public void Subscribe()
    {
        GameDataManager.Add(this);
    }

    public void Unsubscribe()
    {
        GameDataManager.Remove(this);
    }
}
