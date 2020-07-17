using System;

namespace Domain
{
    public class ReverserNameUseCase
    {
        public ReverseNameResponse Reverse(string name, WhitespacePolicy whitespacePolicy)
        {
            var reversed = Reverse(name);
            bool isPalindrome;
            
            if (whitespacePolicy == WhitespacePolicy.Ignore)
            {
                var nameNoSpaces = name.Replace(" ", "");
                var reversedNoSpaces = reversed.Replace(" ", "");
                
                isPalindrome = nameNoSpaces == reversedNoSpaces;
                return new ReverseNameResponse(reversed, isPalindrome);
            }

            isPalindrome = name == reversed;
            return new ReverseNameResponse(reversed, isPalindrome);
        }

        private string Reverse(string word)
        {
            var charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}