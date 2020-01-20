namespace TALib
{
    public partial class Core
    {
        public static RetCode MacdFix(int startIdx, int endIdx, double[] inReal, ref int outBegIdx, ref int outNBElement, double[] outMACD,
            double[] outMACDSignal, double[] outMACDHist, int optInSignalPeriod = 9)
        {
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inReal == null)
            {
                return RetCode.BadParam;
            }

            if (optInSignalPeriod < 1 || optInSignalPeriod > 100000)
            {
                return RetCode.BadParam;
            }

            if (outMACD == null)
            {
                return RetCode.BadParam;
            }

            if (outMACDSignal == null)
            {
                return RetCode.BadParam;
            }

            if (outMACDHist == null)
            {
                return RetCode.BadParam;
            }

            return TA_INT_MACD(startIdx, endIdx, inReal, 0, 0, optInSignalPeriod, ref outBegIdx, ref outNBElement, outMACD, outMACDSignal,
                outMACDHist);
        }

        public static RetCode MacdFix(int startIdx, int endIdx, decimal[] inReal, ref int outBegIdx, ref int outNBElement,
            decimal[] outMACD, decimal[] outMACDSignal, decimal[] outMACDHist, int optInSignalPeriod = 9)
        {
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inReal == null)
            {
                return RetCode.BadParam;
            }

            if (optInSignalPeriod < 1 || optInSignalPeriod > 100000)
            {
                return RetCode.BadParam;
            }

            if (outMACD == null)
            {
                return RetCode.BadParam;
            }

            if (outMACDSignal == null)
            {
                return RetCode.BadParam;
            }

            if (outMACDHist == null)
            {
                return RetCode.BadParam;
            }

            return TA_INT_MACD(startIdx, endIdx, inReal, 0, 0, optInSignalPeriod, ref outBegIdx, ref outNBElement, outMACD, outMACDSignal,
                outMACDHist);
        }

        public static int MacdFixLookback(int optInSignalPeriod)
        {
            return EmaLookback(26) + EmaLookback(optInSignalPeriod);
        }
    }
}
