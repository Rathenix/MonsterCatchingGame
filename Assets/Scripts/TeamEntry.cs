using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamEntry : MonoBehaviour {
    public Monster Monster;
    
	void Start () {
        transform.FindChild("EntryName").GetComponent<TextMeshProUGUI>().text = Monster.Name;
        transform.FindChild("HPAmount").GetComponent<TextMeshProUGUI>().text = Monster.CurrentHp + "/" + Monster.MaxHp;
        var hpFillAmount = (float)Monster.CurrentHp / (float)Monster.MaxHp;
        Debug.Log("Calculated fill amount = " + hpFillAmount);
        transform.FindChild("HealthBar").GetComponent<Image>().fillAmount = hpFillAmount;
        Debug.Log("HP fill updated. Current value = " + transform.FindChild("HealthBar").GetComponent<Image>().fillAmount);
        var statText = transform.FindChild("Stats").GetComponent<TextMeshProUGUI>().text;
        transform.FindChild("Stats").GetComponent<TextMeshProUGUI>().text = String.Format(statText, Monster.Level, Monster.Attack, Monster.Defense, Monster.Speed);
        GetComponent<Button>().onClick.AddListener(RecoverHealth);
    }
	
    void RecoverHealth()
    {
        Monster.CurrentHp = Monster.MaxHp;
        transform.FindChild("HPAmount").GetComponent<TextMeshProUGUI>().text = Monster.CurrentHp + "/" + Monster.MaxHp;
        StartCoroutine(AnimateRecovery());
        GetComponent<Button>().enabled = false;
    }

    private IEnumerator AnimateRecovery()
    {
        var healthBar = transform.FindChild("HealthBar").GetComponent<Image>();
        var destinationFill = (float)Monster.CurrentHp / (float)Monster.MaxHp;
        float currentTime = 0.0f;
        while (healthBar.fillAmount < destinationFill)
        {
            healthBar.fillAmount += currentTime;
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}
