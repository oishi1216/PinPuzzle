using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinSetting : MonoBehaviour
{
    public GameObject pinObj;

    // Start is called before the first frame update
    void Start()
    {
        //�s����EventTrigger��t�^���āA�^�b�v�����Ƃ���OnClickPin�֐����Ăяo���悤�ɐݒ�
        EventTrigger trigger = pinObj.AddComponent<EventTrigger>();
        trigger.triggers = new List<EventTrigger.Entry>();

        trigger = pinObj.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((date) => { PinManager.instance.OnClickPin((PointerEventData)date); });
        trigger.triggers.Add(entry);
    }
}
