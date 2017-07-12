using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class itemman : MonoBehaviour
{
    public UnityEngine.UI.Text iteminfo;
    public GOLD click;
    public float cost;
    public int tickvalue;
    public int count;
    public string itemname;
    private float baseCost;
    public Color standard;
    public Color afford;
    public savesystem auto;
    // Use this for initialization
    void Start()
    {
        baseCost = cost;

    }

    // Update is called once per frame
    void Update()
    {
        iteminfo.text = itemname+"("+count+")" + "\n가격: " + cost + "\n지식: " + tickvalue + "/s";
        if (click.gold >= cost)
        {
            GetComponent<Image>().color = afford;
        }
        else
        {
            GetComponent<Image>().color = standard;
        }
    }
    public void PurchasedItem()
    {
        if (click.gold >= cost)
        {
            click.gold -= cost;
            count += 1;
            cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, count));
            auto.Getgoldpersec();
        }
    }
}
