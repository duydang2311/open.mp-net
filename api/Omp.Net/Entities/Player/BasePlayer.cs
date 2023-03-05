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

	public int Interior => (int)Player_GetInterior(Id);

	public float Health
	{
		get
		{
			unsafe
			{
				float health;
				Player_GetHealth(Id, &health);
				return health;
			}
		}
	}

	public float Armour
	{
		get
		{
			unsafe
			{
				float armour;
				Player_GetArmour(Id, &armour);
				return armour;
			}
		}
	}

	public int Ammo => Player_GetAmmo(Id);

	public PlayerWeaponState WeaponState => (PlayerWeaponState)Player_GetWeaponState(Id);

	public IPlayer TargetPlayer => throw new NotImplementedException();

	public int TargetActor => Player_GetTargetActor(Id);

	public int Team => Player_GetTeam(Id);

	public int Score => Player_GetScore(Id);

	public int DrunkLevel => Player_GetDrunkLevel(Id);

	public Color Colour => Color.FromArgb((int)Player_GetColour(Id));

	public int Skin => Player_GetSkin(Id);

	public int Money => Player_GetMoney(Id);

	public PlayerState State => (PlayerState)Player_GetState(Id);

	public string Ip
	{
		get
		{
			var ptr = Marshal.AllocHGlobal(GameConstants.MaxIpv4Length);
			Player_GetIp(Id, ptr, GameConstants.MaxIpv4Length);
			var ip = Marshal.PtrToStringAnsi(ptr);
			Marshal.FreeHGlobal(ptr);
			return ip!;
		}
	}

	public uint Ping => Player_GetPing(Id);

	public PlayerWeapon ArmedWeapon => (PlayerWeapon)Player_GetArmedWeapon(Id);

	public uint WantedLevel => Player_GetWantedLevel(Id);

	public int FightingStyle => Player_GetFightingStyle(Id);

	public Vector3 Velocity
	{
		get
		{
			unsafe
			{
				float x, y, z;
				Player_GetVelocity(Id, &x, &y, &z);
				return new Vector3(x, y, z);
			}
		}
	}

	public int SurfingVehicleID => Player_GetSurfingVehicleID(Id);

	public int SurfingObjectID => Player_GetSurfingObjectID(Id);

	public int VehicleID => Player_GetVehicleID(Id);

	public int VehicleSeat => Player_GetVehicleSeat(Id);

	public uint AnimationIndex => Player_GetAnimationIndex(Id);

	public PlayerSpecialAction SpecialAction => (PlayerSpecialAction)Player_GetSpecialAction(Id);

	public Vector3 CameraPos
	{
		get
		{
			unsafe
			{
				float x, y, z;
				Player_GetCameraPos(Id, &x, &y, &z);
				return new Vector3(x, y, z);
			}
		}
	}

	public Vector3 FrontVector
	{
		get
		{
			unsafe
			{
				float x, y, z;
				Player_GetCameraFrontVector(Id, &x, &y, &z);
				return new Vector3(x, y, z);
			}
		}
	}

	public byte CameraMode => Player_GetCameraMode(Id);

	public int CameraTargetObject => Player_GetCameraTargetObject(Id);

	public int CameraTargetVehicle => Player_GetCameraTargetVehicle(Id);

	public int CameraTargetPlayer => Player_GetCameraTargetPlayer(Id);

	public int CameraTargetActor => Player_GetCameraTargetActor(Id);

	public float CameraAspectRatio => Player_GetCameraAspectRatio(Id);

	public float CameraZoom => Player_GetCameraZoom(Id);

	public int VirtualWorld => Player_GetVirtualWorld(Id);

	public KeysData Keys
	{
		get
		{
			unsafe
			{
				int keys, updown, leftright;
				Player_GetKeys(Id, &keys, &updown, &leftright);
				return new KeysData((GameKey)keys, (GameKey)updown, (GameKey)leftright);
			}
		}
	}

	public TimeData Time
	{
		get
		{
			unsafe
			{
				int hour, minute;
				Player_GetTime(Id, &hour, &minute);
				return new TimeData(hour, minute);
			}
		}
	}

	public ShotVectorsData LastShotVectors
	{
		get
		{
			unsafe
			{
				float originX, originY, originZ, hitX, hitY, hitZ;
				Player_GetLastShotVectors(Id, &originX, &originY, &originZ, &hitX, &hitY, &hitZ);
				return new ShotVectorsData(originX, originY, originZ, hitX, hitY, hitZ);
			}
		}
	}

	public bool Connected => Player_IsConnected(Id);

	public bool IsInAnyVehicle => Player_IsInAnyVehicle(Id);

	public bool IsInCheckpoint => Player_IsInCheckpoint(Id);

	public bool IsInRaceCheckpoint => Player_IsInRaceCheckpoint(Id);

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

	public bool SetSpawnInfo(int team, int skin, Vector3 position, float rotation, int weapon1 = 0, int ammo1 = 0, int weapon2 = 0, int ammo2 = 0, int weapon3 = 0, int ammo3 = 0)
	{
		return Player_SetSpawnInfo(id, team, skin, position.X, position.Y, position.Z, rotation, weapon1, ammo1, weapon2, ammo2, weapon3, ammo3);
	}

	public bool SetPosition(Vector3 position)
	{
		return Player_SetPosition(Id, position.X, position.Y, position.Z);
	}

	public bool SetPositionFindZ(Vector3 position)
	{
		return Player_SetPositionFindZ(Id, position.X, position.Y, position.Z);
	}

	public bool IsStreamedInFor(IPlayer other)
	{
		return Player_IsStreamedInFor(Id, other.Id);
	}

	public bool SetInterior(uint interiorId)
	{
		return Player_SetInterior(Id, interiorId);
	}

	public bool SetHealth(float health)
	{
		return Player_SetHealth(Id, health);
	}

	public bool SetArmour(float armour)
	{
		return Player_SetArmour(Id, armour);
	}

	public bool SetAmmo(PlayerWeapon weapon, int ammo)
	{
		return Player_SetAmmo(Id, (int)weapon, ammo);
	}

	public bool SetTeam(int teamId)
	{
		return Player_SetTeam(Id, teamId);
	}

	public bool SetScore(int score)
	{
		return Player_SetScore(Id, score);
	}

	public bool SetDrunkLevel(int level)
	{
		return Player_SetDrunkLevel(Id, level);
	}

	public bool SetColor(Color color)
	{
		return Player_SetColor(Id, (uint)color.ToArgb());
	}

	public bool SetSkin(int skinid)
	{
		return Player_SetSkin(Id, skinid);
	}

	public bool GiveWeapon(PlayerWeapon weapon, int ammo)
	{
		return Player_GiveWeapon(Id, (int)weapon, ammo);
	}

	public bool ResetWeapons()
	{
		return Player_ResetWeapons(Id);
	}

	public bool SetArmedWeapon(PlayerWeapon weapon)
	{
		return Player_SetArmedWeapon(Id, (uint)weapon);
	}

	public bool GiveMoney(int money)
	{
		return Player_GiveMoney(Id, money);
	}

	public bool ResetMoney()
	{
		return Player_ResetMoney(Id);
	}

	public bool SetTime(TimeData data)
	{
		return Player_SetTime(Id, data.Hour, data.Minute);
	}

	public bool ToggleClock(bool toggle)
	{
		return Player_ToggleClock(Id, toggle);
	}

	public bool SetWeather(int weather)
	{
		return Player_SetWeather(Id, weather);
	}

	public bool ForceClassSelection()
	{
		return Player_ForceClassSelection(Id);
	}

	public bool SetWantedLevel(uint level)
	{
		return Player_SetWantedLevel(Id, level);
	}

	public bool SetFightingStyle(int style)
	{
		return Player_SetFightingStyle(Id, style);
	}

	public bool SetVelocity(Vector3 velocity)
	{
		return Player_SetVelocity(Id, velocity.X, velocity.Y, velocity.Z);
	}

	public bool PlayCrimeReport(IPlayer suspect, int crime)
	{
		return Player_PlayCrimeReport(Id, suspect.Id, crime);
	}

	public bool PlayAudioStream(string url, Vector3 position, float radius = 50, bool usepos = false)
	{
		return Player_PlayAudioStream(Id, url, position.X, position.Y, position.Z, radius, usepos);
	}

	public bool StopAudioStream()
	{
		return Player_StopAudioStream(Id);
	}

	public bool SetShopName(string shopname)
	{
		return Player_SetShopName(Id, shopname);
	}

	public bool SetSkillLevel(PlayerWeaponSkill skill, int level)
	{
		return Player_SetSkillLevel(Id, (int)skill, level);
	}

	public bool RemoveBuilding(int modelid, Vector3 position, float radius)
	{
		return Player_RemoveBuilding(Id, modelid, position.X, position.Y, position.Z, radius);
	}

	public bool SetAttachedObject(int index, int modelid, int bone, Vector3 offset, Vector3 rotation = default, Vector3? scale = null, Color materialColor1 = default, Color materialColor2 = default)
	{
		scale ??= Vector3.One;
		return Player_SetAttachedObject(Id, index, modelid, bone, offset.X, offset.Y, offset.Z, rotation.X, rotation.Y, rotation.Z, scale.Value.X, scale.Value.Y, scale.Value.Z, materialColor1.ToArgb(), materialColor2.ToArgb());
	}

	public bool RemoveAttachedObject(int index)
	{
		return Player_RemoveAttachedObject(Id, index);
	}

	public bool IsAttachedObjectSlotUsed(int index)
	{
		return Player_IsAttachedObjectSlotUsed(Id, index);
	}

	public bool EditAttachedObject(int index)
	{
		return Player_EditAttachedObject(Id, index);
	}

	public IPlayerTextDraw CreateTextDraw(Vector2 position, string text)
	{
		return Core.Instance.GetTextDrawFactory().Create(this, position, text);
	}

	public IPlayerTextDraw CreateTextDraw(Vector2 position, int model)
	{
		return Core.Instance.GetTextDrawFactory().Create(this, position, model);
	}

	public bool SetChatBubble(string text, int color, float drawDistance, int expireTime)
	{
		return Player_SetChatBubble(Id, text, color, drawDistance, expireTime);
	}

	public bool PutInVehicle(int vehicleId, int seatId)
	{
		return Player_PutInVehicle(Id, vehicleId, seatId);
	}

	public bool RemoveFromVehicle(bool force)
	{
		return Player_RemoveFromVehicle(Id, force);
	}

	public bool ToggleControllable(bool toggle)
	{
		return Player_ToggleControllable(Id, toggle);
	}

	public bool PlaySound(uint soundId, Vector3 position)
	{
		return Player_PlaySound(Id, soundId, position.X, position.Y, position.Z);
	}

	public bool ApplyAnimation(string animLibrary, string animName, float delta, bool loop, bool lockX, bool lockY, bool freeze, int time, PlayerAnimationSyncType syncType = PlayerAnimationSyncType.NoSync)
	{
		return Player_ApplyAnimation(Id, animLibrary, animName, delta, loop, lockX, lockY, freeze, time, (int)syncType);
	}

	public bool ClearAnimations(PlayerAnimationSyncType syncType = PlayerAnimationSyncType.NoSync)
	{
		return Player_ClearAnimations(Id, (int)syncType);
	}

	public bool SetSpecialAction(PlayerSpecialAction action)
	{
		return Player_SetSpecialAction(Id, (int)action);
	}

	public bool DisableRemoteVehicleCollisions(bool collide)
	{
		return Player_DisableRemoteVehicleCollisions(Id, collide);
	}

	public bool SetCheckpoint(Vector3 position, float radius)
	{
		return Player_SetCheckpoint(Id, position.X, position.Y, position.Z, radius);
	}

	public bool DisableCheckpoint()
	{
		return Player_DisableCheckpoint(Id);
	}

	public bool SetRaceCheckpoint(int type, Vector3 position, Vector3 nextPosition, float radius)
	{
		return Player_SetRaceCheckpoint(Id, type, position.X, position.Y, position.Z, nextPosition.X, nextPosition.Y, nextPosition.Z, radius);
	}

	public bool DisableRaceCheckpoint()
	{
		return Player_DisableRaceCheckpoint(Id);
	}

	public bool SetWorldBounds(float maxX, float minX, float maxY, float minY)
	{
		return Player_SetWorldBounds(Id, maxX, minX, maxY, minY);
	}

	public bool SetMarkerFor(IPlayer other, int color)
	{
		return PLayer_SetMarkerFor(Id, other.Id, color);
	}

	public bool ShowNameTagFor(IPlayer other, bool show)
	{
		return Player_ShowNameTagFor(Id, other.Id, show);
	}

	public bool SetMapIcon(int iconId, Vector3 position, int markertype, Color color, MapIconStyle style = MapIconStyle.Local)
	{
		return Player_SetMapIcon(Id, iconId, position.X, position.Y, position.Z, markertype, (uint)color.ToArgb(), (int)style);
	}

	public bool RemoveMapIcon(int iconId)
	{
		return Player_RemoveMapIcon(Id, iconId);
	}

	public bool AllowTeleport(bool allow)
	{
		return Player_AllowTeleport(Id, allow);
	}

	public bool SetCameraPos(Vector3 position)
	{
		return Player_SetCameraPos(Id, position.X, position.Y, position.Z);
	}

	public bool SetCameraLookAt(Vector3 position, PlayerCameraCutType cutType = PlayerCameraCutType.Cut)
	{
		return Player_SetCameraLookAt(Id, position.X, position.Y, position.Z, (int)cutType);
	}

	public bool SetCameraBehind()
	{
		return Player_SetCameraBehind(Id);
	}

	public bool EnableCameraTarget(bool enable)
	{
		return Player_EnableCameraTarget(Id, enable);
	}

	public bool AttachCameraToObject(int objectId)
	{
		return Player_AttachCameraToObject(Id, objectId);
	}

	public bool InterpolateCameraPos(Vector3 fromPosition, Vector3 toPosition, int time, PlayerCameraCutType cutType = PlayerCameraCutType.Cut)
	{
		return Player_InterpolateCameraPos(Id, fromPosition.X, fromPosition.Y, fromPosition.Z, toPosition.X, toPosition.Y, toPosition.Z, time, (int)cutType);
	}

	public bool InterpolateCameraLookAt(Vector3 fromPosition, Vector3 toPosition, int time, PlayerCameraCutType cutType = PlayerCameraCutType.Cut)
	{
		return Player_InterpolateCameraLookAt(Id, fromPosition.X, fromPosition.Y, fromPosition.Z, toPosition.X, toPosition.Y, toPosition.Z, time, (int)cutType);
	}

	public bool SetVirtualWorld(int worldId)
	{
		return Player_SetVirtualWorld(Id, worldId);
	}

	public bool EnableStuntBonus(bool enable)
	{
		return Player_EnableStuntBonus(Id, enable);
	}

	public bool ToggleSpectating(bool toggle)
	{
		return Player_ToggleSpectating(Id, toggle);
	}

	public bool Spectate(IPlayer target, PlayerSpectateMode mode = PlayerSpectateMode.Normal)
	{
		return Player_SpectatePlayer(Id, target.Id, (int)mode);
	}

	public bool Spectate(int targetvehicleid, PlayerSpectateMode mode = PlayerSpectateMode.Normal)
	{
		return Player_SpectateVehicle(Id, targetvehicleid, (int)mode);
	}

	public bool CreateExplosion(Vector3 position, int type, float radius)
	{
		return Player_CreateExplosion(Id, position.X, position.Y, position.Z, type, radius);
	}

	public bool IsInVehicle(int vehicleid)
	{
		return Player_IsInVehicle(Id, vehicleid);
	}
}
