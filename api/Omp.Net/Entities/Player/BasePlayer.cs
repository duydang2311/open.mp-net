using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Natives.PlayerNative;

namespace Omp.Net.Entities;

public class BasePlayer : BaseEntity, IPlayer
{
	private readonly object mutex = new();
	private ITextDrawPool? textDrawPool;

	public BasePlayer(IntPtr nativeHandle, int id) : base(nativeHandle, id) { }

	public bool IsBot => Player_IsBot(NativeHandle);

	public IEnumerable<IPlayerTextDraw> TextDraws
	{
		get
		{
			if (textDrawPool is null)
			{
				return Array.Empty<IPlayerTextDraw>();
			}
			return GetTextDrawPool().GetAll().Cast<IPlayerTextDraw>();
		}
	}

	public bool UseGhostMode { get => Player_IsGhostModeEnabled(NativeHandle); set => Player_ToggleGhostMode(NativeHandle, value); }

	public bool IsUsingOfficialClient => Player_IsUsingOfficialClient(NativeHandle);

	public bool AllowWeapons
	{
		get => Player_AreWeaponsAllowed(NativeHandle);
		set => Player_AllowWeapons(NativeHandle, value);
	}

	public bool AllowTeleport
	{
		get => Player_IsTeleportAllowed(NativeHandle);
		set => Player_AllowTeleport(NativeHandle, value);
	}

	public bool UseClock
	{
		get => Player_HasClock(NativeHandle);
		set => Player_UseClock(NativeHandle, value);
	}

	public bool UseWidescreen
	{
		get => Player_HasWidescreen(NativeHandle);
		set => Player_UseWidescreen(NativeHandle, value);
	}

	public bool UseStuntBonuses { set => Player_UseStuntBonuses(NativeHandle, value); }

	public bool UseCameraTargeting
	{
		get => Player_HasCameraTargeting(NativeHandle);
		set => Player_UseCameraTargeting(NativeHandle, value);
	}

	public PeerNetworkData NetworkData => Player_GetNetworkData(NativeHandle);

	public uint Ping => Player_GetPing(NativeHandle);

	public ClientVersion ClientVersion => Player_GetClientVersion(NativeHandle);

	public string ClientVersionName => Marshal.PtrToStringAnsi(Player_GetClientVersionName(NativeHandle)) ?? string.Empty;

	public Vector3 CameraPosition
	{
		get => Player_GetCameraPosition(NativeHandle);
		set => Player_SetCameraPosition(NativeHandle, value);
	}

	public Vector3 CameraLookAt => Player_GetCameraLookAt(NativeHandle);

	public string Name => Marshal.PtrToStringAnsi(Player_GetName(NativeHandle)) ?? string.Empty;

	public string Serial => Marshal.PtrToStringAnsi(Player_GetSerial(NativeHandle)) ?? string.Empty;

	public IReadOnlyCollection<WeaponSlotData> Weapons
	{
		get
		{
			unsafe
			{
				var slots = new WeaponSlotData[GameConstants.MaxWeaponSlots];
				var ptr = Player_GetWeapons(NativeHandle);
				for (var i = 0; i != GameConstants.MaxWeaponSlots; ++i)
				{
					slots[i] = (WeaponSlotData)Marshal.PtrToStructure(IntPtr.Add(ptr, i * sizeof(WeaponSlotData)), typeof(WeaponSlotData))!;
				}
				return slots;
			}
		}
	}

	public PlayerWeapon ArmedWeapon { get => (PlayerWeapon)Player_GetArmedWeapon(NativeHandle); set => Player_SetArmedWeapon(NativeHandle, (uint)value); }

	public uint ArmedWeaponAmmo => Player_GetArmedWeaponAmmo(NativeHandle);

	public string ShopName
	{
		get => Marshal.PtrToStringAnsi(Player_GetShopName(NativeHandle)) ?? string.Empty;
		set => Player_SetShopName(NativeHandle, value);
	}
	public int DrunkLevel
	{
		get => Player_GetDrunkLevel(NativeHandle);
		set => Player_SetDrunkLevel(NativeHandle, value);
	}

	public Color Color
	{
		get => Color.FromArgb((int)Player_GetColour(NativeHandle));
		set => Player_SetColour(NativeHandle, (uint)value.ToArgb());
	}

	public bool Controllable
	{
		get => Player_GetControllable(NativeHandle);
		set => Player_SetControllable(NativeHandle, value);
	}

	public uint WantedLevel
	{
		get => Player_GetWantedLevel(NativeHandle);
		set => Player_SetWantedLevel(NativeHandle, value);
	}

	public int Money
	{
		get => Player_GetMoney(NativeHandle);
		set => Player_SetMoney(NativeHandle, value);
	}

	public TimeData Time
	{
		get
		{
			unsafe
			{
				long hr, min;
				Player_GetTime(NativeHandle, &hr, &min);
				return new TimeData(hr, min);
			}
		}
		set => Player_SetTime(NativeHandle, value.Hour, value.Minute);
	}

	public float Health
	{
		get => Player_GetHealth(NativeHandle);
		set => Player_SetHealth(NativeHandle, value);
	}

	public int Score
	{
		get => Player_GetScore(NativeHandle);
		set => Player_SetScore(NativeHandle, value);
	}

	public float Armour
	{
		get => Player_GetArmour(NativeHandle);
		set => Player_SetArmour(NativeHandle, value);
	}

	public float Gravity
	{
		get => Player_GetGravity(NativeHandle);
		set => Player_SetGravity(NativeHandle, value);
	}



	public PlayerAnimationData AnimationData => Player_GetAnimationData(NativeHandle);

	public PlayerSurfingData SurfingData => Player_GetSurfingData(NativeHandle);

	public PlayerState State => Player_GetState(NativeHandle);

	public int Team { get => Player_GetTeam(NativeHandle); set => Player_SetTeam(NativeHandle, value); }

	public int Skin => Player_GetSkin(NativeHandle);

	public int Weather
	{
		get => Player_GetWeather(NativeHandle);
		set => Player_SetWeather(NativeHandle, value);
	}

	public Vector4 WorldBounds
	{
		get => Player_GetWorldBounds(NativeHandle);
		set => Player_SetWorldBounds(NativeHandle, value);
	}

	public PlayerFightingStyle FightingStyle
	{
		get => Player_GetFightingStyle(NativeHandle);
		set => Player_SetFightingStyle(NativeHandle, value);
	}

	public PlayerSpecialAction Action
	{
		get => Player_GetAction(NativeHandle);
		set => Player_SetAction(NativeHandle, value);
	}

	public Vector3 Velocity
	{
		get => Player_GetVelocity(NativeHandle);
		set => Player_SetVelocity(NativeHandle, value);
	}

	public uint Interior
	{
		get => Player_GetInterior(NativeHandle);
		set => Player_SetInterior(NativeHandle, value);
	}


	public PlayerKeyData KeyData => Player_GetKeyData(NativeHandle);

	public IReadOnlyCollection<ushort> SkillLevels
	{
		get
		{
			unsafe
			{
				var levels = new ushort[GameConstants.NumSkillLevels];
				var ptr = Player_GetSkillLevels(NativeHandle);
				for (var i = 0; i != GameConstants.NumSkillLevels; ++i)
				{
					levels[i] = (ushort)Marshal.ReadIntPtr(ptr, i * sizeof(ushort)).ToInt32();
				}
				return levels;
			}
		}
	}

	public PlayerAimData AimData => Player_GetAimData(NativeHandle);

	public PlayerBulletData BulletData => Player_GetBulletData(NativeHandle);

	public IPlayer CameraTargetPlayer => throw new NotImplementedException(); // TODO: use entity pool

	public IntPtr CameraTargetVehicle => Player_GetCameraTargetVehicle(NativeHandle);

	public IntPtr CameraTargetObject => Player_GetCameraTargetObject(NativeHandle);

	public IntPtr CameraTargetActor => Player_GetCameraTargetActor(NativeHandle);

	public IPlayer TargetPlayer => throw new NotImplementedException(); // TODO: use entity pool

	public IntPtr TargetActor => Player_GetTargetActor(NativeHandle);

	public PlayerSpectateData SpectateData => Player_GetSpectateData(NativeHandle);

	public int DefaultObjectsRemoved => Player_GetDefaultObjectsRemoved(NativeHandle);

	public bool KickStatus => Player_GetKickStatus(NativeHandle);

	public void ApplyAnimation(AnimationData animation, PlayerAnimationSyncType syncType = PlayerAnimationSyncType.NoSync)
	{
		Player_ApplyAnimation(NativeHandle, animation, syncType);
	}

	public void AttachCameraToObject(IntPtr obj)
	{
		Player_AttachCameraToObject(NativeHandle, obj);
	}

	public void AttachCameraToPlayerObject(IntPtr playerObject)
	{
		Player_AttachCameraToPlayerObject(NativeHandle, playerObject);
	}

	public void Ban(string reason = "")
	{
		Player_Ban(NativeHandle, reason);
	}

	public void BroadcastPacketToStreamed(Span<byte> data, int channel, bool skipFrom = true)
	{
		// properly won't work
		Player_BroadcastPacketToStreamed(NativeHandle, data, channel, skipFrom);
	}

	public void BroadcastRPCToStreamed(int id, Span<byte> data, int channel, bool skipFrom = false)
	{
		// properly won't work
		Player_BroadcastRPCToStreamed(NativeHandle, id, data, channel, skipFrom);
	}

	public void BroadcastSyncPacket(Span<byte> data, int channel)
	{
		// properly won't work
		Player_BroadcastSyncPacket(NativeHandle, data, channel);
	}

	public void ClearAnimations(PlayerAnimationSyncType syncType = PlayerAnimationSyncType.NoSync)
	{
		Player_ClearAnimations(NativeHandle, syncType);
	}

	public void ClearTasks(PlayerAnimationSyncType syncType = PlayerAnimationSyncType.NoSync)
	{
		Player_ClearTasks(NativeHandle, syncType);
	}

	public void CreateExplosion(Vector3 position, int type, float radius)
	{
		Player_CreateExplosion(NativeHandle, position, type, radius);
	}

	public void ForceClassSelection()
	{
		Player_ForceClassSelection(NativeHandle);
	}

	public string GetGameText(int style, out long timeMs, out long remainingMs)
	{
		unsafe
		{
			long timeMs_, remainingMs_;
			var ptr = Player_GetGameText(NativeHandle, style, &timeMs_, &remainingMs_);
			timeMs = timeMs_;
			remainingMs = remainingMs_;
			return Marshal.PtrToStringAnsi(ptr) ?? string.Empty;
		}
	}

	public bool GetOtherColour(IntPtr other, out Color color)
	{
		unsafe
		{
			uint argb;
			var ret = Player_GetOtherColour(NativeHandle, other, &argb);
			color = Color.FromArgb((int)argb);
			return ret;
		}
	}

	public IReadOnlyCollection<IPlayer> GetStreamedPlayers()
	{
		var ptr = Marshal.AllocHGlobal(4);
		var length = Player_GetStreamedPlayers(NativeHandle, ptr);
		var streamedPlayers = new IPlayer[length];
		for (var i = 0; i != length; ++i)
		{
			streamedPlayers[i] = Core.Instance.PlayerPool.Get(Marshal.ReadIntPtr(ptr, i * 4));
		}
		Marshal.FreeHGlobal(ptr);
		return streamedPlayers;
	}

	public WeaponSlotData GetWeaponSlot(int slot)
	{
		return Player_GetWeaponSlot(NativeHandle, slot);
	}

	public void GiveMoney(int money)
	{
		Player_GiveMoney(NativeHandle, money);
	}

	public void GiveWeapon(WeaponSlotData weapon)
	{
		Player_GiveWeapon(NativeHandle, weapon);
	}

	public bool HasGameText(int style)
	{
		return Player_HasGameText(NativeHandle, style);
	}

	public void HideGameText(int style)
	{
		Player_HideGameText(NativeHandle, style);
	}

	public void InterpolateCameraLookAt(Vector3 from, Vector3 to, int time, PlayerCameraCutType cutType = PlayerCameraCutType.Cut)
	{
		Player_InterpolateCameraLookAt(NativeHandle, from, to, time, cutType);
	}

	public void InterpolateCameraPosition(Vector3 from, Vector3 to, int time, PlayerCameraCutType cutType = PlayerCameraCutType.Cut)
	{
		Player_InterpolateCameraPosition(NativeHandle, from, to, time, cutType);
	}

	public bool IsStreamedInFor(IPlayer other)
	{
		return Player_IsStreamedInForPlayer(NativeHandle, other.NativeHandle);
	}

	public void Kick()
	{
		Player_Kick(NativeHandle);
	}

	public string LastPlayedAudio()
	{
		return Marshal.PtrToStringAnsi(Player_LastPlayedAudio(NativeHandle)) ?? string.Empty;
	}

	public uint LastPlayedSound()
	{
		return Player_LastPlayedSound(NativeHandle);
	}

	public void PlayAudio(string url)
	{
		Player_PlayAudio(NativeHandle, url, false, Vector3.Zero, 0);
	}

	public void PlayAudio(string url, Vector3 pos, float distance)
	{
		Player_PlayAudio(NativeHandle, url, true, pos, distance);
	}

	public bool PlayerCrimeReport(IPlayer suspect, int crime)
	{
		return Player_PlayerCrimeReport(NativeHandle, suspect.NativeHandle, crime);
	}

	public void PlaySound(uint sound, Vector3 pos)
	{
		Player_PlaySound(NativeHandle, sound, pos);
	}

	public void RemoveDefaultObjects(uint model, Vector3 pos, float radius)
	{
		Player_RemoveDefaultObjects(NativeHandle, model, pos, radius);
	}

	public void RemoveFromVehicle(bool force)
	{
		Player_RemoveFromVehicle(NativeHandle, force);
	}

	public void RemoveWeapon(PlayerWeapon weapon)
	{
		Player_RemoveWeapon(NativeHandle, (byte)weapon);
	}

	public void ResetMoney()
	{
		Player_ResetMoney(NativeHandle);
	}

	public void ResetWeapons()
	{
		Player_ResetWeapons(NativeHandle);
	}

	public void SendChatMessage(IPlayer sender, string message)
	{
		Player_SendChatMessage(NativeHandle, sender.NativeHandle, message);
	}

	public void SendClientCheck(int actionType, int address, int offset, int count)
	{
		Player_SendClientCheck(NativeHandle, actionType, address, offset, count);
	}

	public void SendClientMessage(Color color, string message)
	{
		Player_SendClientMessage(NativeHandle, (uint)color.ToArgb(), message);
	}

	public void SendCommand(string message)
	{
		Player_SendCommand(NativeHandle, message);
	}

	public void SendDeathMessage(IPlayer killed, IPlayer? killer, PlayerWeapon weapon)
	{
		Player_SendDeathMessage(NativeHandle, killed.NativeHandle, killer?.NativeHandle ?? IntPtr.Zero, (int)weapon);
	}

	public void SendEmptyDeathMessage()
	{
		Player_SendEmptyDeathMessage(NativeHandle);
	}

	public void SendGameText(string message, long timeMs, int style)
	{
		Player_SendGameText(NativeHandle, message, timeMs, style);
	}

	public bool SendPacket(Span<byte> data, int channel, bool dispatchEvents = true)
	{
		// propertly won't work
		return Player_SendPacket(NativeHandle, data, channel, dispatchEvents);
	}

	public bool SendRPC(int id, Span<byte> data, int channel, bool dispatchEvents = true)
	{
		// propertly won't work
		return Player_SendRPC(NativeHandle, id, data, channel, dispatchEvents);
	}

	public void SetCameraBehind()
	{
		Player_SetCameraBehind(NativeHandle);
	}

	public void SetCameraLookAt(Vector3 pos, PlayerCameraCutType cutType = PlayerCameraCutType.Cut)
	{
		Player_SetCameraLookAt(NativeHandle, pos, cutType);
	}

	public void SetChatBubble(string text, Color color, float drawDist, long expireMs)
	{
		Player_SetChatBubble(NativeHandle, text, (uint)color.ToArgb(), drawDist, expireMs);
	}

	public void SetMapIcon(int id, Vector3 pos, int type, Color color, MapIconStyle style)
	{
		Player_SetMapIcon(NativeHandle, id, pos, type, (uint)color.ToArgb(), style);
	}

	public PlayerNameStatus SetName(string name)
	{
		return Player_SetName(NativeHandle, name);
	}

	public void SetOtherColour(IPlayer other, Color color)
	{
		Player_SetOtherColour(NativeHandle, other.NativeHandle, (uint)color.ToArgb());
	}

	public void SetPositionFindZ(Vector3 pos)
	{
		Player_SetPositionFindZ(NativeHandle, pos);
	}

	public void SetRemoteVehicleCollisions(bool collide)
	{
		Player_SetRemoteVehicleCollisions(NativeHandle, collide);
	}

	public void SetSkillLevel(PlayerWeaponSkill skill, int level)
	{
		Player_SetSkillLevel(NativeHandle, skill, level);
	}

	public void SetSkin(int skin, bool send = true)
	{
		Player_SetSkin(NativeHandle, skin, send);
	}

	public void SetSpectating(bool spectating)
	{
		Player_SetSpectating(NativeHandle, spectating);
	}

	public void SetTransform(Vector3 vec3)
	{
		Player_SetTransform(NativeHandle, vec3);
	}

	public void SetWeaponAmmo(WeaponSlotData data)
	{
		Player_SetWeaponAmmo(NativeHandle, data);
	}

	public void SetWorldTime(long time)
	{
		Player_SetWorldTime(NativeHandle, time);
	}

	public void Spawn()
	{
		Player_Spawn(NativeHandle);
	}

	public void SpectatePlayer(IPlayer target, PlayerSpectateMode mode)
	{
		Player_SpectatePlayer(NativeHandle, target.NativeHandle, mode);
	}

	public void SpectateVehicle(IntPtr target, PlayerSpectateMode mode)
	{
		Player_SpectateVehicle(NativeHandle, target, mode);
	}

	public void StopAudio()
	{
		Player_StopAudio(NativeHandle);
	}

	public void StreamInForPlayer(IPlayer other)
	{
		Player_StreamInForPlayer(NativeHandle, other.NativeHandle);
	}

	public void StreamOutForPlayer(IPlayer other)
	{
		Player_StreamOutForPlayer(NativeHandle, other.NativeHandle);
	}

	public void ToggleOtherNameTag(IPlayer other, bool toggle)
	{
		Player_ToggleOtherNameTag(NativeHandle, other.NativeHandle, toggle);
	}

	public void UnsetMapIcon(int id)
	{
		Player_UnsetMapIcon(NativeHandle, id);
	}

	public IPlayerTextDraw Create(Vector2 position, string text)
	{
		return (IPlayerTextDraw)GetTextDrawPool().Create(position, text);
	}

	public IPlayerTextDraw Create(Vector2 position, int model)
	{
		return (IPlayerTextDraw)GetTextDrawPool().Create(position, model);
	}

	private ITextDrawPool GetTextDrawPool()
	{
		lock (mutex)
		{
			textDrawPool ??= new TextDrawPool(Core.Instance.GetPlayerTextDrawFactory(this));
			return textDrawPool;
		}
	}
}
