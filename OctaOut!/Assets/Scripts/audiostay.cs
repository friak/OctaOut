using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiostay : MonoBehaviour
{

    public static audiostay instance;
    void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(transform.gameObject);
        }
}
