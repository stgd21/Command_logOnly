using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private Command m_Command;
    private Command noCommand = new NoMovement();
    private float time;

    public void SetCommand(Command command, float timeStart)
    {
        m_Command = command;
        time = timeStart;
    }

    public void ExecuteCommand()
    {
        m_Command.Execute();
    }

    public void Clear(string key)
    {
        m_Command = noCommand;
        Debug.Log(key + " held for " + (Time.timeSinceLevelLoad - time) + " seconds");
    }
}
