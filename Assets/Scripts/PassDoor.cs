using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerCapsule;

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        checkForPlayer();
    }

    public void checkForPlayer()
    {
        var doorPos1 = GameObject.Find("Door").transform.position;
        var doorPos2 = GameObject.Find("Door (1)").transform.position;
        var doorPos3 = GameObject.Find("Door (2)").transform.position;
        var doorPos4 = GameObject.Find("Door (3)").transform.position;
        var doorPos5 = GameObject.Find("Door (4)").transform.position;
        var doorPos6 = GameObject.Find("Door (5)").transform.position;

        var list = new List<UnityEngine.Vector3> {doorPos1, doorPos2, doorPos3, doorPos4, doorPos5, doorPos6};

        var playerPos = GameObject.Find("Character").transform.position;

        double range = 2;

        for (int i = 1; i < 6; i++)
            if (Vector3.Distance(list[i], playerPos) < range && Input.GetKey("e"))
            {
                PlayerCapsule.transform.LookAt(list[i]);
                StartCoroutine(Teleport(list[i]));
                //Debug.Log(PlayerCapsule);
            }
    }

    IEnumerator Teleport(UnityEngine.Vector3 userInput)
    {
        playerMovement.disabled = true;
        yield return new WaitForSeconds(0.1f);
        PlayerCapsule.transform.position = userInput;
        yield return new WaitForSeconds(0.1f);
        playerMovement.disabled = false;
    }
}
