using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.Security.Application;
using System.IO;
using System.Text;



namespace MightyHeartsTest.Code
{
    public partial class MightyHeartsAPI
    {
        public MightyHeartsAPI()
        {

        }

        public ArchimedesResponseHelper sendArchimedesDataFull(ArchimedesPostHelper ArchObj)
        {
            //Remember that ArchimedesHelper helper classes default many fields. Handle the way you want to handle nulls and defaults before passing through to Full.
            var url = "https://demo-indigo4health.archimedesmodel.com/IndiGO4Health/IndiGO4Health";
            var postdata = 
                "age=" + ArchObj.age +
                "&gender=" + ArchObj.gender + "&height= " + ArchObj.height +
                "&weight=" + ArchObj.weight + "&smoker=" + ArchObj.smoker +
                "&mi=" + ArchObj.mi + "&stroke=" + ArchObj.stroke +
                "&diabetes=" + ArchObj.diabetes + "&systolic=" + ArchObj.systolic +
                "&diastolic=" + ArchObj.diastolic + "&cholesterol=" + ArchObj.cholesterol +
                "&hdl=" + ArchObj.hdl + "&ldl=" + ArchObj.ldl +
                "&triglycerides=" + ArchObj.triglycerides + "&hba1c=" + ArchObj.hba1c +
                "&cholesterolmeds=" + ArchObj.cholesterolmeds + "&bloodpressuremeds=" + ArchObj.bloodpressuremeds +
                "&bloodpressuremedcount=" + ArchObj.bloodpressuremedcount + "&aspirin=" + ArchObj.aspirin +
                "&moderateexercise=" + ArchObj.moderateexercise + "&vigorousexercise=" + ArchObj.vigorousexercise +
                "&familyhistory=" + ArchObj.familymihistory;

            try
            {
                //Create the Request

                var request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                byte[] byteArray = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Write the Request to a string

                    var mem = new MemoryStream();
                    var responseStream = response.GetResponseStream();

                    var buffer = new Byte[2048];
                    int count = responseStream.Read(buffer, 0, buffer.Length);

                    while (count > 0)
                    {
                        mem.Write(buffer, 0, count);
                        count = responseStream.Read(buffer, 0, buffer.Length);
                    }
                    responseStream.Close();
                    mem.Close();
                    

                    var responseArray = mem.ToArray();
                    var encoding = new System.Text.UTF8Encoding();

                    //Write to a variable

                    var json = encoding.GetString(responseArray);

                    //Parse into JSON

                    JObject obj = JObject.Parse(json);
                    var archRisk = new Interventions((float)obj["Interventions"]["IncreaseInRisk"], (float)obj["Interventions"]["PercentReductionInRiskWithAdditionalModerateExercise"], (float)obj["Interventions"]["PercentReductionInRiskWithAdditionalVigorousExercise"], (float)obj["Interventions"]["PercentReductionInRiskWithWeightLoss"], (float)obj["Interventions"]["PercentReductionInRiskWithMedication"], (float)obj["Interventions"]["PercentReductionWithSmokingCessation"], (float)obj["Interventions"]["PercentReductionWithAllInterventions"], (float)obj["Interventions"]["PoundsOfWeightLossRequired"]);
                    
                    //From the API Documentation, it seems that the API in production mode will either return Risk comparisons or not. Non-production API doesn't do this, but let's build for this future. 
                    
                    
                    if (obj["Risk"] != null)
                    {

                        var CRisk = new CVDRisk((float)obj["Risk"][0]["comparisonRisk"], (float)obj["Risk"][0]["rating"], (float)obj["Risk"][0]["ratingForAge"], (float)obj["Risk"][0]["risk"], (float)obj["Risk"][0]["riskPercentile"]);
                        var HRisk = new HighCVDRisk((float)obj["Risk"][1]["comparisonRisk"], (float)obj["Risk"][1]["rating"], (float)obj["Risk"][1]["ratingForAge"], (float)obj["Risk"][1]["risk"], (float)obj["Risk"][1]["riskPercentile"]);
                        var LRisk = new LowCVDRisk((float)obj["Risk"][2]["comparisonRisk"], (float)obj["Risk"][2]["rating"], (float)obj["Risk"][2]["ratingForAge"], (float)obj["Risk"][2]["risk"], (float)obj["Risk"][2]["riskPercentile"]);
                        var other = new OtherArchInfo((Boolean)obj["ElevatedBloodPressure"], (Boolean)obj["ElevatedCholesterol"], (float)obj["WarningCode"], (float)obj["Recommendation"], (float)obj["DoctorRecommendation"]);
                        var archResponse = new ArchimedesResponseHelper(archRisk, CRisk, HRisk, LRisk, other);
                        return archResponse;
                    }
                    else
                    {
                        var other = new OtherArchInfo((Boolean)obj["ElevatedBloodPressure"], (Boolean)obj["ElevatedCholesterol"], (float)obj["WarningCode"], (float)obj["Recommendation"], (float)obj["DoctorRecommendation"]);
                        var archResponse = new ArchimedesResponseHelper(archRisk, other);
                        return archResponse;
                    }



                }
                else
                {
                    throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
        }

    }
    
}