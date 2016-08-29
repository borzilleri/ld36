using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectActivate : MonoBehaviour, UsableObject
{
    // A multi-purpose script which causes an action to occur when
    // a trigger collider is entered.
    public enum Mode
    {
        Trigger = 0,    // Just broadcast the action on to the target
        Replace = 1,    // replace target with source
        Activate = 2,   // Activate the target GameObject
        Enable = 3,     // Enable a component
        Animate = 4,    // Start animation on target
        Deactivate = 5,  // Decativate target GameObject
        Destroy = 6     // Destroy the target object
    }

    public Mode action = Mode.Activate;         // The action to accomplish
    public Object target;                       // The game object to affect. If none, the trigger work on this game object
    public GameObject source;
    public int triggerCount = 1;
    public bool repeatTrigger = false;

    private void DoActivateTrigger()
    {
        triggerCount--;

        if (triggerCount == 0 || repeatTrigger)
        {
            Object currentTarget = target ?? gameObject;
            Behaviour targetBehaviour = currentTarget as Behaviour;
            GameObject targetGameObject = currentTarget as GameObject;
            if (targetBehaviour != null)
            {
                targetGameObject = targetBehaviour.gameObject;
            }

            switch (action)
            {
                case Mode.Trigger:
                    if (targetGameObject != null)
                    {
                        targetGameObject.BroadcastMessage("DoActivateTrigger");
                    }
                    break;
                case Mode.Replace:
                    if (source != null)
                    {
                        if (targetGameObject != null)
                        {
                            Instantiate(source, targetGameObject.transform.position,
                                        targetGameObject.transform.rotation);
                            DestroyObject(targetGameObject);
                        }
                    }
                    break;
                case Mode.Activate:
                    if (targetGameObject != null)
                    {
                        targetGameObject.SetActive(true);
                    }
                    break;
                case Mode.Enable:
                    if (targetBehaviour != null)
                    {
                        targetBehaviour.enabled = true;
                    }
                    break;
                case Mode.Animate:
                    if (targetGameObject != null)
                    {
                        targetGameObject.GetComponent<Animation>().Play();
                    }
                    break;
                case Mode.Deactivate:
                    if (targetGameObject != null)
                    {
                        targetGameObject.SetActive(false);
                    }
                    break;
                case Mode.Destroy:
                    if (targetGameObject != null)
                    {
                        DestroyObject(targetGameObject);
                    }
                    break;
            }
        }
    }

    public void UseStart(GameObject user)
    {
        Debug.Log(string.Format("{0} used {1}", user.name, this.name));
        DoActivateTrigger();
    }

	public void UseEnd(GameObject user) {
	}

    public void Nearby(GameObject user)
    {
    }

    public string GetTooltip()
    {
        return "My tooltip";
    }
}
