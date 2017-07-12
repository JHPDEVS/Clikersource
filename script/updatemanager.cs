using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class updatemanager : MonoBehaviour
{
    public GOLD click;
    public UnityEngine.UI.Text iteminfo;
    public float cost;
    public int count = 0;
    public int clickpower;
    public string itemname;
    public Color standard;
    public Color affordable;
    private float baseCost;
    private Slider _slider;
    void Start()
    {
        baseCost = cost;
        _slider = GetComponentInChildren<Slider>();
       count = PlayerPrefs.GetInt(itemname, count);
       cost = PlayerPrefs.GetFloat(itemname + "cost", cost);
        //Load the data we just saved
        //Add keys with significant names and values
        //Save the data
    }
    // Update is called once per frame
    void Update()
    {
       
        iteminfo.text = itemname + "(" + count + ")"+ "\nCost: " + cost + "\nPower: +" + clickpower;
        _slider.value = click.gold / cost * 100;
        if (_slider.value >= 100)
        {
            GetComponent<Image>().color = affordable;
        }
        else
        {
            GetComponent<Image>().color = standard;
        }
    }
   

    public void purchasedupgrade()
    {
        if (click.gold >= cost)
        {
           
            click.gold -= cost;
            count += 1;
            click.goldperclick += clickpower;
            cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, count));
          PlayerPrefs.SetInt(itemname, count);
            PlayerPrefs.SetFloat(itemname + "cost", cost);
        }
    }
}
