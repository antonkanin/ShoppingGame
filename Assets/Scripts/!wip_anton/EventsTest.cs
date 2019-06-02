using System;
using UnityEngine;

public class EnemyPositionChangedEventArgs : EventArgs
{
}

public interface IEnemyModel
{
    event EventHandler<EnemyPositionChangedEventArgs> OnPositionChanged;

    Vector3 Position { get; set; }
}

public class EnemyModel : IEnemyModel
{
    public event EventHandler<EnemyPositionChangedEventArgs> OnPositionChanged = (sender, e) => { };

    private Vector3 position;

    public Vector3 Position
    {
        get { return position; }
        set
        {
            if (position != value)
            {
                position = value;

                var eventArgs = new EnemyPositionChangedEventArgs();
                OnPositionChanged(this, eventArgs);
            }
        }
    }
}

public class EventsTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}