using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    static SystemManager instance = null;
    
    public SystemManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    
}
