using System.Drawing;
using System.Numerics;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;

namespace Omp.Net.Entities;

public interface IPlayer
{
	IntPtr NativeHandle { get; }
	int Id { get; }
	Vector3 Position { get; }
	float FacingAngle { get; }
	int Interior { get; }
	float Health { get; }
	float Armour { get; }
	int Ammo { get; }
	PlayerWeaponState WeaponState { get; }
	IPlayer TargetPlayer { get; }
	int TargetActor { get; }
	int Team { get; }
	int Score { get; }
	int DrunkLevel { get; }
	Color Colour { get; }
	int Skin { get; }
	int Money { get; }
	PlayerState State { get; }
	string Ip { get; }
	uint Ping { get; }
	PlayerWeapon ArmedWeapon { get; }
	string Name { get; }
	uint WantedLevel { get; }
	int FightingStyle { get; }
	Vector3 Velocity { get; }
	int SurfingVehicleID { get; }
	int SurfingObjectID { get; }
	int VehicleID { get; }
	int VehicleSeat { get; }
	uint AnimationIndex { get; }
	PlayerSpecialAction SpecialAction { get; }
	Vector3 CameraPos { get; }
	Vector3 FrontVector { get; }
	byte CameraMode { get; }
	int CameraTargetObject { get; }
	int CameraTargetVehicle { get; }
	int CameraTargetPlayer { get; }
	int CameraTargetActor { get; }
	float CameraAspectRatio { get; }
	float CameraZoom { get; }
	int VirtualWorld { get; }
	KeysData Keys { get; }
	TimeData Time { get; }
	ShotVectorsData LastShotVectors { get; }
	bool Connected { get; }
	bool IsInAnyVehicle { get; }
	bool IsInCheckpoint { get; }
	bool IsInRaceCheckpoint { get; }

	bool GetWeaponData(int slot, out WeaponData data);
	bool SetSpawnInfo(int team, int skin, Vector3 position, float rotation, int weapon1 = 0, int weapon1_ammo = 0, int weapon2 = 0, int weapon2_ammo = 0, int weapon3 = 0, int weapon3_ammo = 0);
	bool Spawn();
	bool SetPosition(Vector3 position);
	bool SetPositionFindZ(Vector3 position);
	bool SetFacingAngle(float angle);
	bool IsStreamedInFor(IPlayer other);
	bool SetInterior(uint interiorId);
	bool SetHealth(float health);
	bool SetArmour(float armour);
	bool SetAmmo(PlayerWeapon weapon, int ammo);
	bool SetTeam(int teamId);
	bool SetScore(int score);
	bool SetDrunkLevel(int level);
	bool SetColor(Color color);
	bool SetSkin(int skinid);
	bool GiveWeapon(PlayerWeapon weapon, int ammo);
	bool ResetWeapons();
	bool SetArmedWeapon(PlayerWeapon weapon);
	bool GiveMoney(int money);
	bool ResetMoney();
	int SetName(string name);
	bool SetTime(TimeData data);
	bool ToggleClock(bool toggle);
	bool SetWeather(int weather);
	bool ForceClassSelection();
	bool SetWantedLevel(uint level);
	bool SetFightingStyle(int style);
	bool SetVelocity(Vector3 velocity);
	bool PlayCrimeReport(IPlayer suspect, int crime);
	bool PlayAudioStream(string url, Vector3 position, float radius = 50, bool usepos = false);
	bool StopAudioStream();
	bool SetShopName(string shopname);
	bool SetSkillLevel(PlayerWeaponSkill skill, int level);
	bool RemoveBuilding(int modelid, Vector3 position, float radius);
	bool SetAttachedObject(int index, int modelid, int bone, Vector3 offset, Vector3 rotation = default, Vector3? scale = null, Color materialColor1 = default, Color materialColor2 = default);
	bool RemoveAttachedObject(int index);
	bool IsAttachedObjectSlotUsed(int index);
	bool EditAttachedObject(int index);
	IPlayerTextDraw CreateTextDraw(Vector2 position, string text);
	IPlayerTextDraw CreateTextDraw(Vector2 position, int model);
	bool SetChatBubble(string text, int color, float drawDistance, int expireTime);
	bool PutInVehicle(int vehicleId, int seatId);
	bool RemoveFromVehicle(bool force);
	bool ToggleControllable(bool toggle);
	bool PlaySound(uint soundId, Vector3 position);
	bool ApplyAnimation(string anim_lib, string anim_name, float delta, bool loop, bool lock_x, bool lock_y, bool freeze, int time, int sync_type = (int)PlayerAnimationSyncType.NoSync);
	bool ClearAnimations(int sync_type = (int)PlayerAnimationSyncType.NoSync);
	bool SetSpecialAction(int actionid);
	bool DisableRemoteVehicleCollisions(bool collide);
	bool SetCheckpoint(Vector3 position, float radius);
	bool DisableCheckpoint();
	bool SetRaceCheckpoint(int type, Vector3 position, Vector3 nextPosition, float radius);
	bool DisableRaceCheckpoint();
	bool SetWorldBounds(float x_max, float x_min, float y_max, float y_min);
	bool SetMarkerFor(IPlayer other, int color);
	bool ShowNameTagFor(IPlayer other, bool show);
	bool SetMapIcon(int iconId, Vector3 position, int markertype, uint color, int style = (int)MapIconStyle.Local);
	bool RemoveMapIcon(int iconId);
	bool AllowTeleport(bool allow);
	bool SetCameraPos(Vector3 position);
	bool SetCameraLookAt(Vector3 position, int cut_type = (int)PlayerCameraCutType.Cut);
	bool SetCameraBehind();
	bool EnableCameraTarget(bool enable);
	bool AttachCameraToObject(int objectId);
	bool InterpolateCameraPos(Vector3 fromPosition, Vector3 toPosition, int time, int cut_type = (int)PlayerCameraCutType.Cut);
	bool InterpolateCameraLookAt(Vector3 fromPosition, Vector3 toPosition, int time, int cut_type = (int)PlayerCameraCutType.Cut);
	bool SetVirtualWorld(int worldId);
	bool EnableStuntBonusFor(bool enable);
	bool ToggleSpectating(bool toggle);
	bool Spectate(IPlayer target, int mode = (int)PlayerSpectateMode.Normal);
	bool Spectate(int targetvehicleid, int mode = (int)PlayerSpectateMode.Normal);
	bool CreateExplosion(Vector3 position, int type, float radius);
	bool IsInVehicle(int vehicleid);
}
