using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public List<Card> heldCards = new List<Card>();

    public Transform minPosition;
    public Transform maxPosition;

    public List<Vector3> cardPositions = new List<Vector3>();

    void Start()
    {
        SetCardPositionsInHand();
    }

    void Update()
    {
        
    }

    public void SetCardPositionsInHand()
    {
        cardPositions.Clear();

        Vector3 distanceBetweenPoints = Vector3.zero;
        if (heldCards.Count > 1)
        {
            distanceBetweenPoints = (maxPosition.position - minPosition.position) / (heldCards.Count - 1);
        }

        for (int i = 0; i < heldCards.Count; i++)
        {
            cardPositions.Add(minPosition.position + (distanceBetweenPoints * i));

            // heldCards[i].transform.position = cardPositions[i];
            // heldCards[i].transform.rotation = minPosition.rotation;

            heldCards[i].MoveToPoint(cardPositions[i], minPosition.rotation);

            heldCards[i].inHand = true;
            heldCards[i].handPosition = i;
        }
    }
}
