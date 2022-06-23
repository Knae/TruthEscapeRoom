using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskList : MonoBehaviour
{
	[Header("Tasks")]
	[SerializeField] private TextMeshProUGUI txtTask_Alarm;
	[SerializeField] private TextMeshProUGUI txtTask_Bed;
	[SerializeField] private TextMeshProUGUI txtTask_Breakfast;

	// Update is called once per frame
	void Update()
    {
        if(StaticVariables.bAlarmOff)
		{
			StrikethroughText(txtTask_Alarm);
		}
		
		if(StaticVariables.bMadeBed)
		{
			StrikethroughText(txtTask_Bed);
		}
		
		if(StaticVariables.bHadBreakfast)
		{
			StrikethroughText(txtTask_Breakfast);
		}
    }

    private void StrikethroughText(TextMeshProUGUI _inTargetTextObject)
	{
		string currentText = _inTargetTextObject.text;
		currentText = "<s>" + currentText + "</s>";
		_inTargetTextObject.text = currentText;
	}
}
