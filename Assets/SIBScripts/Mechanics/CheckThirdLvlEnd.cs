using UnityEngine;

public class CheckThirdLvlEnd : MonoBehaviour
{
    [SerializeField]
    GameObject ripPlayerObj;
    [SerializeField]
    GameObject ripDragonObj;
    [SerializeField]
    GameObject dragonObj;
    [SerializeField]
    FireAnimation fireAnimation;

    [SerializeField]
    PlayerView playerView;
    [SerializeField]
    GameObject nextLvlPrefab;
    


    private bool isQPressed = false;
    private bool isDragonDead = false;

    private int fireCount = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            SetQPressed();

        }

        CheckLvlEnd();
    }

    public void SetQPressed()
    {
        isQPressed = true;
    }

    void CheckLvlEnd()
    {
        if (playerView.currentCollider == "FireCollider" && !isDragonDead)
        {
            playerView.MoveToInitPose();
            fireCount += 1;
            ripPlayerObj.SetActive(true);
            fireAnimation.ShowFire();

            return;
        }

        if (playerView.currentCollider == "FireCollider")
        {
            Debug.Log("Exit");
            PrefabLoader.LoadPrefab(nextLvlPrefab);
        }

        return;
    }

    public void CheckDragonDead()
    {
        if (playerView.integerPart == 9999)
        {
            isDragonDead = true;
            dragonObj.SetActive(false);
            ripDragonObj.SetActive(true);
        }
    }
}
