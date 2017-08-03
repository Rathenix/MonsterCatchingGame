using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureMonster : MonoBehaviour {

    public Monster Monster;
    public CaptureController captureController;
    public Sprite defaultSprite;
    public Sprite hitSprite;
    private bool IsAnimating = false;
    private bool IsCaptured = false;
    private float moveTime;
    public float moveDistance = 1f;
    public float moveCooldown = 1f;
    public float restChance = 0f;
    public float restTime = 1f;

    private void Start()
    {
        moveDistance = 1f / Monster.Speed;
        moveCooldown = 1f / Monster.Speed;
        restChance = 100f - ((Monster.CurrentHp / Monster.MaxHp) * 100f);
        restTime = 10 - Monster.Speed;
    }
    private void Update()
    {
        if (!IsAnimating && !IsCaptured)
        {
            MoveRandomly();
            CheckIfCaptured();
        }
        else if (IsCaptured)
        {
            captureController.MonsterCaptured(Monster);
        }
    }

    private void MoveRandomly()
    {
        if (Time.time >= moveTime + moveCooldown)
        {
            var randDirection = Random.Range(0, 4);
            switch (randDirection)
            {
                case 0:
                    if (transform.position.x <= captureController.bottomBounds.x)
                    {
                        transform.position += new Vector3(moveDistance, 0, 0);
                        if (transform.position.x >= captureController.bottomBounds.x)
                        {
                            transform.position = new Vector3(captureController.bottomBounds.x, transform.position.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 1:
                    if (transform.position.x >= captureController.topBounds.x)
                    {
                        transform.position += new Vector3(-moveDistance, 0, 0);
                        if (transform.position.x <= captureController.topBounds.x)
                        {
                            transform.position = new Vector3(captureController.topBounds.x, transform.position.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 2:
                    if (transform.position.y <= captureController.topBounds.y)
                    {
                        transform.position += new Vector3(0, moveDistance, 0);
                        if (transform.position.y >= captureController.topBounds.y)
                        {
                            transform.position = new Vector3(transform.position.x, captureController.topBounds.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
                case 3:
                    if (transform.position.y >= captureController.bottomBounds.y)
                    {
                        transform.position += new Vector3(0, -moveDistance, 0);
                        if (transform.position.y <= captureController.bottomBounds.y)
                        {
                            transform.position = new Vector3(transform.position.x, captureController.bottomBounds.y, transform.position.z);
                        }
                        moveTime = Time.time;
                    }
                    break;
            }
        }
    }

    private void CheckIfCaptured()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var collider = Physics2D.OverlapPoint(mousePosition);
            if (collider)
            {
                StartCoroutine(AnimateHit());
                if (Monster.CurrentHp > 1)
                {
                    Monster.CurrentHp -= 1;
                }
                else
                {
                    StartCoroutine(AnimateCapture());
                }
            }

        }
    }

    private IEnumerator AnimateHit()
    {
        IsAnimating = true;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = hitSprite;
        yield return StartCoroutine(ShakeGameObject(gameObject, .2f, .1f));
        spriteRenderer.sprite = defaultSprite;
        IsAnimating = false;
    }

    private IEnumerator AnimateCapture()
    {
        if (IsAnimating)
        {
            yield return new WaitUntil(() => { return IsAnimating == false; });
        }
        IsAnimating = true;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = hitSprite;
        yield return StartCoroutine(ScaleGameObjectOverTime(gameObject, .5f, 0f));
        IsAnimating = false;
        IsCaptured = true;
    }

    private IEnumerator ShakeGameObject(GameObject objectToShake, float totalShakeDuration, float decreasePoint, bool objectIs2D = true)
    {
        if (decreasePoint >= totalShakeDuration)
        {
            Debug.LogError("decreasePoint must be less than totalShakeDuration...Exiting");
            yield break; //Exit!
        }

        //Get Original Pos and rot
        Transform objTransform = objectToShake.transform;
        Vector3 defaultPos = objTransform.position;
        Quaternion defaultRot = objTransform.rotation;

        float counter = 0f;

        //Shake Speed
        const float speed = 0.1f;

        //Angle Rotation(Optional)
        const float angleRot = 4;

        //Do the actual shaking
        while (counter < totalShakeDuration)
        {
            counter += Time.deltaTime;
            float decreaseSpeed = speed;
            float decreaseAngle = angleRot;

            //Shake GameObject
            if (objectIs2D)
            {
                //Don't Translate the Z Axis if 2D Object
                Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                tempPos.z = defaultPos.z;
                objTransform.position = tempPos;

                //Only Rotate the Z axis if 2D
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(0f, 0f, 1f));
            }
            else
            {
                objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-angleRot, angleRot), new Vector3(1f, 1f, 1f));
            }
            yield return null;


            //Check if we have reached the decreasePoint then start decreasing  decreaseSpeed value
            if (counter >= decreasePoint)
            {
                Debug.Log("Decreasing shake");

                //Reset counter to 0 
                counter = 0f;
                while (counter <= decreasePoint)
                {
                    counter += Time.deltaTime;
                    decreaseSpeed = Mathf.Lerp(speed, 0, counter / decreasePoint);
                    decreaseAngle = Mathf.Lerp(angleRot, 0, counter / decreasePoint);

                    Debug.Log("Decrease Value: " + decreaseSpeed);

                    //Shake GameObject
                    if (objectIs2D)
                    {
                        //Don't Translate the Z Axis if 2D Object
                        Vector3 tempPos = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        tempPos.z = defaultPos.z;
                        objTransform.position = tempPos;

                        //Only Rotate the Z axis if 2D
                        objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(0f, 0f, 1f));
                    }
                    else
                    {
                        objTransform.position = defaultPos + UnityEngine.Random.insideUnitSphere * decreaseSpeed;
                        objTransform.rotation = defaultRot * Quaternion.AngleAxis(UnityEngine.Random.Range(-decreaseAngle, decreaseAngle), new Vector3(1f, 1f, 1f));
                    }
                    yield return null;
                }

                //Break from the outer loop
                break;
            }
        }
        objTransform.position = defaultPos; //Reset to original postion
        objTransform.rotation = defaultRot;//Reset to original rotation

        Debug.Log("Done!");
    }

    private IEnumerator ScaleGameObjectOverTime(GameObject obj, float time, float endScale)
    {
        Vector3 originalScale = obj.transform.localScale;
        Vector3 destinationScale = new Vector3(endScale, endScale);

        float currentTime = 0.0f;
        do
        {
            obj.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
}
