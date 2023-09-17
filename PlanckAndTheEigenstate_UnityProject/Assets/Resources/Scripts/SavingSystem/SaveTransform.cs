using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveTransform : MonoBehaviour, ISaveable
{
    [SerializeField] SavingSystem saving;
    int id;
    int sceneId = 0;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneId = SceneManager.GetActiveScene().buildIndex;
        id = GetHashCode();
        SaveData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hi");
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            SaveData();
        }
    }

    public void DeleteData()
    {
        throw new System.NotImplementedException();
    }

    public void LoadData()
    {
        transform.position = (Vector3)saving.Load(sceneId, id);
    }

    public void SaveData()
    {
        saving.Save(sceneId, id, transform.position);
    }

    public void UpdateData()
    {
        throw new System.NotImplementedException();
    }
}
