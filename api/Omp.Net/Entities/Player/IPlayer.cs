using System.Drawing;
using System.Numerics;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;

namespace Omp.Net.Entities;

public interface IPlayer : IEntity
{
	bool IsBot { get; }
	bool UseGhostMode { get; set; }
	bool IsUsingOfficialClient { get; }
	bool AllowWeapons { get; set; }
	bool AllowTeleport { get; set; }
	bool UseClock { get; set; }
	bool UseWidescreen { get; set; }
	bool UseStuntBonuses { set; }
	bool UseCameraTargeting { get; set; }
	IEnumerable<IPlayerTextDraw> TextDraws { get; }

	PeerNetworkData NetworkData { get; }
	uint Ping { get; }
	ClientVersion ClientVersion { get; }
	string ClientVersionName { get; }
	Vector3 CameraPosition { get; set; }
	Vector3 CameraLookAt { get; }
	string Name { get; }
	string Serial { get; }
	IReadOnlyCollection<WeaponSlotData> Weapons { get; }
	PlayerWeapon ArmedWeapon { get; set; }
	uint ArmedWeaponAmmo { get; }
	string ShopName { get; set; }
	int DrunkLevel { get; set; }
	Color Color { get; set; }
	bool Controllable { get; set; }
	uint WantedLevel { get; set; }
	int Money { get; set; }
	TimeData Time { get; set; }
	float Health { get; set; }
	int Score { get; set; }
	float Armour { get; set; }
	float Gravity { get; set; }
	PlayerAnimationData AnimationData { get; }
	PlayerSurfingData SurfingData { get; }
	PlayerState State { get; }
	int Team { get; set; }
	int Skin { get; }
	int Weather { get; set; }
	Vector4 WorldBounds { get; set; }
	PlayerFightingStyle FightingStyle { get; set; }
	PlayerSpecialAction Action { get; set; }
	Vector3 Velocity { get; set; }
	uint Interior { get; set; }
	PlayerKeyData KeyData { get; }
	IReadOnlyCollection<ushort> SkillLevels { get; }
	PlayerAimData AimData { get; }
	PlayerBulletData BulletData { get; }
	IPlayer CameraTargetPlayer { get; }
	IntPtr CameraTargetVehicle { get; }
	IntPtr CameraTargetObject { get; }
	IntPtr CameraTargetActor { get; }
	IPlayer TargetPlayer { get; }
	IntPtr TargetActor { get; }
	PlayerSpectateData SpectateData { get; }
	int DefaultObjectsRemoved { get; }
	bool KickStatus { get; }

	void SetPositionFindZ(Vector3 pos);
	void SetCameraLookAt(Vector3 pos, PlayerCameraCutType cutType = PlayerCameraCutType.Cut);
	void SetCameraBehind();
	PlayerNameStatus SetName(string name);
	void SetWeaponAmmo(WeaponSlotData data);
	void SetOtherColour(IPlayer other, Color color);
	void SetSpectating(bool spectating);
	void SetMapIcon(int id, Vector3 pos, int type, Color color, MapIconStyle style);
	void SetTransform(Vector3 vec3);
	void SetWorldTime(long time);
	void SetSkin(int skin, bool send = true);
	void SetChatBubble(string text, Color color, float drawDist, long expireMs);
	void SetSkillLevel(PlayerWeaponSkill skill, int level);
	void SetRemoteVehicleCollisions(bool collide);

	IReadOnlyCollection<IPlayer> GetStreamedPlayers();
	string GetGameText(int style, out long timeMs, out long remainingMs);
	WeaponSlotData GetWeaponSlot(int slot);
	bool GetOtherColour(IntPtr other, out Color color);

	void Kick();
	void Ban(string reason = "");
	bool SendPacket(Span<byte> data, int channel, bool dispatchEvents = true);
	bool SendRPC(int id, Span<byte> data, int channel, bool dispatchEvents = true);
	void BroadcastRPCToStreamed(int id, Span<byte> data, int channel, bool skipFrom = false);
	void BroadcastPacketToStreamed(Span<byte> data, int channel, bool skipFrom = true);
	void BroadcastSyncPacket(Span<byte> data, int channel);
	void Spawn();
	void InterpolateCameraPosition(Vector3 from, Vector3 to, int time, PlayerCameraCutType cutType = PlayerCameraCutType.Cut);
	void InterpolateCameraLookAt(Vector3 from, Vector3 to, int time, PlayerCameraCutType cutType = PlayerCameraCutType.Cut);
	void AttachCameraToObject(IntPtr obj);
	void AttachCameraToPlayerObject(IntPtr playerObject);
	void GiveWeapon(WeaponSlotData weapon);
	void RemoveWeapon(PlayerWeapon weapon);
	void ResetWeapons();
	void PlaySound(uint sound, Vector3 pos);
	uint LastPlayedSound();
	void PlayAudio(string url);
	void PlayAudio(string url, Vector3 pos, float distance);
	bool PlayerCrimeReport(IPlayer suspect, int crime);
	void StopAudio();
	string LastPlayedAudio();
	void CreateExplosion(Vector3 vec, int type, float radius);
	void SendDeathMessage(IPlayer killed, IPlayer? killer, PlayerWeapon weapon);
	void SendEmptyDeathMessage();
	void RemoveDefaultObjects(uint model, Vector3 pos, float radius);
	void ForceClassSelection();
	void GiveMoney(int money);
	void ResetMoney();
	void UnsetMapIcon(int id);
	void ToggleOtherNameTag(IPlayer other, bool toggle);
	void ApplyAnimation(AnimationData animation, PlayerAnimationSyncType syncType = PlayerAnimationSyncType.NoSync);
	void ClearAnimations(PlayerAnimationSyncType syncType = PlayerAnimationSyncType.NoSync);
	void StreamInForPlayer(IPlayer other);
	void StreamOutForPlayer(IPlayer other);
	void SendClientMessage(Color color, string message);
	void SendChatMessage(IPlayer sender, string message);
	void SendCommand(string message);
	void SendGameText(string message, long timeMs, int style);
	void HideGameText(int style);
	bool HasGameText(int style);
	void RemoveFromVehicle(bool force);
	void SpectatePlayer(IPlayer target, PlayerSpectateMode mode);
	void SpectateVehicle(IntPtr target, PlayerSpectateMode mode);
	void SendClientCheck(int actionType, int address, int offset, int count);
	void ClearTasks(PlayerAnimationSyncType syncType = PlayerAnimationSyncType.NoSync);
	bool IsStreamedInFor(IPlayer other);
}
