#if !NET7_0_OR_GREATER
using System.Runtime.InteropServices;
using Omp.Net.Shared.Enums;

namespace Omp.Net.CApi.Natives;

internal static partial class PlayerNative
{
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetSpawnInfo(int playerid, int team, int skin, float x, float y, float z, float rotation, int weapon1, int weapon1_ammo, int weapon2, int weapon2_ammo, int weapon3, int weapon3_ammo);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_Spawn(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetPosition(int playerid, float x, float y, float z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetPositionFindZ(int playerid, float x, float y, float z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public unsafe static extern bool Player_GetPosition(int playerid, float* x, float* y, float* z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetFacingAngle(int playerid, float angle);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public unsafe static extern bool Player_GetFacingAngle(int playerid, float* angle);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsStreamedInFor(int playerid, int forplayerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetInterior(int playerid, uint interiorid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetInterior(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetHealth(int playerid, float health);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetHealth(int playerid, float* health);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetArmour(int playerid, float armour);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetArmour(int playerid, float* armour);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetAmmo(int playerid, int weaponid, int ammo);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetAmmo(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetWeaponState(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTargetPlayer(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTargetActor(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTeam(int playerid, int teamid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTeam(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetScore(int playerid, int score);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetScore(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetDrunkLevel(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetDrunkLevel(int playerid, int level);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetColor(int playerid, uint argb);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetColour(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetSkin(int playerid, int skinid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetSkin(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_GiveWeapon(int playerid, int weaponid, int ammo);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ResetWeapons(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetArmedWeapon(int playerid, uint weaponid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetWeaponData(int playerid, int slot, int* weapon, int* ammo);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_GiveMoney(int playerid, int money);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ResetMoney(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern int Player_SetName(int playerid, [MarshalAs(UnmanagedType.LPStr)] string name);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetMoney(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetState(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_GetIp(int playerid, IntPtr ip, uint size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetPing(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetArmedWeapon(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetKeys(int playerid, int* keys, int* updown, int* leftright);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_GetName(int playerid, IntPtr name, uint size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTime(int playerid, int hour, int minute);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetTime(int playerid, int* hour, int* minute);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ToggleClock(int playerid, bool toggle);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetWeather(int playerid, int weather);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ForceClassSelection(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetWantedLevel(int playerid, uint level);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetWantedLevel(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetFightingStyle(int playerid, int style);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetFightingStyle(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetVelocity(int playerid, float x, float y, float z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetVelocity(int playerid, float* x, float* y, float* z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_PlayCrimeReport(int playerid, int suspectid, int crime);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_PlayAudioStream(int playerid, [MarshalAs(UnmanagedType.LPStr)] string url, float posX = 0, float posY = 0, float posZ = 0, float distance = 50, bool usepos = false);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_StopAudioStream(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_SetShopName(int playerid, [MarshalAs(UnmanagedType.LPStr)] string shopname);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetSkillLevel(int playerid, int skill, int level);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetSurfingVehicleID(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetSurfingObjectID(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_RemoveBuilding(int playerid, int modelid, float x, float y, float z, float radius);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetLastShotVectors(int playerid, float* originX, float* originY, float* originZ, float* hitposX, float* hitposY, float* hitposZ);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetAttachedObject(int playerid, int index, int modelid, int bone, float offsetX = 0, float offsetY = 0, float offsetZ = 0, float rotX = 0, float rotY = 0, float rotZ = 0, float scaleX = 1, float scaleY = 1, float scaleZ = 1, int materialcolor1 = 0, int materialcolor2 = 0);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_RemoveAttachedObject(int playerid, int index);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsAttachedObjectSlotUsed(int playerid, int index);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_EditAttachedObject(int playerid, int index);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern int Player_CreateTextDraw(int playerid, float x, float y, [MarshalAs(UnmanagedType.LPStr)] string text);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_CreatePreviewModelTextDraw(int playerid, float x, float y, int model);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_DestroyTextDraw(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetTextDrawPosition(int playerid, int textid, float* x, float* y);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetTextDrawLetterSize(int playerid, int textid, float* x, float* y);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetTextDrawTextSize(int playerid, int textid, float* x, float* y);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTextDrawAlignment(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetTextDrawColor(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_TextDrawHasBox(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetTextDrawBoxColor(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTextDrawShadow(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTextDrawOutline(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Player_GetTextDrawBackgroundColor(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTextDrawStyle(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsTextDrawProportional(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsTextDrawSelectable(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_GetTextDrawText(int playerid, int textid, IntPtr text, uint size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTextDrawPreviewModel(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetTextDrawPreviewRotation(int playerid, int textid, float* rot_x, float* rot_y, float* rot_z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Player_GetTextDrawPreviewZoom(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTextDrawPreviewVehiclePrimaryColor(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetTextDrawPreviewVehicleSecondaryColor(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawPosition(int playerid, int textid, float x, float y);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawLetterSize(int playerid, int textid, float x, float y);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawTextSize(int playerid, int textid, float x, float y);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawAlignment(int playerid, int textid, int alignment);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawColor(int playerid, int textid, uint argb);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawUseBox(int playerid, int textid, bool use);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawBoxColor(int playerid, int textid, uint argb);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawShadow(int playerid, int textid, int size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawOutline(int playerid, int textid, int size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawBackgroundColor(int playerid, int textid, uint argb);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawStyle(int playerid, int textid, int style);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawProportional(int playerid, int textid, bool proportional);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawSelectable(int playerid, int textid, bool selectable);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ShowTextDraw(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_HideTextDraw(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_SetTextDrawText(int playerid, int textid, [MarshalAs(UnmanagedType.LPStr)] string text);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawPreviewModel(int playerid, int textid, int model);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawPreviewRotation(int playerid, int textid, float rot_x, float rot_y, float rot_z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawPreviewZoom(int playerid, int textid, float zoom);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawPreviewVehiclePrimaryColor(int playerid, int textid, int color);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetTextDrawPreviewVehicleSecondaryColor(int playerid, int textid, int color);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_RestreamTextDraw(int playerid, int textid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_SetPVarInt(int playerid, [MarshalAs(UnmanagedType.LPStr)] string varname, int value);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern int Player_GetPVarInt(int playerid, [MarshalAs(UnmanagedType.LPStr)] string varname);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_SetPVarString(int playerid, [MarshalAs(UnmanagedType.LPStr)] string varname, [MarshalAs(UnmanagedType.LPStr)] string value);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_GetPVarString(int playerid, [MarshalAs(UnmanagedType.LPStr)] string varname, IntPtr value, uint size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_SetPVarFloat(int playerid, [MarshalAs(UnmanagedType.LPStr)] string varname, float value);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern float Player_GetPVarFloat(int playerid, [MarshalAs(UnmanagedType.LPStr)] string varname);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_DeletePVar(int playerid, [MarshalAs(UnmanagedType.LPStr)] string varname);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetPVarsUpperIndex(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_GetPVarNameAtIndex(int playerid, int index, IntPtr varname, uint size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern int Player_GetPVarType(int playerid, [MarshalAs(UnmanagedType.LPStr)] string varname);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_SetChatBubble(int playerid, [MarshalAs(UnmanagedType.LPStr)] string text, int color, float drawdistance, int expiretime);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_PutInVehicle(int playerid, int vehicleid, int seatid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetVehicleID(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetVehicleSeat(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_RemoveFromVehicle(int playerid, bool force);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ToggleControllable(int playerid, bool toggle);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_PlaySound(int playerid, uint soundid, float x, float y, float z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern bool Player_ApplyAnimation(int playerid, [MarshalAs(UnmanagedType.LPStr)] string anim_lib, [MarshalAs(UnmanagedType.LPStr)] string anim_name, float delta, bool loop, bool lock_x, bool lock_y, bool freeze, int time, int sync_type = (int)PlayerAnimationSyncType.NoSync);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ClearAnimations(int playerid, int sync_type = (int)PlayerAnimationSyncType.NoSync);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern ushort Player_GetAnimationIndex(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetSpecialAction(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetSpecialAction(int playerid, int actionid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_DisableRemoteVehicleCollisions(int playerid, bool collide);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetCheckpoint(int playerid, float x, float y, float z, float radius);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_DisableCheckpoint(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetRaceCheckpoint(int playerid, int type, float x, float y, float z, float next_x, float next_y, float next_z, float radius);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_DisableRaceCheckpoint(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetWorldBounds(int playerid, float x_max, float x_min, float y_max, float y_min);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool PLayer_SetMarkerFor(int playerid, int showplayerid, int color);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ShowNameTagFor(int playerid, int showplayerid, bool show);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetMapIcon(int playerid, int iconid, float x, float y, float z, int markertype, uint argb, int style = (int)MapIconStyle.Local);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_RemoveMapIcon(int playerid, int iconid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_AllowTeleport(int playerid, bool allow);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetCameraPos(int playerid, float x, float y, float z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetCameraLookAt(int playerid, float x, float y, float z, int cut_type = (int)PlayerCameraCutType.Cut);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetCameraBehind(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetCameraPos(int playerid, float* x, float* y, float* z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern bool Player_GetCameraFrontVector(int playerid, float* x, float* y, float* z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern byte Player_GetCameraMode(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_EnableCameraTarget(int playerid, bool enable);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetCameraTargetObject(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetCameraTargetVehicle(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetCameraTargetPlayer(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetCameraTargetActor(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Player_GetCameraAspectRatio(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Player_GetCameraZoom(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_AttachCameraToObject(int playerid, int objectid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_InterpolateCameraPos(int playerid, float from_x, float from_y, float from_z, float to_x, float to_y, float to_z, int time, int cut_type = (int)PlayerCameraCutType.Cut);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_InterpolateCameraLookAt(int playerid, float from_x, float from_y, float from_z, float to_x, float to_y, float to_z, int time, int cut_type = (int)PlayerCameraCutType.Cut);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsConnected(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsInVehicle(int playerid, int vehicleid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsInAnyVehicle(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsInCheckpoint(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsInRaceCheckpoint(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetVirtualWorld(int playerid, int worldid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_GetVirtualWorld(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_EnableStuntBonus(int playerid, bool enable);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_ToggleSpectating(int playerid, bool toggle);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SpectatePlayer(int playerid, int targetplayerid, int mode = (int)PlayerSpectateMode.Normal);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SpectateVehicle(int playerid, int targetvehicleid, int mode = (int)PlayerSpectateMode.Normal);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_CreateExplosion(int playerid, float x, float y, float z, int type, float radius);
}
#endif
