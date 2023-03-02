namespace Omp.Net.Shared.Enums;

public enum PlayerWeaponState : sbyte
{
	PlayerWeaponState_Unknown = -1,
	PlayerWeaponState_NoBullets,
	PlayerWeaponState_LastBullet,
	PlayerWeaponState_MoreBullets,
	PlayerWeaponState_Reloading
};
