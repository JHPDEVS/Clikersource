using UnityEngine;
using System.Collections;

public class conventer : MonoBehaviour {

    private static conventer instance;
    public static conventer Instance
    {
        get
        {
            return instance;
        }

    }
    // Use this for initialization
    void Awake() {
        createInstance();
    }

    // Update is called once per frame
    void createInstance() {
        if (instance == null)
        {
            instance = this;
        }
    }
    public string GetCurrencyIntoString(float valueToConvert,bool currencyPerSec,bool currencyPerClick)
    {
        string converted;
        if (valueToConvert >= 1000000)
        {
            converted = (valueToConvert / 1000000f).ToString("f3") + " mil";
       }else if (valueToConvert >= 1000)
        { 
           converted = (valueToConvert / 1000f).ToString("f3") + " 원";
        }
        else
        {
            converted = valueToConvert +" 원";
        }
        if (currencyPerSec == true)
        {
            converted = converted + "터치";
        }
        if (currencyPerClick == true)
        {
            converted = converted +"/클릭";
        }
        return converted;
    }
    }