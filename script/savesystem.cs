using UnityEngine;
using System.Collections;

public class savesystem : MonoBehaviour {
    public UnityEngine.UI.Text gpsdisply;
    public GOLD GOLD;
    public GOLD click;
    public itemman[] items;
    public itemman ad;
    // Use this for initialization
    void Start () {
        GOLD.gold = PlayerPrefs.GetFloat("Cost", GOLD.gold);
        GOLD.goldperclick = PlayerPrefs.GetInt("goldperclick", GOLD.goldperclick);
        loadstuff();
        StartCoroutine(AutoTick());
    }
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetFloat("Cost", GOLD.gold);
        PlayerPrefs.SetInt("goldperclick", GOLD.goldperclick);    
        PlayerPrefs.Save();
        gpsdisply.text = Getgoldpersec() + " 지식/초";
    }
    public float Getgoldpersec()
    {
        float tick = 0;
        foreach (itemman item in items)
        {
            tick += item.count * item.tickvalue;
            PlayerPrefs.SetInt(item.itemname + "Count", item.count);
            PlayerPrefs.SetFloat(item.itemname + "Cost", item.cost);
        }
        return tick;
    }
    public void AutoGoldpersec()
    {
        click.gold += Getgoldpersec() / 5;
       
    }
    public void loadstuff()
    {
        foreach (itemman item in items)
        {
          
           item.count= PlayerPrefs.GetInt(item.itemname + "Count", item.count);
            item.cost= PlayerPrefs.GetFloat(item.itemname + "Cost", item.cost);
        }
    }
    IEnumerator AutoTick()
    {
        while (true)
        {
            AutoGoldpersec();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
