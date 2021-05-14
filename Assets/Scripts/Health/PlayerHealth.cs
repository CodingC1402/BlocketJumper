using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public CheckPointCollection checkPointCollection;
    public ControllerMenu controller;
    public Heath health;
    public Rigidbody2D playerRb;
    public Button fireButton;
    public Button dashButton;
    public GameObject explosionEffect;
    public float delayBeforeExplosion = 0.1f;

    private Vector3 velocity;
    private Vector3 currentPos;
    private bool isMoving = false;
    private bool isDamaged = false;
    private bool isStopUpdate = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("SettingHealth to dif");
        health.healthBar.SetMaxHealth(Difficulty.GetHealthFromValue());
        health.health = Difficulty.GetHealthFromValue();
    }

    private void Update()
    {
        if (isStopUpdate)
            return;

        if (isMoving)
        {
            currentPos += velocity * Time.deltaTime;
            gameObject.transform.position = currentPos;
            return;
        }
        if (health.isDead)
        {
            controller.Lose();
            isStopUpdate = true;
            return;
        }
        if (health.isImmune)
        {
            if (!isDamaged)
            {
                playerRb.bodyType = RigidbodyType2D.Static;
                gameObject.GetComponent<PlayDash>().TurnAllSprite(false);
                StartCoroutine(spawnInExplosion());
                currentPos = gameObject.transform.position;
                velocity = (checkPointCollection.getCheckPointPosition() - currentPos) / delayBeforeExplosion;
                isMoving = true;

                fireButton.IsDisabled = true;
                dashButton.IsDisabled = true;
                isDamaged = true;
            }
        }
        else
        {
            isDamaged = false;
        }    
    }

    IEnumerator spawnInExplosion()
    {
        yield return new WaitForSeconds(delayBeforeExplosion);
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        playerRb.transform.position = checkPointCollection.getCheckPointPosition();

        GameObject effect = Instantiate(explosionEffect);
        effect.transform.position = gameObject.transform.position;

        gameObject.GetComponent<PlayDash>().TurnAllSprite(true);

        isMoving = false;
        yield return new WaitForSeconds(0.5f);
        fireButton.IsDisabled = false;
        dashButton.IsDisabled = false;
    }
}
