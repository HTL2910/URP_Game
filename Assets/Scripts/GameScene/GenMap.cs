using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenMap : MonoBehaviour
{
    [Header("tree")]
    [SerializeField] GameObject tree1;
    [SerializeField] int countTree1=1;
    [SerializeField] GameObject tree2;
    [SerializeField] int countTree2=1;
    [SerializeField] GameObject cupBoard;
    [SerializeField] int countCupBoard=1;
    [SerializeField] Transform treesParent;
    [Header("Attribute")]
    //private float maxDistance = 400f;
    private float minDistance = 0f;
    private float leftTreeSpawn = 0f;
    private float rightTreeSpawn = 100f;
    private float horizontalDistance = 50f;
    private float minCarSpawn = 10f;//use for cat
    private float maxCarSpawn = 90f;//use for cat
    private float minpadding = 50f;
    private float maxpadding = 100f;

    [Header("Cars")]
    [SerializeField] Transform carsParent;
    [SerializeField] GameObject car;
    [SerializeField] int countCar;

    [Header("Cat")]
    [SerializeField] Transform catsParent;
    [SerializeField] GameObject cat;
    [SerializeField] int countCatSpawn = 1;

    private void Start()
    {
        GenerationMap();
    }
    private void GenerationMap()
    {
        GenObject(tree1, countTree1, leftTreeSpawn - horizontalDistance, leftTreeSpawn, treesParent);
        GenObject(tree2, countTree2, rightTreeSpawn , rightTreeSpawn + horizontalDistance, treesParent);
        GenObject(cupBoard, countCupBoard, leftTreeSpawn - horizontalDistance, leftTreeSpawn, treesParent);
        GenObject(cupBoard, countCupBoard, rightTreeSpawn, rightTreeSpawn + horizontalDistance, treesParent);
        GenObject(car, countCar, minCarSpawn, maxCarSpawn, carsParent);
        GenObject(cat, countCatSpawn, minCarSpawn, maxCarSpawn, catsParent);


    }
    private void GenObject(GameObject Obj,int count,float min,float max,Transform parent)
    {
        int padding = Mathf.CeilToInt(Random.Range(minpadding, maxpadding));
        
        float posZ = Random.Range(minDistance, maxpadding);
        for(int i=0;i<count;i++)
        {
            float posX = Random.Range(min, max);
            GameObject tmp = Instantiate(Obj);
            tmp.transform.position=new Vector3(posX,0f, posZ + (padding * i));
            tmp.transform.SetParent(parent);
        }

    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
