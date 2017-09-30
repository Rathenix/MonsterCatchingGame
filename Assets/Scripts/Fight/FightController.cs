using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightController : MonoBehaviour {

    Canvas canvas;
    public GameObject EngagedMonsterObj;
    public GameObject PlayerMonsterObj;
    FightMonster EngagedMonster;
    FightMonster PlayerMonster;
    public GameObject FightButtonObj;
    public GameObject CaptureButtonObj;
    public GameObject ItemButtonObj;
    public GameObject RunButtonObj;
    public GameObject MonsterTray;
    GameObject heldButton;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        EngagedMonsterObj = Instantiate(Resources.Load("Fight/EngagedMonster", typeof(GameObject)), canvas.transform) as GameObject;
        EngagedMonster = EngagedMonsterObj.GetComponent<FightMonster>();
        EngagedMonster.Initialize(GameController.EngagedMonster);
        if (GameController.Team.Count > 0)
        {
            PlayerMonsterObj = Instantiate(Resources.Load("Fight/PlayerMonster", typeof(GameObject)), canvas.transform) as GameObject;
            PlayerMonster = PlayerMonsterObj.GetComponent<FightMonster>();
            PlayerMonster.Initialize(GameController.Team[0]);
            PlayerMonster.IsPlayer = true;
        }
        
    }
    private void Update()
    {
        CheckForTaps();
    }
    void CheckForTaps()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
            if (hitInfo)
            {
                if (hitInfo.transform.gameObject.CompareTag("Button"))
                {
                    OnButtonTouch(Input.GetTouch(i), hitInfo);
                }
                else
                {
                    UnHighlightAllButtons();
                }
            }
            else
            {
                UnHighlightAllButtons();
            }
        }
    }
    void OnButtonTouch(Touch touch, RaycastHit2D hitInfo)
    {
        var touchedMat = hitInfo.transform.GetComponent<Renderer>().material;
        float brightness = 175f / 255f;
        var tappedColor = new Color(brightness, brightness, brightness);

        if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            if (hitInfo.transform.gameObject != heldButton)
            {
                UnHighlightAllButtons();
                heldButton = hitInfo.transform.gameObject;
            }
            touchedMat.color = tappedColor;
        }
        if (touch.phase == TouchPhase.Ended)
        {
            touchedMat.color = new Color(1, 1, 1);
            if (hitInfo.transform == FightButtonObj.transform)
            {
                OnFightButtonTap();
            }
            if (hitInfo.transform == CaptureButtonObj.transform)
            {
                OnCaptureButtonTap();
            }
            if (hitInfo.transform == ItemButtonObj.transform)
            {
                OnItemButtonTap();
            }
            if (hitInfo.transform == RunButtonObj.transform)
            {
                OnRunButtonTap();
            }
        }
    }
    void UnHighlightAllButtons()
    {
        var mat = FightButtonObj.GetComponent<Renderer>().material;
        mat.color = new Color(1, 1, 1);
        mat = CaptureButtonObj.GetComponent<Renderer>().material;
        mat.color = new Color(1, 1, 1);
        mat = ItemButtonObj.GetComponent<Renderer>().material;
        mat.color = new Color(1, 1, 1);
        mat = RunButtonObj.GetComponent<Renderer>().material;
        mat.color = new Color(1, 1, 1);
    }
    void OnFightButtonTap()
    {
        Debug.Log("You clicked Fight!");
    }
    void OnCaptureButtonTap()
    {
        Debug.Log("You clicked Capture!");
    }
    void OnItemButtonTap()
    {
        Debug.Log("You clicked Item!");
    }
    void OnRunButtonTap()
    {
        Debug.Log("You ran away!");
        SceneManager.LoadScene("Map");
    }
}
