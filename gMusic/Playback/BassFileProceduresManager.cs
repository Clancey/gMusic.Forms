
using System;
using ManagedBass;
using System.Collections.Generic;
using gMusic.Managers;
namespace gMusic.Playback {
	public static class BassFileProceduresManager {
		public static void ClearProcedure (IntPtr user)
		{
			OnClearProcedure?.Invoke (user);
		}
		public static Action<IntPtr> OnClearProcedure { get; set; }

		public static Func<FileProcedures, IntPtr, (FileProcedures proc, IntPtr user)> CreateFileProcedureImpl { get; set; } = (proc, user) => (proc, user);

		public static (FileProcedures proc, IntPtr user) CreateProcedure (FileProcedures proc, IntPtr user = default (IntPtr)) => CreateFileProcedureImpl (proc, user);

		public static Func<SyncProcedure, IntPtr, (SyncProcedure proc, IntPtr user)> CreateSyncProcedureImpl { get; set; } = (proc, user) => (proc, user);


		public static (SyncProcedure proc, IntPtr user) CreateProcedure (SyncProcedure proc, IntPtr user = default (IntPtr)) => CreateSyncProcedureImpl (proc, user);
	}
}