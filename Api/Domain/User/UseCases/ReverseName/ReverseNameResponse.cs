using System;
using System.ComponentModel;

namespace Domain
{
    public class ReverseNameResponse : IEquatable<ReverseNameResponse>
    {
        public readonly string ReversedName;
        public readonly bool IsPalindrome;

        public ReverseNameResponse(string reversedName, bool isPalindrome)
        {
            ReversedName = reversedName;
            IsPalindrome = isPalindrome;
        }
        
        public bool Equals(ReverseNameResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ReversedName == other.ReversedName && IsPalindrome == other.IsPalindrome;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ReverseNameResponse) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ReversedName, IsPalindrome);
        }

        public static bool operator ==(ReverseNameResponse left, ReverseNameResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReverseNameResponse left, ReverseNameResponse right)
        {
            return !Equals(left, right);
        }
    }
}