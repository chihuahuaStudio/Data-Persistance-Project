using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InputName : MonoBehaviour
{
    public static InputName Instance;

    public InputField inputField;
    [HideInInspector]public string myName;
    
    public void GetName()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        myName = inputField.text;
        DontDestroyOnLoad(gameObject);
      
    }

   
}
