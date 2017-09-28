using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureMonster : Monster {

    public CaptureController captureController;
    private bool IsAnimating = false;
    private bool IsCaptured = false;
    Rigidbody2D rb;
    Animator Animator;
    List<Vector2> Positions;
    float teleportTimer = 0f;
    float TeleportRate = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Positions = new List<Vector2>();
        AddAndSetPositions();
    }
    
    private void Update()
    {
        if (!IsAnimating && !IsCaptured)
        {
            TeleportAroundOverTime();
        }
        else if (IsCaptured)
        {
            captureController.MonsterCaptured(this);
        }
    }

    private void AddAndSetPositions()
    {
        Positions.Add(new Vector2(0, 60));
        Positions.Add(new Vector2(-60, 105));
        Positions.Add(new Vector2(55, 105));
        Positions.Add(new Vector2(-45, 15));
        Positions.Add(new Vector2(45, 15));
        Positions.Add(new Vector2(0, -45));
        Positions.Add(new Vector2(-80, -50));
        Positions.Add(new Vector2(85, -50));
        transform.position = Positions[0];
    }

    private void TeleportAroundOverTime()
    {
        teleportTimer += Time.deltaTime;
        if (teleportTimer >= TeleportRate)
        {
            transform.position = Positions[Random.Range(0, 8)];
            teleportTimer = 0;
        }
    }

    private void HitAndCheckIfCaptured()
    {
        StartCoroutine(AnimateHit());
        if (CurrentHp > 1)
        {
            CurrentHp -= 1;
        }
        else
        {
            StartCoroutine(AnimateCapture());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            HitAndCheckIfCaptured();
        }
    }

    private IEnumerator AnimateHit()
    {
        IsAnimating = true;
        Animator.Play("MonsterHit");
        yield return StartCoroutine(ShakeGameObject(gameObject, .2f, .1f));
        Animator.Play("MonsterNormal");
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
        //Animator.Play("Capture");
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
