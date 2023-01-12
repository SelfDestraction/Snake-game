public class Blockint : BlockEater
{
    private int _progress;
    protected override void ChangeHP(Ihealth health)
    {
        _progress++;
        HealthUpdate(Health - _progress);


        if (_progress >= Health)
        {
            Destroy(gameObject);
        }
    }
}
