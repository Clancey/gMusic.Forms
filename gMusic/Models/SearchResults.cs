using System;
using System.Collections.Generic;
using gMusic.Models;

namespace gMusic
{
	public class SearchResults
	{
        public List<GroupedMediaItems> Sections = new List<GroupedMediaItems>();

        public void Add(string title, List<MediaItemBase> items)
        {
            Sections.Add(new GroupedMediaItems(title,items));
        }

		public string Query { get; set; }

        public class GroupedMediaItems :List<MediaItemBase>
        {
            public GroupedMediaItems(string title, List<MediaItemBase> items) : base(items)
            {
                Title = title;
            }
            public string Title { get; set; }
            public string QuickJump { get; set; } = "∙";
        }
	}
}

