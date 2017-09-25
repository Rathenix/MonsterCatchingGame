using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureChip : MonoBehaviour {

    public CaptureController Controller;
    public Transform PlusOne;
    public bool Collected = false;
    float disappearTimer = 0f;
    float disappearSeconds = 5;

    private void Start()
    {
        PlusOne = transform.FindChild("PlusOne");
    }

    private void Update()
    {
        disappearTimer += Time.deltaTime;
        if (disappearTimer >= disappearSeconds)
        {
            Controller.DestroyChip(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            OnChipCollision();
        }
    }

    void OnChipCollision()
    {
        if (!Collected)
        {
            Collected = true;
            Controller.ChipCollected();
            StartCoroutine(GetChip());
        }
    }

    IEnumerator GetChip()
    {
        //transform.position += new Vector3(0, 2, 0);
        var counter = 0f;
        while (counter < .5)
        {
            counter += Time.deltaTime;
            transform.Rotate(Vector3.up * 10);
            yield return null;
        }
        counter = 0;
        transform.rotation = new Quaternion();
        GetComponent<Renderer>().enabled = false;
        PlusOne.gameObject.SetActive(true);
        var mat = PlusOne.GetComponent<Renderer>().material;
        var color = mat.color;
        while (counter < color.a)
        {
            counter += Time.deltaTime;
            mat.color = new Color(color.r, color.g, color.b, color.a - counter);
            yield return null;
        }
        Controller.DestroyChip(gameObject);
    }
}
