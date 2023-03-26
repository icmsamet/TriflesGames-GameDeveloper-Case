using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using GG.Infrastructure.Utils.Swipe;

public class ToiletPaperMovement
{
    private Transform m_transform;
    private Vector2 m_clamp;
    public ToiletPaperMovement(Transform _transform,Vector2 _clamp)
    {
        m_transform = _transform;
        m_clamp = _clamp;
    }
    public void Move(string id, UnityAction<bool> startAction)
    {
        m_transform.rotation = Quaternion.Euler(Vector3.zero);
        switch (id)
        {
            case DirectionId.ID_UP:
                m_transform.DORotate(new Vector3(360, 0, 0), .5f, RotateMode.LocalAxisAdd)
                .OnStart(() =>
                {
                    startAction.Invoke(true);
                });
                break;
            case DirectionId.ID_LEFT:
                m_transform.DORotate(new Vector3(0, 0, 360), .5f, RotateMode.LocalAxisAdd)
                .OnStart(() =>
                {
                    startAction.Invoke(true);
                });
                break;
            case DirectionId.ID_UP_LEFT:
                m_transform.DORotate(new Vector3(0, 0, 360), .5f, RotateMode.LocalAxisAdd)
                .OnStart(() =>
                {
                    startAction.Invoke(true);
                });
                break;

            case DirectionId.ID_RIGHT:
                m_transform.DORotate(new Vector3(0, 0, 360), .5f, RotateMode.LocalAxisAdd)
                .OnStart(() =>
                {
                    startAction.Invoke(true);
                });
                break;
            case DirectionId.ID_UP_RIGHT:
                m_transform.DORotate(new Vector3(0, 0, 360), .5f, RotateMode.LocalAxisAdd)
                .OnStart(() =>
                {
                    startAction.Invoke(true);
                });
                break;
        }
    }
    public void Clamp()
    {
        Vector3 currentLocalPos = m_transform.localPosition;

        currentLocalPos.x = Mathf.Clamp(currentLocalPos.x, -m_clamp.x, m_clamp.x);
        currentLocalPos.y = Mathf.Clamp(currentLocalPos.y, -m_clamp.y, m_clamp.y);
        currentLocalPos.z = Mathf.Clamp(currentLocalPos.z, -1, -1);

        m_transform.localPosition = currentLocalPos;
    }
    public Quaternion LocalRotation
    {
        get { return m_transform.localRotation; }
        set { m_transform.localRotation = value; }
    }
}
