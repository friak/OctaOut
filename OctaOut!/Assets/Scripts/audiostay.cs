using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiostay : MonoBehaviour
{
   
        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
}
