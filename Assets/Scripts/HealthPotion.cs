using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectable
{
    public void Accept(ICollectableVisitor collectableVisitor)
    {
        collectableVisitor.Visit(this);
    }
}