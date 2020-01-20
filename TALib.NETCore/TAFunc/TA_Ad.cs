using System;

namespace TALib
{
    public partial class Core
    {
        public static RetCode Ad(int startIdx, int endIdx, double[] inHigh, double[] inLow, double[] inClose, double[] inVolume,
            ref int outBegIdx, ref int outNBElement, double[] outReal)
        {
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inHigh == null || inLow == null || inClose == null || inVolume == null)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            int nbBar = endIdx - startIdx + 1;
            outNBElement = nbBar;
            outBegIdx = startIdx;
            int currentBar = startIdx;
            int outIdx = default;
            double ad = default;
            while (true)
            {
                if (nbBar == 0)
                {
                    break;
                }

                double high = inHigh[currentBar];
                double low = inLow[currentBar];
                double tmp = high - low;
                double close = inClose[currentBar];
                if (tmp > 0.0)
                {
                    ad += (close - low - (high - close)) / tmp * inVolume[currentBar];
                }

                outReal[outIdx] = ad;
                outIdx++;
                currentBar++;
                nbBar--;
            }

            return RetCode.Success;
        }

        public static RetCode Ad(int startIdx, int endIdx, decimal[] inHigh, decimal[] inLow, decimal[] inClose, decimal[] inVolume,
            ref int outBegIdx, ref int outNBElement, decimal[] outReal)
        {
            if (startIdx < 0)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeEndIndex;
            }

            if (inHigh == null || inLow == null || inClose == null || inVolume == null)
            {
                return RetCode.BadParam;
            }

            if (outReal == null)
            {
                return RetCode.BadParam;
            }

            int nbBar = endIdx - startIdx + 1;
            outNBElement = nbBar;
            outBegIdx = startIdx;
            int currentBar = startIdx;
            int outIdx = default;
            decimal ad = default;
            while (true)
            {
                if (nbBar == 0)
                {
                    break;
                }

                decimal high = inHigh[currentBar];
                decimal low = inLow[currentBar];
                decimal tmp = high - low;
                decimal close = inClose[currentBar];
                if (tmp > Decimal.Zero)
                {
                    ad += (close - low - (high - close)) / tmp * inVolume[currentBar];
                }

                outReal[outIdx] = ad;
                outIdx++;
                currentBar++;
                nbBar--;
            }

            return RetCode.Success;
        }

        public static int AdLookback()
        {
            return 0;
        }
    }
}
