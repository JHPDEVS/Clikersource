using UnityEngine;
using System.Collections;

public class GOLD : MonoBehaviour {
    public UnityEngine.UI.Text gpc;
    public UnityEngine.UI.Text golddisplay;
    public float gold = 0;
    public int goldperclick = 1;
    void Start()
    {
      
        //Create data instance
        //Add keys with significant names and values
        //Save the data


     
    }
    void Update(){
     
     
        gpc.text = conventer.Instance.GetCurrencyIntoString(goldperclick, false, true) ;
        golddisplay.text = "지식: " +conventer.Instance.GetCurrencyIntoString(gold,false,false);	
	}
    public void Clicked()
    {
        gold += goldperclick;
      
    }
}
