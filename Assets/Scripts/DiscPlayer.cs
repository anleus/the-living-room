using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscPlayer : MonoBehaviour
{
    public delegate void DiscIntroduced();
    public static event DiscIntroduced OnDiscIntroduced;

    [SerializeField] private Transform cdPosition;

    private void OnTriggerEnter(Collider other)
    {
        if ("CD".Equals(other.name) && other.TryGetComponent<CD>(out CD cd))
        {
            Debug.Log("hola");
            cd.Action();
            StartCoroutine(MoveCD(cd.transform));
        }
    }

    private IEnumerator MoveCD(Transform cd)
    {
        Vector3 startPosition = cdPosition.position;
        Vector3 targetPosition = startPosition + new Vector3(0, 0, 0.5f);
        cd.transform.position = startPosition;

        float journey = 0f;

        while (journey < 1f)
        {
            journey += Time.deltaTime * 0.3f;

            cd.position = Vector3.Lerp(startPosition, targetPosition, journey);

            yield return null;
        }

        cd.position = targetPosition;

        OnDiscIntroduced?.Invoke();
    }
}
