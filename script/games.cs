using UnityEngine;

using System.Collections;

public class games : FFMonoBehaviour

{
    private static games instance;

    public Enemy m_enemy;

    public static games Instance

    {

        get

        {

            return instance;

        }

    }

    public override void Awake()

    {
       
        base.Awake();

            
        instance = this;
        m_battleStateManager = new BattleStateMachineManager();

        m_battleStateManager.Init();

        m_battleStateManager.SetState(BattleStateIndex.BattleReady);

        m_character.Init();

        m_character.SetState(UnitStateIndex.Idle);

        Refresh();
    }


    public void TouchScreen(Vector3 pos)

    {

        if (m_enemy == null)

            return;



        m_enemy.SetDamage(10);




        GameObject effectObject = ResourceManager.Instance.ClonePrefab("Hit");

    }



public void AttackEvent(int attack)

    {

        if (m_enemy == null)

            return;



        m_enemy.SetDamage(attack);



    }


    public void Update()

    {

        if (m_character)

        {

            m_character.UpdateFrame();

        }

    }



    public void LateUpdate()

    {

        if (m_character)

        {

            m_character.AfterUpdateFrame();

        }

    }
    public Enemy enemy

    {

        get { return m_enemy; }

        set { m_enemy = value; }

    }
   
    public void Refresh()

    {

        InvenData.ItemSaveData saveData = GameInfo.Instance.invenData.LoadData(ItemIndex.Gold);

      int gold = 0;

       if (saveData != null)

          gold = saveData.num;

    m_goldLabel.text = string.Format(string.Format("Gold : {0}", gold));

    }

    public BattleStateMachineManager battleStateManager

    {

        get { return m_battleStateManager; }



    }
    public UnityEngine.UI.Text m_goldLabel;
    public UnityEngine.UI.Text m_stageLabel;
    public UnityEngine.UI.Text m_hpLabel;
    public UISlider m_hpBar;
    BattleStateMachineManager m_battleStateManager;
    public Character m_character;
}
