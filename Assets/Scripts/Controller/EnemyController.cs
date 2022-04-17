using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kryz.Tweening;
using SDD.Events;

public class EnemyController : CharController, IEventHandler
{
    [Tooltip("The final position of enemy")]
    [SerializeField] private Transform m_TransformEnd;
    [Tooltip("If the enemy move or not ?")]
    [SerializeField] private bool m_IsMove;

    private IEnumerator m_MyTranslateCoroutine = null;

    #region Events handlers
    private void OnButtonActivateGOClickedEvent(ButtonActivateGOClickedEvent e)
    {
        if(e.eGameObject != null && e.eGameObject.Equals(this.gameObject))
        {
            this.SetIsMove(true);
        }
    }
    #endregion

    private void SetIsMove(bool isMove)
    {
        this.m_IsMove = isMove;
        OnEnable();
    }

    #region Events suscribtions
    public void SubscribeEvents()
    {
        EventManager.Instance.AddListener<ButtonActivateGOClickedEvent>(OnButtonActivateGOClickedEvent);
    }

    public void UnsubscribeEvents()
    {
        EventManager.Instance.AddListener<ButtonActivateGOClickedEvent>(OnButtonActivateGOClickedEvent);
    }
    #endregion

    #region MonoBehaviour methods
    private void Awake()
    {
        this.m_MyTranslateCoroutine = Tools.MyTranslateCoroutine(base.transform, base.transform.position, this.m_TransformEnd.position, 200, EasingFunctions.Linear, TranslationSpeed);
        this.SubscribeEvents();
    }

    private void OnEnable()
    {
        if (this.m_IsMove) StartCoroutine(this.m_MyTranslateCoroutine);
    }

    private void OnDisable()
    {
        if (this.m_MyTranslateCoroutine != null) StopCoroutine(this.m_MyTranslateCoroutine);
    }

    private void OnDestroy()
    {
        this.UnsubscribeEvents();
    }
    #endregion
}