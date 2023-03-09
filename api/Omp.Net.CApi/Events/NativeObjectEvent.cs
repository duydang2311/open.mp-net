using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;

namespace Omp.Net.CApi.Events;

internal delegate void OnObjectMovedDelegate(EntityId obj);
internal delegate void OnPlayerObjectMovedDelegate(EntityId player, EntityId obj);
internal delegate void OnObjectSelectedDelegate(EntityId player, EntityId obj, int model, Vector3 position);
internal delegate void OnPlayerObjectSelectedDelegate(EntityId player, EntityId obj, int model, Vector3 position);
internal delegate void OnObjectEditedDelegate(EntityId player, EntityId obj, ObjectEditResponse response, Vector3 offset, Vector3 rotation);
internal delegate void OnPlayerObjectEditedDelegate(EntityId player, EntityId obj, ObjectEditResponse response, Vector3 offset, Vector3 rotation);
internal delegate void OnPlayerAttachedObjectEditedDelegate(EntityId player, int index, bool saved, ObjectAttachmentSlotData data);


internal static class NativeObjectEvent
{
	public static event OnObjectMovedDelegate? NativeOnObjectMoved;
	public static event OnPlayerObjectMovedDelegate? NativeOnPlayerObjectMoved;
	public static event OnObjectSelectedDelegate? NativeOnObjectSelected;
	public static event OnPlayerObjectSelectedDelegate? NativeOnPlayerObjectSelected;
	public static event OnObjectEditedDelegate? NativeOnObjectEdited;
	public static event OnPlayerObjectEditedDelegate? NativeOnPlayerObjectEdited;
	public static event OnPlayerAttachedObjectEditedDelegate? NativeOnPlayerAttachedObjectEdited;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnObjectMoved(EntityId obj)
	{
		NativeOnObjectMoved?.Invoke(obj);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerObjectMoved(EntityId player, EntityId obj)
	{
		NativeOnPlayerObjectMoved?.Invoke(player, obj);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnObjectSelected(EntityId player, EntityId obj, int model, Vector3 position)
	{
		NativeOnObjectSelected?.Invoke(player, obj, model, position);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerObjectSelected(EntityId player, EntityId obj, int model, Vector3 position)
	{
		NativeOnPlayerObjectSelected?.Invoke(player, obj, model, position);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnObjectEdited(EntityId player, EntityId obj, ObjectEditResponse response, Vector3 offset, Vector3 rotation)
	{
		NativeOnObjectEdited?.Invoke(player, obj, response, offset, rotation);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerObjectEdited(EntityId player, EntityId obj, ObjectEditResponse response, Vector3 offset, Vector3 rotation)
	{
		NativeOnPlayerObjectEdited?.Invoke(player, obj, response, offset, rotation);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static unsafe void OnPlayerAttachedObjectEdited(EntityId player, int index, bool saved, void* objectAttachmentSlotDataPtr)
	{
		unsafe
		{
			var model = *((int*)objectAttachmentSlotDataPtr + 0);
			var bone = *((int*)objectAttachmentSlotDataPtr + 1);
			var offsetX = *((float*)objectAttachmentSlotDataPtr + 2);
			var offsetY = *((float*)objectAttachmentSlotDataPtr + 3);
			var offsetZ = *((float*)objectAttachmentSlotDataPtr + 4);
			var rotX = *((float*)objectAttachmentSlotDataPtr + 5);
			var rotY = *((float*)objectAttachmentSlotDataPtr + 6);
			var rotZ = *((float*)objectAttachmentSlotDataPtr + 7);
			var scaleX = *((float*)objectAttachmentSlotDataPtr + 8);
			var scaleY = *((float*)objectAttachmentSlotDataPtr + 9);
			var scaleZ = *((float*)objectAttachmentSlotDataPtr + 10);
			var r1 = *((byte*)objectAttachmentSlotDataPtr + 44);
			var g1 = *((byte*)objectAttachmentSlotDataPtr + 45);
			var b1 = *((byte*)objectAttachmentSlotDataPtr + 46);
			var a1 = *((byte*)objectAttachmentSlotDataPtr + 47);
			var r2 = *((byte*)objectAttachmentSlotDataPtr + 48);
			var g2 = *((byte*)objectAttachmentSlotDataPtr + 49);
			var b2 = *((byte*)objectAttachmentSlotDataPtr + 50);
			var a2 = *((byte*)objectAttachmentSlotDataPtr + 51);
			ObjectAttachmentSlotData data = new() { Model = model, Bone = bone, Offset = new Vector3(offsetX, offsetY, offsetZ), Rotation = new Vector3(rotX, rotY, rotZ), Scale = new Vector3(scaleX, scaleY, scaleZ), Color1 = Color.FromArgb(a1, r1, g1, b1), Color2 = Color.FromArgb(a2, r2, g2, b2) };
			NativeOnPlayerAttachedObjectEdited?.Invoke(player, index, saved, data);
		}
	}
}
