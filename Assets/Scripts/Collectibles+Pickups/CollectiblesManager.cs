using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager instance;

    private void Awake()
    {
        instance = this;
    }




    public int collectiblesCount;

    public int extaLifeTreshhold;



    // Start is called before the first frame update
    void Start()
    {
        collectiblesCount = InfoTracker.instance.currentFruit;

        if (UIController.instance != null)
        {
            UIController.instance.UpdateCoolectiblesDisplay(collectiblesCount);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCollectible(int amount)
    {
        collectiblesCount += amount;
        if (collectiblesCount >= extaLifeTreshhold)
        {
            collectiblesCount -= extaLifeTreshhold;
            if (LifeController.instance != null)
            {
            LifeController.instance.AddLife();
            }
        }
        if (UIController.instance != null)
        {
            UIController.instance.UpdateCoolectiblesDisplay(collectiblesCount);

        }

    }

}
