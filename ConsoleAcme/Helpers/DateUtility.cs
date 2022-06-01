namespace ConsoleAcme.Helpers
{
    public static class DateUtility
    {
        public static TimeSpan getTime(string format)
        {
            var split = format.Split(Constant.SEPARATEHOUR);
            if (split.Length < 2)
                throw new Exception("Bad format time");
            return new TimeSpan(Convert.ToInt16(split[0]), Convert.ToInt16(split[1]), 0);
        }
    }
}
