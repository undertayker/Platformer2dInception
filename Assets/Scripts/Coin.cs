using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public void Accept(ICollectableVisitor collectableVisitor)
    {
        collectableVisitor.Visit(this); 
    }
}