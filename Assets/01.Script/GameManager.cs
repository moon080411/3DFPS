using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field:SerializeField]public GameObject Player { get; private set; }
    public static GameManager Instance { get; private set; }

    public static bool set = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            set = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
