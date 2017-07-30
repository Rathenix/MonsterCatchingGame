using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour {

    public GoogleMap mainMap;
    public GameObject player;
    public MonsterInteractionsMenu monsterInteractionsMenu;

    public MonsterInteractionsMenu ShowMonsterInteractionsMenu(GameObject target)
    {
        return Instantiate(monsterInteractionsMenu, target.transform.position, new Quaternion(), transform.GetComponentInParent<Canvas>().transform);
    }
}
