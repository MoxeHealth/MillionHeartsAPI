using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//NAME: ArchimedesResponseHelper
//AUTHOR: Mark Olschesky
//PURPOSE: A helper class for storing the items needed for Archimedes API calls.
//COPYRIGHT: MIT License - Please attribute ownership back to the author/source company. You must include the MIT License in all included iterations of the code.
/*
Copyright (c) 2012 Mox eHealth, LLC.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. */

namespace MightyHeartsAPI
{
    public class Interventions
    {
        public float IncreaseInRisk { get; set; }
        public float ModerateExerciseReduction { get; set; }
        public float VigorousExerciseReduction { get; set; }
        public float WeightLossReduction { get; set; }
        public float MedicationReduction { get; set; }
        public float SmokingReduction { get; set; }
        public float AllReductions { get; set; }
        public float WeightLossRequired { get; set; }
        public Interventions(float IncreaseInRisk, float ModerateExerciseReduction, float VigorousExerciseReduction, float WeightLossReduction, float MedicationReduction, float SmokingReduction, float AllReductions, float WeightLossRequired)
        {
            this.IncreaseInRisk = IncreaseInRisk;
            this.ModerateExerciseReduction = ModerateExerciseReduction;
            this.VigorousExerciseReduction = VigorousExerciseReduction;
            this.WeightLossReduction = WeightLossReduction;
            this.MedicationReduction = MedicationReduction;
            this.SmokingReduction = SmokingReduction;
            this.AllReductions = AllReductions;
            this.WeightLossReduction = WeightLossReduction;
            this.WeightLossRequired = WeightLossRequired;
        }

    }

    public class CVDRisk
    {
        public float comparisonRisk { get; set; }
        public float rating { get; set; }
        public float ratingForAge { get; set; }
        public float risk { get; set; }
        public float riskPercentile { get; set; }
        public CVDRisk(float comparisonRisk, float rating, float ratingForAge, float risk, float riskPercentile)
        {
            this.comparisonRisk = comparisonRisk;
            this.rating = rating;
            this.ratingForAge = ratingForAge;
            this.risk = risk;
            this.riskPercentile = riskPercentile;
        }
    }
    public class HighCVDRisk
    {
        public float comparisonRisk { get; set; }
        public float rating { get; set; }
        public float ratingForAge { get; set; }
        public float risk { get; set; }
        public float riskPercentile { get; set; }
        public HighCVDRisk(float comparisonRisk, float rating, float ratingForAge, float risk, float riskPercentile)
        {
            this.comparisonRisk = comparisonRisk;
            this.rating = rating;
            this.ratingForAge = ratingForAge;
            this.risk = risk;
            this.riskPercentile = riskPercentile;
        }
    }
    public class LowCVDRisk
    {
        public float comparisonRisk { get; set; }
        public float rating { get; set; }
        public float ratingForAge { get; set; }
        public float risk { get; set; }
        public float riskPercentile { get; set; }
        public LowCVDRisk(float comparisonRisk, float rating, float ratingForAge, float risk, float riskPercentile)
        {
            this.comparisonRisk = comparisonRisk;
            this.rating = rating;
            this.ratingForAge = ratingForAge;
            this.risk = risk;
            this.riskPercentile = riskPercentile;
        }
    }

    public class OtherArchInfo
    {
        public float DoctorRecommendation { get; set; }
        public Boolean ElevatedBloodPressure { get; set; }
        public Boolean ElevatedCholesterol { get; set; }
        public float Recommendation { get; set; }
        public float WarningCode { get; set; }
        public OtherArchInfo(Boolean ElevatedBloodPressure, Boolean ElevatedCholesterol, float WarningCode, float Recommendation = 0, float DoctorRecommendation = 0)
        {
            this.DoctorRecommendation = DoctorRecommendation;
            this.ElevatedBloodPressure = ElevatedBloodPressure;
            this.ElevatedCholesterol = ElevatedCholesterol;
            this.Recommendation = Recommendation;
            this.WarningCode = WarningCode;
        }
    }
    public class ArchimedesResponseHelper
    {
        public float DoctorRecommendation { get; set; }
        public Boolean ElevatedBloodPressure { get; set; }
        public Boolean ElevatedCholesterol { get; set; }
        public float Recommendation { get; set; }
        public float WarningCode { get; set; }
        public float CVDComparisonRisk { get; set; }
        public float CVDRating { get; set; }
        public float CVDRatingForAge { get; set; }
        public float CVDRisk { get; set; }
        public float CVDRiskPercentile { get; set; }
        public float HighComparisonRisk { get; set; }
        public float HighRating { get; set; }
        public float HighRatingForAge { get; set; }
        public float HighRisk { get; set; }
        public float HighRiskPercentile { get; set; }
        public float LowComparisonRisk { get; set; }
        public float LowRating { get; set; }
        public float LowRatingForAge { get; set; }
        public float LowRisk { get; set; }
        public float LowRiskPercentile { get; set; }
        public float IncreaseInRisk { get; set; }
        public float ModerateExerciseReduction { get; set; }
        public float VigorousExerciseReduction { get; set; }
        public float WeightLossReduction { get; set; }
        public float MedicationReduction { get; set; }
        public float SmokingReduction { get; set; }
        public float AllReductions { get; set; }
        public float WeightLossRequired { get; set; }
        public ArchimedesResponseHelper(Interventions floater, CVDRisk CVD, HighCVDRisk HighCVD, LowCVDRisk LowCVD, OtherArchInfo OtherArch)
        {
            this.DoctorRecommendation = OtherArch.DoctorRecommendation;
            this.ElevatedBloodPressure = OtherArch.ElevatedBloodPressure;
            this.ElevatedCholesterol = OtherArch.ElevatedCholesterol;
            this.Recommendation = OtherArch.Recommendation;
            this.WarningCode = OtherArch.WarningCode;
            this.CVDComparisonRisk = CVD.comparisonRisk;
            this.CVDRating = CVD.rating;
            this.CVDRatingForAge = CVD.ratingForAge;
            this.CVDRisk = CVD.risk;
            this.CVDRiskPercentile = CVD.riskPercentile;
            this.HighComparisonRisk = HighCVD.comparisonRisk;
            this.HighRating = HighCVD.rating;
            this.HighRatingForAge = HighCVD.ratingForAge;
            this.HighRisk = HighCVD.risk;
            this.HighRiskPercentile = HighCVD.riskPercentile;
            this.LowComparisonRisk = LowCVD.comparisonRisk;
            this.LowRating = LowCVD.rating;
            this.LowRatingForAge = LowCVD.ratingForAge;
            this.LowRisk = LowCVD.risk;
            this.LowRiskPercentile = LowCVD.riskPercentile;
            this.ModerateExerciseReduction = floater.ModerateExerciseReduction;
            this.VigorousExerciseReduction = floater.VigorousExerciseReduction;
            this.IncreaseInRisk = floater.IncreaseInRisk;
            this.WeightLossReduction = floater.WeightLossReduction;
            this.WeightLossRequired = floater.WeightLossRequired;
            this.SmokingReduction = floater.SmokingReduction;
            this.AllReductions = floater.AllReductions;
            this.MedicationReduction = floater.MedicationReduction;
        }
        public ArchimedesResponseHelper(Interventions floater, OtherArchInfo OtherArch)
        {
            this.ModerateExerciseReduction = floater.ModerateExerciseReduction;
            this.VigorousExerciseReduction = floater.VigorousExerciseReduction;
            this.IncreaseInRisk = floater.IncreaseInRisk;
            this.WeightLossReduction = floater.WeightLossReduction;
            this.WeightLossRequired = floater.WeightLossRequired;
            this.SmokingReduction = floater.SmokingReduction;
            this.AllReductions = floater.AllReductions;
            this.MedicationReduction = floater.MedicationReduction;
            this.DoctorRecommendation = OtherArch.DoctorRecommendation;
            this.ElevatedBloodPressure = OtherArch.ElevatedBloodPressure;
            this.ElevatedCholesterol = OtherArch.ElevatedCholesterol;
            this.Recommendation = OtherArch.Recommendation;
            this.WarningCode = OtherArch.WarningCode;
        }
    }
}
