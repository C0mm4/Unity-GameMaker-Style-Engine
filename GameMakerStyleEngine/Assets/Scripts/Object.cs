using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.UI;
using UnityEngine;

// Custom Mono Behaviour Class
// extend Object class for new Mono Behaviour Class
// Override the virtual methods of the Object class for custom functionality
public abstract class Object : MonoBehaviour
{
    public delegate void Alarm();
    public Alarm[] alarms;
    public bool[] isAlarmRun;

    // Start is called before the first frame update
    public void Awake()
    {
        alarms = new Alarm[]
        {
            Alarm0, Alarm1, Alarm2, Alarm3, Alarm4, Alarm5, Alarm6, Alarm7, Alarm8, Alarm9
        };

        isAlarmRun = new bool[alarms.Length];
        OnCreate();
    }

    // Update is called once per frame
    // Objects inheriting from the Object class do not declare the Update method.
    void Update()
    {
        BeforeStep();
        KeyInput();
        Step();
        AfterStep();
    }

    public virtual void OnCreate()
    {
        // Custom code to execute during object creation
    }

    // In each frame (On Update), the following steps are executed in order: BeforeStep > KeyInput > Step > AfterStep
    // Override the code to be used in this section.

    public virtual void BeforeStep()
    {
        // Add your code for Before Step here
    }

    public virtual void Step()
    {
        // Add your code for Step here
    }

    public virtual void AfterStep()
    {
        // Add your code for After Step here
    }

    public virtual void KeyInput()
    {
        // Describe the behavior of keyboard input here
    }

    // Execute the alarm at index 'index' after the specified 'time'.
    // No additional access is possible during the execution of the alarm.
    public void SetAlarm(int index, float time = 0)
    {
        if(time == 0)
        {
            alarms[1].Invoke();
        }
        else if (!isAlarmRun[index]) 
        {
            isAlarmRun[index] = true;

            Task.Run(async () =>
            {
                await Task.Delay((int)(time * 1000));
                alarms[index].Invoke();
                isAlarmRun[index] = false;
            });
        }
    }

    public abstract void Alarm0();
    public abstract void Alarm1();
    public abstract void Alarm2();
    public abstract void Alarm3();
    public abstract void Alarm4();
    public abstract void Alarm5();
    public abstract void Alarm6();
    public abstract void Alarm7();
    public abstract void Alarm8();
    public abstract void Alarm9(); 
}
