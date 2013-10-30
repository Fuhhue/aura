﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence file in the main folder

namespace Aura.Data.Database
{
	public class ChairInfo
	{
		public int ItemId { get; internal set; }
		public int PropId { get; internal set; }
		public int GiantPropId { get; internal set; }
		public int Effect { get; internal set; }
	}

	/// <summary>
	/// Indexed by item id.
	/// </summary>
	public class ChairDb : DatabaseCSVIndexed<int, ChairInfo>
	{
		protected override void ReadEntry(CSVEntry entry)
		{
			if (entry.Count < 5)
				throw new FieldCountException(5);

			var info = new ChairInfo();
			info.ItemId = entry.ReadInt();
			entry.ReadString();
			info.PropId = entry.ReadInt();
			info.GiantPropId = entry.ReadInt();
			info.Effect = entry.ReadInt();

			this.Entries.Add(info.ItemId, info);
		}
	}
}
