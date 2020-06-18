using System;

namespace TALib
{
    public static partial class Core
    {
        public static RetCode StdDev(double[] inReal, int startIdx, int endIdx, double[] outReal, out int outBegIdx, out int outNbElement,
            int optInTimePeriod = 5, double optInNbDev = 1.0)
        {
            outBegIdx = outNbElement = 0;

            if (startIdx < 0 || endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (inReal == null || outReal == null || optInTimePeriod < 2 || optInTimePeriod > 100000)
            {
                return RetCode.BadParam;
            }

            RetCode retCode = TA_INT_VAR(inReal, startIdx, endIdx, outReal, out outBegIdx, out outNbElement, optInTimePeriod);
            if (retCode != RetCode.Success)
            {
                return retCode;
            }

            if (!optInNbDev.Equals(1.0))
            {
                for (var i = 0; i < outNbElement; i++)
                {
                    double tempReal = outReal[i];
                    outReal[i] = !TA_IsZeroOrNeg(tempReal) ? Math.Sqrt(tempReal) * optInNbDev : 0.0;
                }
            }
            else
            {
                for (var i = 0; i < outNbElement; i++)
                {
                    double tempReal = outReal[i];
                    outReal[i] = !TA_IsZeroOrNeg(tempReal) ? Math.Sqrt(tempReal) : 0.0;
                }
            }

            return RetCode.Success;
        }

        public static RetCode StdDev(decimal[] inReal, int startIdx, int endIdx, decimal[] outReal, out int outBegIdx, out int outNbElement,
            int optInTimePeriod = 5, decimal optInNbDev = 1m)
        {
            outBegIdx = outNbElement = 0;

            if (startIdx < 0 || endIdx < 0 || endIdx < startIdx)
            {
                return RetCode.OutOfRangeStartIndex;
            }

            if (inReal == null || outReal == null || optInTimePeriod < 2 || optInTimePeriod > 100000)
            {
                return RetCode.BadParam;
            }

            RetCode retCode = TA_INT_VAR(inReal, startIdx, endIdx, outReal, out outBegIdx, out outNbElement, optInTimePeriod);
            if (retCode != RetCode.Success)
            {
                return retCode;
            }

            if (optInNbDev != Decimal.One)
            {
                for (var i = 0; i < outNbElement; i++)
                {
                    decimal tempReal = outReal[i];
                    outReal[i] = !TA_IsZeroOrNeg(tempReal) ? DecimalMath.Sqrt(tempReal) * optInNbDev : Decimal.Zero;
                }
            }
            else
            {
                for (var i = 0; i < outNbElement; i++)
                {
                    decimal tempReal = outReal[i];
                    outReal[i] = !TA_IsZeroOrNeg(tempReal) ? DecimalMath.Sqrt(tempReal) : Decimal.Zero;
                }
            }

            return RetCode.Success;
        }

        public static int StdDevLookback(int optInTimePeriod = 5)
        {
            if (optInTimePeriod < 2 || optInTimePeriod > 100000)
            {
                return -1;
            }

            return VarLookback(optInTimePeriod);
        }
    }
}
