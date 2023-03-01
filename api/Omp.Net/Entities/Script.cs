using Omp.Net.CApi.Events;
using static Omp.Net.CApi.Events.NativeScriptEvent;

namespace Omp.Net.Entities;

public class Script
{
	public event ScriptStartDelegate? OnStart
	{
		add
		{
			NativeScriptStartEvent += value;
		}
		remove
		{
			NativeScriptStartEvent -= value;
		}
	}
}
