using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class ObjectWillEarnThings : MonoBehaviour
{
    [Header("ObjectWillGainScore behaviour")]
    [Tooltip("ObjectWillGainScore audio clip")]
    [SerializeField] private AudioClip m_ObjectInteractionSfxClip;

    /// <summary>
    /// OnInteractionWithTheObject we gain score and send <see cref="PlaySFXEvent"/>
    /// </summary>
    protected virtual void OnInteractionWithTheObject()
    {
        EventManager.Instance.Raise(new PlaySFXEvent() { eAudioClip = this.m_ObjectInteractionSfxClip });
        
    }

    /// <summary>
    /// OnInteractionWithTheObjectEarnScore we gain score <see cref="ObjectWillGainScoreEvent"/> and call <seealso cref="OnInteractionWithTheObject"/>
    /// </summary>
    /// <param name="gameObject"></param>
    protected virtual void OnInteractionWithTheObjectEarnScore(GameObject gameObject)
    {
        this.OnInteractionWithTheObject();
        EventManager.Instance.Raise(new ObjectWillGainScoreEvent() { eThisGameObject = this.gameObject, eOtherGO = gameObject });
    }

    /// <summary>
    /// OnInteractionWithTheObjectEarnTime we gain time <see cref="ObjectWillGainTimeEvent"/> and call <seealso cref="OnInteractionWithTheObject"/>
    /// </summary>
    /// <param name="gameObject"></param>
    protected virtual void OnInteractionWithTheObjectEarnTime(GameObject gameObject)
    {
        this.OnInteractionWithTheObject();
        EventManager.Instance.Raise(new ObjectWillGainTimeEvent() { eThisGameObject = this.gameObject, eOtherGO = gameObject });
    }
}
