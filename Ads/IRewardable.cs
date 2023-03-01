
using UnityEngine.Events;

public interface IRewardable 
{
    UnityAction OnComplite { get; set; }

    Rewards GetRewardType();

}