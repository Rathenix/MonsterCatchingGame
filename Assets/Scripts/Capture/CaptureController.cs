using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaptureController : MonoBehaviour {

    public Vector3 topBounds = new Vector3();
    public Vector3 bottomBounds = new Vector3();
    GameObject Chip;
    float ChipSpawnTimer = 0;
    public int ChipSpawnChance = 5;
    public float ChipSpawnSeconds = 1;
    public int MaxChips = 5;
    int CurrentChips;
    public GameObject ChipsText;

    private void Start()
    {
        var engagedMonster = GameController.EngagedMonster;
        var captureMonsterObj = Instantiate(engagedMonster.CaptureObject, new Vector3(-80, 100, 0), new Quaternion());
        var captureMonster = captureMonsterObj.GetComponent<CaptureMonster>();
        captureMonster.captureController = this;
        captureMonster.Initialize(engagedMonster);
        Chip = Resources.Load("Capture/Chip", typeof(GameObject)) as GameObject;
        ChipsText.GetComponent<TextMeshProUGUI>().text = "Chips: " + GameController.PlayerChips;
    }

    private void Update()
    {
        UpdateChips();
    }

    void UpdateChips()
    {
        if (CurrentChips <= MaxChips)
        {
            ChipSpawnTimer += Time.deltaTime;
            if (ChipSpawnTimer > ChipSpawnSeconds)
            {
                var rand = Random.Range(1, 101);
                if (rand <= ChipSpawnChance)
                {
                    var x = Random.Range(topBounds.x, bottomBounds.x);
                    var y = Random.Range(bottomBounds.y, topBounds.y);
                    var chip = Instantiate(Chip, new Vector3(x, y, 0), new Quaternion());
                    chip.GetComponent<CaptureChip>().Controller = this;
                    CurrentChips++;
                }
                ChipSpawnTimer = 0;
            }
        }
    }

    public void MonsterCaptured(Monster monster)
    {
        GameController.Team.Add(monster);
        SceneManager.LoadScene("Map");
    }

    public void ChipCollected()
    {
        GameController.PlayerChips += 1;
        ChipsText.GetComponent<TextMeshProUGUI>().text = "Chips: " + GameController.PlayerChips;
    }

    public void DestroyChip(GameObject chip)
    {
        Destroy(chip);
        CurrentChips--;
    }
}
