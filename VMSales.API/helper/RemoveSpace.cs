namespace VMSales.API.helper
{
    public static class RemoveSpace
    {
        public static string TrimSpaceInside(string inputString)
        {
            return inputString.Replace(" ","");
        }

        public static string RemoveFirstCharIfNotNumber(string inputString)
        {
            if (inputString.Length != 0)
            {
                return Int32.TryParse(inputString.Substring(0, 1), out var number) ? inputString : inputString.Substring(1);
            }
            return "0";
        }
    }
}
