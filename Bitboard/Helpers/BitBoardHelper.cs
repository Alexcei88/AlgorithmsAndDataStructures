namespace ConsoleTester.Helpers
{
    public static class BitBoardHelper
    {
        public static int PopCnt(ulong bits)
        {
            int count = 0;
            while (bits > 0)
            {
                ++count;
                bits &= bits - 1;
            }

            return count;
        }
    }
}