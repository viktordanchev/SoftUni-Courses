namespace Problem04.BalancedParentheses
{
    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        { 
            char[] parenthesesArray = parentheses.ToCharArray();

            if (parenthesesArray.Length % 2 == 1)
                return false;

            for (int i = 0; i < parenthesesArray.Length; i++)
            {
                var openParenthese = parenthesesArray[i];
                var closeParenthese = ' ';

                switch (openParenthese)
                {
                    case '(':
                        closeParenthese = ')';
                        break;
                    case '{':
                        closeParenthese = '}';
                        break;
                    case '[':
                        closeParenthese = ']';
                        break;
                    default:
                        continue;
                }

                if (!IsClosed(i, parenthesesArray, closeParenthese))
                    return false;
            }

            return true;
        }

        private bool IsClosed(int start, char[] parentheses, char closeParenthese)
        {
            for (int i = start; i < parentheses.Length; i++)
            {
                if (parentheses[i] == closeParenthese)
                    return true;
            }

            return false;
        }
    }
}
