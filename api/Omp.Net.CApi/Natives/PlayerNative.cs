using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;

namespace Omp.Net.CApi.Natives;

internal static partial class PlayerNative
{
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_Kick(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern void Player_Ban(IntPtr player, string reason = "");

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsBot(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PeerNetworkData Player_GetNetworkData(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetPing(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SendPacket(IntPtr player, Span<byte> data, int channel, bool dispatchEvents = true);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SendRPC(IntPtr player, int id, Span<byte> data, int channel, bool dispatchEvents = true);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]

	public static extern void Player_BroadcastRPCToStreamed(IntPtr player, int id, Span<byte> data, int channel, bool skipFrom = false);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_BroadcastPacketToStreamed(IntPtr player, Span<byte> data, int channel, bool skipFrom = true);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_BroadcastSyncPacket(IntPtr player, Span<byte> data, int channel);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_Spawn(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern ClientVersion Player_GetClientVersion(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetClientVersionName(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetPositionFindZ(IntPtr player, Vector3 pos);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetCameraPosition(IntPtr player, Vector3 pos);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector3 Player_GetCameraPosition(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetCameraLookAt(IntPtr player, Vector3 pos, PlayerCameraCutType cutType);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector3 Player_GetCameraLookAt(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetCameraBehind(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]

	public static extern void Player_InterpolateCameraPosition(IntPtr player, Vector3 from, Vector3 to, int time, PlayerCameraCutType cutType);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]

	public static extern void Player_InterpolateCameraLookAt(IntPtr player, Vector3 from, Vector3 to, int time, PlayerCameraCutType cutType);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_AttachCameraToObject(IntPtr player, IntPtr obj);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_AttachCameraToPlayerObject(IntPtr player, IntPtr playerObject);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern PlayerNameStatus Player_SetName(IntPtr player, string name);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetName(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetSerial(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_GiveWeapon(IntPtr player, WeaponSlotData weapon);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_RemoveWeapon(IntPtr player, byte weapon);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetWeaponAmmo(IntPtr player, WeaponSlotData data);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetWeapons(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern WeaponSlotData Player_GetWeaponSlot(IntPtr player, int slot);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_ResetWeapons(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetArmedWeapon(IntPtr player, uint weapon);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetArmedWeapon(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetArmedWeaponAmmo(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetShopName(IntPtr player, string name);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetShopName(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetDrunkLevel(IntPtr player, int level);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetDrunkLevel(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetColour(IntPtr player, uint argb);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetColour(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetOtherColour(IntPtr player, IntPtr other, uint argb);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetOtherColour(IntPtr player, IntPtr other, uint* argb);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetControllable(IntPtr player, bool controllable);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_GetControllable(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetSpectating(IntPtr player, bool spectating);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetWantedLevel(IntPtr player, uint level);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetWantedLevel(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_PlaySound(IntPtr player, uint sound, Vector3 pos);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_LastPlayedSound(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_PlayAudio(IntPtr player, string url, bool usePos, Vector3 pos, float distance);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_PlayerCrimeReport(IntPtr player, IntPtr suspect, int crime);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_StopAudio(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_LastPlayedAudio(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_CreateExplosion(IntPtr player, Vector3 vec, int type, float radius);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SendDeathMessage(IntPtr player, IntPtr killed, IntPtr killer, int weapon);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SendEmptyDeathMessage(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_RemoveDefaultObjects(IntPtr player, uint model, Vector3 pos, float radius);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_ForceClassSelection(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetMoney(IntPtr player, int money);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_GiveMoney(IntPtr player, int money);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_ResetMoney(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetMoney(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetMapIcon(IntPtr player, int id, Vector3 pos, int type, uint argb, MapIconStyle style);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_UnsetMapIcon(IntPtr player, int id);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_UseStuntBonuses(IntPtr player, bool enable);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_ToggleOtherNameTag(IntPtr player, IntPtr other, bool toggle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetTime(IntPtr player, long hr, long min);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern void Player_GetTime(IntPtr player, long* hours, long* minutes);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_UseClock(IntPtr player, bool enable);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_HasClock(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_UseWidescreen(IntPtr player, bool enable);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_HasWidescreen(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetTransform(IntPtr player, Vector3 vec3);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetHealth(IntPtr player, float health);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Player_GetHealth(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetScore(IntPtr player, int score);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetScore(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetArmour(IntPtr player, float armour);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Player_GetArmour(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetGravity(IntPtr player, float gravity);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Player_GetGravity(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetWorldTime(IntPtr player, long time);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_ApplyAnimation(IntPtr player, AnimationData animation, PlayerAnimationSyncType syncType);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_ClearAnimations(IntPtr player, PlayerAnimationSyncType syncType);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerAnimationData Player_GetAnimationData(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerSurfingData Player_GetSurfingData(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_StreamInForPlayer(IntPtr player, IntPtr other);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsStreamedInForPlayer(IntPtr player, IntPtr other);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_StreamOutForPlayer(IntPtr player, IntPtr other);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetStreamedPlayers(IntPtr player, IntPtr streamedPlayers);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerState Player_GetState(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetTeam(IntPtr player, int team);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTeam(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetSkin(IntPtr player, int skin, bool send = true);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetSkin(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern void Player_SetChatBubble(IntPtr player, string text, uint argb, float drawDist, long expireMs);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern void Player_SendClientMessage(IntPtr player, uint argb, string message);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern void Player_SendChatMessage(IntPtr player, IntPtr sender, string message);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern void Player_SendCommand(IntPtr player, string message);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern void Player_SendGameText(IntPtr player, string message, long timeMs, int style);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_HideGameText(IntPtr player, int style);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_HasGameText(IntPtr player, int style);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern IntPtr Player_GetGameText(IntPtr player, int style, long* timeMs, long* remainingMs);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetWeather(IntPtr player, int weatherID);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetWeather(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetWorldBounds(IntPtr player, Vector4 coords);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector4 Player_GetWorldBounds(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetFightingStyle(IntPtr player, PlayerFightingStyle style);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerFightingStyle Player_GetFightingStyle(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetSkillLevel(IntPtr player, PlayerWeaponSkill skill, int level);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetAction(IntPtr player, PlayerSpecialAction action);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerSpecialAction Player_GetAction(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetVelocity(IntPtr player, Vector3 velocity);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector3 Player_GetVelocity(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetInterior(IntPtr player, uint interior);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetInterior(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerKeyData Player_GetKeyData(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetSkillLevels(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerAimData Player_GetAimData(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerBulletData Player_GetBulletData(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_UseCameraTargeting(IntPtr player, bool enable);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_HasCameraTargeting(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_RemoveFromVehicle(IntPtr player, bool force);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetCameraTargetPlayer(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetCameraTargetVehicle(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetCameraTargetObject(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetCameraTargetActor(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetTargetPlayer(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Player_GetTargetActor(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SetRemoteVehicleCollisions(IntPtr player, bool collide);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SpectatePlayer(IntPtr player, IntPtr target, PlayerSpectateMode mode);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SpectateVehicle(IntPtr player, IntPtr target, PlayerSpectateMode mode);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern PlayerSpectateData Player_GetSpectateData(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_SendClientCheck(IntPtr player, int actionType, int address, int offset, int count);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_ToggleGhostMode(IntPtr player, bool toggle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsGhostModeEnabled(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetDefaultObjectsRemoved(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_GetKickStatus(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_ClearTasks(IntPtr player, PlayerAnimationSyncType syncType);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_AllowWeapons(IntPtr player, bool allow);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_AreWeaponsAllowed(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_AllowTeleport(IntPtr player, bool allow);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsTeleportAllowed(IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsUsingOfficialClient(IntPtr player);
}
