using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityAction GameStarted;
    public static UnityAction<GateController.SkillTypes,float> OnGetSkill;
}