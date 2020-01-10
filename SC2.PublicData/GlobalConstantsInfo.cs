using System;

namespace SC2.PublicData
{
    [Serializable]
    public class GlobalConstantsInfo
    {
        public int MineralsPatchesPerBase { get; set; }

        public int GasPatchesPerBase { get; set; }

        public int MaximumPeriodInSecondsForBuildPrediction { get; set; }

        public int MineralsPerMinuteFrom3WorkersPerPatch { get; set; }

        public int MineralsPerMinuteFrom2WorkersPerPatch { get; set; }

        public int MineralsPerMinuteFrom1WorkerPerPatch { get; set; }

        public int GasPerMinuteFrom3WorkersPerPatch { get; set; }

        public int GasPerMinuteFrom2WorkersPerPatch { get; set; }

        public int GasPerMinuteFrom1WorkerPerPatch { get; set; }

        public int MineralsPerMinuteFrom1Mule { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GlobalConstantsInfo) obj);
        }

        protected bool Equals(GlobalConstantsInfo s)
        {
            return MineralsPatchesPerBase == s.MineralsPatchesPerBase
                   && GasPatchesPerBase == s.GasPatchesPerBase
                   && MaximumPeriodInSecondsForBuildPrediction == s.MaximumPeriodInSecondsForBuildPrediction
                   && MineralsPerMinuteFrom3WorkersPerPatch == s.MineralsPerMinuteFrom3WorkersPerPatch
                   && MineralsPerMinuteFrom2WorkersPerPatch == s.MineralsPerMinuteFrom2WorkersPerPatch
                   && MineralsPerMinuteFrom1WorkerPerPatch == s.MineralsPerMinuteFrom1WorkerPerPatch
                   && GasPerMinuteFrom3WorkersPerPatch == s.GasPerMinuteFrom3WorkersPerPatch
                   && GasPerMinuteFrom2WorkersPerPatch == s.GasPerMinuteFrom2WorkersPerPatch
                   && GasPerMinuteFrom1WorkerPerPatch == s.GasPerMinuteFrom1WorkerPerPatch
                   && MineralsPerMinuteFrom1Mule == s.MineralsPerMinuteFrom1Mule;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = MineralsPatchesPerBase;
                hashCode = (hashCode) ^ GasPatchesPerBase;
                hashCode = (hashCode) ^ MaximumPeriodInSecondsForBuildPrediction;
                hashCode = (hashCode) ^ MineralsPerMinuteFrom3WorkersPerPatch;
                hashCode = (hashCode) ^ MineralsPerMinuteFrom2WorkersPerPatch;
                hashCode = (hashCode) ^ MineralsPerMinuteFrom1WorkerPerPatch;
                hashCode = (hashCode) ^ GasPerMinuteFrom3WorkersPerPatch;
                hashCode = (hashCode) ^ GasPerMinuteFrom2WorkersPerPatch;
                hashCode = (hashCode) ^ GasPerMinuteFrom1WorkerPerPatch;
                hashCode = (hashCode) ^ MineralsPerMinuteFrom1Mule;
                return hashCode;
            }
        }
    }
}
