public class StateMachineData
{
    private float _speed;
    public float Speed
    {
        get => _speed;

        set
        {
            if (value >= 0)
                _speed = value;
        }
    }
}