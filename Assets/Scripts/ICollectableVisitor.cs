public interface ICollectableVisitor
{
    public void Visit(Coin coin);

    public void Visit(HealthPotion healthPotion);
}