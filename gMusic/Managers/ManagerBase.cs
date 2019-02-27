using System;
using System.Collections.Generic;
using System.Text;
using gMusic.Models;

namespace gMusic.Managers
{
	public class ManagerBase<T> : BaseModel where T : new()
	{
		public static T Shared { get; set; } = new T();
	}
}