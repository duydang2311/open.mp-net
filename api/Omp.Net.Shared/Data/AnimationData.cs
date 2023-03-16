using System.Runtime.InteropServices;

namespace Omp.Net.Shared.Data;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct AnimationData
{
	public readonly float Delta { get; init; } ///< The speed to play the animation
	public readonly bool Loop { get; init; } ///< If set to 1, the animation will loop. If set to 0, the animation will play once
	public readonly bool LockX { get; init; } ///< If set to 0, the player is returned to their old X coordinate once the animation is complete (for animations that move the player such as walking). 1 will not return them to their old position
	public readonly bool LockY { get; init; } ///< Same as above but for the Y axis. Should be kept the same as the previous parameter
	public readonly bool Freeze { get; init; } ///< Setting this to 1 will freeze the player at the end of the animation. 0 will not
	public readonly uint Time { get; init; } ///< Timer in milliseconds. For a never-ending loop it should be 0
	public readonly string Lib { get; init; } ///< The animation library of the animation to apply
	public readonly string Name { get; init; } ///< The name of the animation to apply

	public AnimationData()
	{
		Delta = 4.1f;
		Loop = false;
		LockX = false;
		LockY = false;
		Freeze = false;
		Time = 0;
		Lib = string.Empty;
		Name = string.Empty;
	}

	public AnimationData(float delta, bool loop, bool lockX, bool lockY, bool freeze, uint time, string lib, string name)
	{
		Delta = delta;
		Loop = loop;
		LockX = lockX;
		LockY = lockY;
		Freeze = freeze;
		Time = time;
		Lib = lib;
		Name = name;
	}

	public readonly override string ToString()
	{
		return $"({Delta}, {Loop}, {LockX}, {LockY}, {Freeze}, {Time}, {Lib}, {Name})";
	}
}
