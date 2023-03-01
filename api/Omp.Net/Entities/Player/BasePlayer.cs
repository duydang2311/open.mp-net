using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared.Data;
using static Omp.Net.CApi.Natives.PlayerNative;

namespace Omp.Net.Entities;

public partial class BasePlayer : IPlayer
{
	private readonly int id;
	public int Id => id;

	public BasePlayer(int id)
	{
		this.id = id;
	}

	public string Name
	{
		get
		{
			var ptr = Marshal.AllocHGlobal(GameConstants.MaxPlayerName);
			Player_GetName(id, ptr, GameConstants.MaxPlayerName);
			var name = Marshal.PtrToStringAnsi(ptr, GameConstants.MaxPlayerName);
			Marshal.FreeHGlobal(ptr);
			return name;
		}
	}

	public Vector3 Position
	{
		get
		{
			unsafe
			{
				float x, y, z;
				Player_GetPosition(id, &x, &y, &z);
				return new Vector3(x, y, z);
			}
		}
	}

	public float FacingAngle
	{
		get
		{
			unsafe
			{
				float angle;
				Player_GetFacingAngle(id, &angle);
				return angle;
			}
		}
	}

	public int SetName(string name)
	{
		return Player_SetName(id, name);
	}

	public bool Spawn()
	{
		return Player_Spawn(id);
	}

	public bool SetSpawnInfo(int team, int skin, float x, float y, float z, float rotation, int weapon1 = 0, int weapon1_ammo = 0, int weapon2 = 0, int weapon2_ammo = 0, int weapon3 = 0, int weapon3_ammo = 0)
	{
		return Player_SetSpawnInfo(id, team, skin, x, y, z, rotation, weapon1, weapon1_ammo, weapon2, weapon2_ammo, weapon3, weapon3_ammo);
	}

	public bool SetPosition(float x, float y, float z)
	{
		return Player_SetPosition(id, x, y, z);
	}

	public bool SetPositionFindZ(float x, float y, float z)
	{
		return Player_SetPositionFindZ(id, x, y, z);
	}

	public bool SetFacingAngle(float angle)
	{
		return Player_SetFacingAngle(id, angle);
	}
}
