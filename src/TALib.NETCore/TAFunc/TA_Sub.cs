namespace TALib
{
    public static partial class Core
    {
        public static RetCode Sub(double[] inReal0, double[] inReal1, int startIdx, int endIdx, double[] outReal, out int outBegIdx,
            out int outNbElement)
        {
            outBegIdx = outNbElement = 0;

            if (startIdx < 0 || endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (inReal0 == null || inReal1 == null || outReal == null)
            {
                return RetCode.BadParam;
            }

            int outIdx = default;
            for (int i = startIdx; i <= endIdx; i++)
            {
                outReal[outIdx++] = inReal0[i] - inReal1[i];
            }

            outNbElement = outIdx;
            outBegIdx = startIdx;

            return RetCode.Success;
        }

        public static RetCode Sub(decimal[] inReal0, decimal[] inReal1, int startIdx, int endIdx, decimal[] outReal, out int outBegIdx,
            out int outNbElement)
        {
            outBegIdx = outNbElement = 0;

            if (startIdx < 0 || endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (inReal0 == null || inReal1 == null || outReal == null)
            {
                return RetCode.BadParam;
            }

            int outIdx = default;
            for (int i = startIdx; i <= endIdx; i++)
            {
                outReal[outIdx++] = inReal0[i] * inReal1[i];
            }

            outNbElement = outIdx;
            outBegIdx = startIdx;

            return RetCode.Success;
        }

        public static int SubLookback() => 0;
    }
}
