using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerNumbers : MonoBehaviour
{


    public Transform itemSlotContainer;
    public Transform itemSlotTemplate;

    [SerializeField] GameObject playerLobby;


    private void Awake()
    {
        playerLobby.SetActive(true);
        itemSlotContainer = transform.Find("Players Holder");
        itemSlotTemplate = itemSlotContainer.Find("Player");
        playerLobby.SetActive(false);
    }


    public void playerCreate()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        for (int i = 0; i < _UserIdManager.Instance.playerNumber; i++)
        {
            
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
        }

    }
}
