using System.Numerics;

namespace Omp.Net.Entities;

public interface IPlayer
{
	int Id { get; }
	string Name { get; }
	Vector3 Position { get; }
	float FacingAngle { get; }
	bool SetSpawnInfo(int team, int skin, float x, float y, float z, float rotation, int weapon1 = 0, int weapon1_ammo = 0, int weapon2 = 0, int weapon2_ammo = 0, int weapon3 = 0, int weapon3_ammo = 0);
	bool Spawn();
	bool SetPosition(float x, float y, float z);
	bool SetPositionFindZ(float x, float y, float z);
	bool SetFacingAngle(float angle);
	int SetName(string name);
}
