using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SimpleDatabase;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace gMusic.Models
{
    public abstract class MediaItemBase : BaseModel, iDirty, IPopulated
    {
        public MediaItemBase()
        {
        }

        public MediaItemBase(string name) : this(name, Normalize(name))
        {
        }

        public MediaItemBase(string name, string nameNorm)
        {
            Name = name;
            NameNorm = nameNorm;
            IndexCharacter = GetIndexChar(NameNorm);
        }

        string id;

        [Indexed, PrimaryKey]
        public string Id
        {
            get { return id; }
            set { ProcPropertyChanged(ref id, value); }
        }

        string indexCharacter;

        [GroupBy]
        public virtual string IndexCharacter
        {
            get { return indexCharacter; }
            set { ProcPropertyChanged(ref indexCharacter, value); }
        }

        string name;

        [Indexed]
        public string Name
        {
            get { return name; }
            set { ProcPropertyChanged(ref name, value); }
        }

        string nameNorm;

        [OrderBy]
        public virtual string NameNorm
        {
            get { return nameNorm; }
            set { ProcPropertyChanged(ref nameNorm, value); }
        }

        public abstract bool ShouldBeLocal();

        int offlineCount;

        [Indexed]
        public int OfflineCount
        {
            get { return offlineCount; }
            set { ProcPropertyChanged(ref offlineCount, value); }
        }

        public static string GetIndexChar(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "#";
            var theChar = name[0]; //name.Substring (0, 1).ToUpper ();
            return char.IsLetter(theChar) ? name.Substring(0, 1).ToUpper() : "#";
            //return alpha.IndexOf (theChar, StringComparison.OrdinalIgnoreCase) != -1 ? theChar.ToString () : "#";
        }

        public static string Normalize(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "";
            var nameNorm = RemoveDiacritics(name.ToLower()).Trim();
            if (nameNorm.StartsWith("the "))
                nameNorm = nameNorm.Replace("the ", "");
            nameNorm = nameNorm.Replace("'", "");
            nameNorm = nameNorm.Replace("-", " ");
            nameNorm = nameNorm.Replace("_", " ");
            return nameNorm;
        }

        public static string RemoveDiacritics(string input)
        {
            var stFormD = input.Normalize(NormalizationForm.FormD);
            var len = stFormD.Length;
            var sb = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        [Ignore]
        public bool IsDirty { get; set; }

        public void Populated()
        {
            IsDirty = false;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }

        [Ignore]
        public virtual string DetailText { get; }

        string artworkUrl;
        public async Task<string> GetArtworkUrl()
        {
            if (!string.IsNullOrWhiteSpace(artworkUrl))
                return artworkUrl;
            artworkUrl = await Managers.ArtworkManager.Shared.GetArtwork(this);
            return artworkUrl;
        }

        public override bool Equals(object obj)
        {
            var item = obj as MediaItemBase;
            if (item == null)
                return false;
            return item.Id == this.Id;
        }
        public override int GetHashCode() => Id?.GetHashCode() ?? base.GetHashCode();
    }
}