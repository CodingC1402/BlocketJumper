using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayDash : MonoBehaviour
{
    public GameObject dashEffect;
    public Button fireButton;
    public Button dashButton;
    public GameObject asset;
    public GameObject canon;
    public GameObject player;
    public Rigidbody2D playerRb;
    public SpriteRenderer[] playerSprites;
    public float dashDuration = 0.5f;
    public float dashVerlocity = 20;
    public float afterDashVerlocity = 20;
    public float dashCoolDown = 2;

    private SoundManager soundManager;
    private Vector2 vector = Vector2.zero;
    private bool isDashing = false;
    private bool blockDash = false;
    private float[] rbSetting = new float[4];

    private void Start()
    {
        soundManager = gameObject.GetComponent<SoundManager>();
        dashButton.coolDownTime = dashCoolDown;
    }

    private void Update()
    {
        if (dashButton.isPressed)
        {
            if (blockDash)
                return;

            Dash();
            StartCoroutine(endDash());
            blockDash = true;
        }
        else
        {
            blockDash = false;
        }
    }

    private void Dash()
    {
        if (isDashing)
            return;

        isDashing = true;

        soundManager.PlaySound("DashSound");

        fireButton.IsDisabled = true;
        TurnAllSprite(false);
        player.tag = "None";
        playerRb.velocity = Vector2.zero;

        GameObject effect = Instantiate(dashEffect);
        effect.transform.position = player.transform.position;
        effect.transform.parent = player.transform;

        float assetRotationY = asset.transform.eulerAngles.y;
        Vector3 rotation = canon.transform.eulerAngles;
        if (assetRotationY != 0)
        {
            if (rotation.z >= 180)
            {
                rotation.z -= 360;
                rotation.z %= 360;
            }
            rotation.z = 180 - rotation.z;
        }

        rotation.z %= 360;
        if (rotation.z < 0)
        {
            rotation.z = 360 - rotation.z;
        }
        rotation.z = (int)((rotation.z + 45) / 90f) % 4;

        switch (rotation.z)
        {
            case 0:
                vector.x = 1;
                break;
            case 1:
                vector.y = 1;
                break;
            case 2:
                vector.x = -1;
                break;
            case 3:
                vector.y = -1;
                break;
        }
        playerRb.velocity = new Vector2(vector.x * dashVerlocity, vector.y * dashVerlocity);

        rotation.z = rotation.z * 90;
        rotation.y = 0;
        effect.transform.eulerAngles = rotation;

        rbSetting[0] = playerRb.mass;
        rbSetting[1] = playerRb.drag;
        rbSetting[2] = playerRb.angularDrag;
        rbSetting[3] = playerRb.gravityScale;

        playerRb.mass = 0;
        playerRb.gravityScale = 0;
        playerRb.drag = 0;
        playerRb.angularDrag = 0;
    }

    IEnumerator endDash()
    {
        yield return new WaitForSeconds(dashDuration);

        TurnAllSprite(true);
        player.tag = "Player";

        playerRb.mass = rbSetting[0];
        playerRb.drag = rbSetting[1];
        playerRb.angularDrag = rbSetting[2];
        playerRb.gravityScale = rbSetting[3];

        playerRb.velocity = new Vector2(vector.x * afterDashVerlocity, vector.y * afterDashVerlocity);
        vector = Vector2.zero;

        fireButton.IsDisabled = false;
        isDashing = false;
    }

    public void TurnAllSprite(bool isOn)
    {
        foreach(SpriteRenderer sprite in playerSprites)
        {
            sprite.enabled = isOn;
        }
    }
}
