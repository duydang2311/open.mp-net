using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Natives.PlayerNative;

namespace Omp.Net.Entities;

public partial class BasePlayer : IPlayer
{
	private readonly int id;
	private readonly IntPtr nativeHandle;

	public IntPtr NativeHandle => nativeHandle;
	public int Id => id;

	public BasePlayer(IntPtr nativeHandle, int id)
	{
		this.nativeHandle = nativeHandle;
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

	public int Interior => throw new NotImplementedException();

	public float Health => throw new NotImplementedException();

	public float Armour => throw new NotImplementedException();

	public int Ammo => throw new NotImplementedException();

	public PlayerWeaponState WeaponState => throw new NotImplementedException();

	public IPlayer TargetPlayer => throw new NotImplementedException();

	public int TargetActor => throw new NotImplementedException();

	public int Team => throw new NotImplementedException();

	public int Score => throw new NotImplementedException();

	public int DrunkLevel => throw new NotImplementedException();

	public Color Colour => throw new NotImplementedException();

	public int Skin => throw new NotImplementedException();

	public int Money => throw new NotImplementedException();

	public PlayerState State => throw new NotImplementedException();

	public string Ip => throw new NotImplementedException();

	public uint Ping => throw new NotImplementedException();

	public PlayerWeapon ArmedWeapon => throw new NotImplementedException();

	public uint WantedLevel => throw new NotImplementedException();

	public int FightingStyle => throw new NotImplementedException();

	public Vector3 Velocity => throw new NotImplementedException();

	public int SurfingVehicleID => throw new NotImplementedException();

	public int SurfingObjectID => throw new NotImplementedException();

	public int VehicleID => throw new NotImplementedException();

	public int VehicleSeat => throw new NotImplementedException();

	public uint AnimationIndex => throw new NotImplementedException();

	public PlayerSpecialAction SpecialAction => throw new NotImplementedException();

	public Vector3 CameraPos => throw new NotImplementedException();

	public Vector3 FrontVector => throw new NotImplementedException();

	public byte CameraMode => throw new NotImplementedException();

	public int CameraTargetObject => throw new NotImplementedException();

	public int CameraTargetVehicle => throw new NotImplementedException();

	public int CameraTargetPlayer => throw new NotImplementedException();

	public int CameraTargetActor => throw new NotImplementedException();

	public float CameraAspectRatio => throw new NotImplementedException();

	public float CameraZoom => throw new NotImplementedException();

	public int VirtualWorld => throw new NotImplementedException();

	public KeysData Keys => throw new NotImplementedException();

	public TimeData Time => throw new NotImplementedException();

	public ShotVectorsData LastShotVectors => throw new NotImplementedException();

	public bool Connected => throw new NotImplementedException();

	public bool IsInAnyVehicle => throw new NotImplementedException();

	public bool IsInCheckpoint => throw new NotImplementedException();

	public bool IsInRaceCheckpoint => throw new NotImplementedException();

	public int SetName(string name)
	{
		return Player_SetName(id, name);
	}

	public bool Spawn()
	{
		return Player_Spawn(id);
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

	public bool GetWeaponData(int slot, out WeaponData data)
	{
		throw new NotImplementedException();
	}

	public bool SetSpawnInfo(int team, int skin, Vector3 position, float rotation, int weapon1 = 0, int weapon1_ammo = 0, int weapon2 = 0, int weapon2_ammo = 0, int weapon3 = 0, int weapon3_ammo = 0)
	{
		return Player_SetSpawnInfo(id, team, skin, position.X, position.Y, position.Z, rotation, weapon1, weapon1_ammo, weapon2, weapon2_ammo, weapon3, weapon3_ammo);
	}

	public bool SetPosition(Vector3 position)
	{
		throw new NotImplementedException();
	}

	public bool SetPositionFindZ(Vector3 position)
	{
		throw new NotImplementedException();
	}

	public bool IsStreamedInFor(IPlayer other)
	{
		throw new NotImplementedException();
	}

	public bool SetInterior(uint interiorId)
	{
		throw new NotImplementedException();
	}

	public bool SetHealth(float health)
	{
		throw new NotImplementedException();
	}

	public bool SetArmour(float armour)
	{
		throw new NotImplementedException();
	}

	public bool SetAmmo(PlayerWeapon weapon, int ammo)
	{
		throw new NotImplementedException();
	}

	public bool SetTeam(int teamId)
	{
		throw new NotImplementedException();
	}

	public bool SetScore(int score)
	{
		throw new NotImplementedException();
	}

	public bool SetDrunkLevel(int level)
	{
		throw new NotImplementedException();
	}

	public bool SetColor(Color color)
	{
		throw new NotImplementedException();
	}

	public bool SetSkin(int skinid)
	{
		throw new NotImplementedException();
	}

	public bool GiveWeapon(PlayerWeapon weapon, int ammo)
	{
		throw new NotImplementedException();
	}

	public bool ResetWeapons()
	{
		throw new NotImplementedException();
	}

	public bool SetArmedWeapon(PlayerWeapon weapon)
	{
		throw new NotImplementedException();
	}

	public bool GiveMoney(int money)
	{
		throw new NotImplementedException();
	}

	public bool ResetMoney()
	{
		throw new NotImplementedException();
	}

	public bool SetTime(TimeData data)
	{
		throw new NotImplementedException();
	}

	public bool ToggleClock(bool toggle)
	{
		throw new NotImplementedException();
	}

	public bool SetWeather(int weather)
	{
		throw new NotImplementedException();
	}

	public bool ForceClassSelection()
	{
		throw new NotImplementedException();
	}

	public bool SetWantedLevel(uint level)
	{
		throw new NotImplementedException();
	}

	public bool SetFightingStyle(int style)
	{
		throw new NotImplementedException();
	}

	public bool SetVelocity(Vector3 velocity)
	{
		throw new NotImplementedException();
	}

	public bool PlayCrimeReport(IPlayer suspect, int crime)
	{
		throw new NotImplementedException();
	}

	public bool PlayAudioStream(string url, Vector3 position, float radius = 50, bool usepos = false)
	{
		throw new NotImplementedException();
	}

	public bool StopAudioStream()
	{
		throw new NotImplementedException();
	}

	public bool SetShopName(string shopname)
	{
		throw new NotImplementedException();
	}

	public bool SetSkillLevel(PlayerWeaponSkill skill, int level)
	{
		throw new NotImplementedException();
	}

	public bool RemoveBuilding(int modelid, Vector3 position, float radius)
	{
		throw new NotImplementedException();
	}

	public bool SetAttachedObject(int index, int modelid, int bone, Vector3 offset, Vector3 rotation = default, Vector3? scale = null, Color materialColor1 = default, Color materialColor2 = default)
	{
		throw new NotImplementedException();
	}

	public bool RemoveAttachedObject(int index)
	{
		throw new NotImplementedException();
	}

	public bool IsAttachedObjectSlotUsed(int index)
	{
		throw new NotImplementedException();
	}

	public bool EditAttachedObject(int index)
	{
		throw new NotImplementedException();
	}

	public IPlayerTextDraw CreateTextDraw(Vector2 position, string text)
	{
		throw new NotImplementedException();
	}

	public IPlayerTextDraw CreateTextDraw(Vector2 position, int model)
	{
		throw new NotImplementedException();
	}

	public bool SetChatBubble(string text, int color, float drawDistance, int expireTime)
	{
		throw new NotImplementedException();
	}

	public bool PutInVehicle(int vehicleId, int seatId)
	{
		throw new NotImplementedException();
	}

	public bool RemoveFromVehicle(bool force)
	{
		throw new NotImplementedException();
	}

	public bool ToggleControllable(bool toggle)
	{
		throw new NotImplementedException();
	}

	public bool PlaySound(uint soundId, Vector3 position)
	{
		throw new NotImplementedException();
	}

	public bool ApplyAnimation(string anim_lib, string anim_name, float delta, bool loop, bool lock_x, bool lock_y, bool freeze, int time, int sync_type = 0)
	{
		throw new NotImplementedException();
	}

	public bool ClearAnimations(int sync_type = 0)
	{
		throw new NotImplementedException();
	}

	public bool SetSpecialAction(int actionid)
	{
		throw new NotImplementedException();
	}

	public bool DisableRemoteVehicleCollisions(bool collide)
	{
		throw new NotImplementedException();
	}

	public bool SetCheckpoint(Vector3 position, float radius)
	{
		throw new NotImplementedException();
	}

	public bool DisableCheckpoint()
	{
		throw new NotImplementedException();
	}

	public bool SetRaceCheckpoint(int type, Vector3 position, Vector3 nextPosition, float radius)
	{
		throw new NotImplementedException();
	}

	public bool DisableRaceCheckpoint()
	{
		throw new NotImplementedException();
	}

	public bool SetWorldBounds(float x_max, float x_min, float y_max, float y_min)
	{
		throw new NotImplementedException();
	}

	public bool SetMarkerFor(IPlayer other, int color)
	{
		throw new NotImplementedException();
	}

	public bool ShowNameTagFor(IPlayer other, bool show)
	{
		throw new NotImplementedException();
	}

	public bool SetMapIcon(int iconId, Vector3 position, int markertype, uint color, int style = 0)
	{
		throw new NotImplementedException();
	}

	public bool RemoveMapIcon(int iconId)
	{
		throw new NotImplementedException();
	}

	public bool AllowTeleport(bool allow)
	{
		throw new NotImplementedException();
	}

	public bool SetCameraPos(Vector3 position)
	{
		throw new NotImplementedException();
	}

	public bool SetCameraLookAt(Vector3 position, int cut_type = 0)
	{
		throw new NotImplementedException();
	}

	public bool SetCameraBehind()
	{
		throw new NotImplementedException();
	}

	public bool EnableCameraTarget(bool enable)
	{
		throw new NotImplementedException();
	}

	public bool AttachCameraToObject(int objectId)
	{
		throw new NotImplementedException();
	}

	public bool InterpolateCameraPos(Vector3 fromPosition, Vector3 toPosition, int time, int cut_type = 0)
	{
		throw new NotImplementedException();
	}

	public bool InterpolateCameraLookAt(Vector3 fromPosition, Vector3 toPosition, int time, int cut_type = 0)
	{
		throw new NotImplementedException();
	}

	public bool SetVirtualWorld(int worldId)
	{
		throw new NotImplementedException();
	}

	public bool EnableStuntBonusFor(bool enable)
	{
		throw new NotImplementedException();
	}

	public bool ToggleSpectating(bool toggle)
	{
		throw new NotImplementedException();
	}

	public bool Spectate(IPlayer target, int mode = 1)
	{
		throw new NotImplementedException();
	}

	public bool Spectate(int targetvehicleid, int mode = 1)
	{
		throw new NotImplementedException();
	}

	public bool CreateExplosion(Vector3 position, int type, float radius)
	{
		throw new NotImplementedException();
	}

	public bool IsInVehicle(int vehicleid)
	{
		throw new NotImplementedException();
	}
}
