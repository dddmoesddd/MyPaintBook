using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Text;

namespace PaintBook.Content.Domain.PostAndPostInfo.Model
{
    public class PostInfo : ValueObject
    {

        public bool IsLike { get; private set; }
        public bool IsShared { get; private set; }
        public long LikeCount { get; private set; }
        public long SharedCount { get; private set; }
        public bool UnfallowOwner { get; private set; }
        public bool HidePost { get; private set; }
        public string Value { get; }

        public PostInfo(bool isLike, bool isShared, bool unfallowowner, bool hidepost)
        {
            IsLike = isLike;
            IsShared = isShared;
            UnfallowOwner = unfallowowner;
            HidePost = hidepost;
            var st = new StringBuilder();
            st.Append("IsLike:" + isLike.ToString());
            st.Append(";");
            st.Append("IsShared:" + isShared.ToString());
            st.Append(";");
            st.Append("UnfallowOwner:" + unfallowowner.ToString());
            st.Append(";");
            st.Append("HidePost:" + hidepost.ToString());
            Value = st.ToString();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IsLike;
            yield return IsShared;
            yield return LikeCount;
            yield return SharedCount;
            yield return UnfallowOwner;

        }

        public static Result<PostInfo> Create(string value)
        {
            var values = value.Split(";");
            var isLike = values[0].Split(":");
            var isshared = values[1].Split(":");
            var unfallowowner = values[2].Split(":");
            var hidepost = values[3].Split(":");
            return Result.Success(new PostInfo(bool.Parse(isLike[1]),
                bool.Parse(isshared[1]),
                bool.Parse(unfallowowner[1]),
                bool.Parse(hidepost[1])));
        }

    }
}
