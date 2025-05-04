using UnityEngine;

public class CheckSecondLvlEnd : MonoBehaviour
{
    [SerializeField]
    PlayerView playerView;
    [SerializeField]
    GameObject nextLvlPrefab;
    


    private bool isQPressed = false;


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
        if (playerView.currentCollider != "Exit")
        {
            return;
        }

        Debug.Log("Exit");
        PrefabLoader.LoadPrefab(nextLvlPrefab);

    }
}
