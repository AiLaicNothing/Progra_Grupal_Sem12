using UnityEngine;
using System;
using UnityEngine.UIElements;
[Serializable]

public class NarrativeNode : GenericNode
{
    [SerializeField] string[] time=new string[]{"Daytime","Golden Hour","Night"};
    [SerializeField] string[] tone = new string[]{"Serious","Relaxed","Upset"};

    [SerializeField] int selectedTime;
    [SerializeField] int selectedTone;
    public string text;
    public string Output()
    {
        return time[selectedTime] +"-"+ tone[selectedTone]+":"+ text;
    }
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort(INPUT_PORT_NAME).Build();
        context.AddOutputPort(OUTPUT_PORT_NAME).Build();
    }
}