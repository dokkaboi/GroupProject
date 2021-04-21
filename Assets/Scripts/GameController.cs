using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject[] carList;
    public int carChoice = 0;

    void Awake()
    {
        Instantiate(carList[carChoice], new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
