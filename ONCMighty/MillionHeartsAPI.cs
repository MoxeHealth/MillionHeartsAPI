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



namespace MillionHeartsAPI
{
    //NAME: MillionHeartsAPI
    //AUTHOR: Mark Olschesky
    //PURPOSE: Contains the classes to make API calls needed for the Million Hearts Challenge, sponsored by ONC.
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
    public partial class MillionHeartsAPI
    {
        public MillionHeartsAPI()
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

        public SurescriptsResponseHelper closestSurescriptsPharmacy(string apiKey, float lat, float lon, int radius)
        {
            var url = "https://millionhearts.surescripts.net/test/Provider/Find";
            var postdata = "apikey=" + apiKey + "&lat=" + lat.ToString() +
                           "&lon=" + lon.ToString() + "&radius=" + radius.ToString()
                           + "&maxResults=1";
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

                    return new SurescriptsResponseHelper((string)obj["address1"],
                    (string)obj["city"],
                    (string)obj["description"],
                   (float)obj["distance"],
                   (float)obj["lat"],
                    (float)obj["lon"],
                    (string)obj["name"],
                   (string)obj["phone"],
                    (Boolean)obj["precise"],
                    (string)obj["state"],
                    (string)obj["url"],
                    (string)obj["urlCaption"],
                    (string)obj["zip"],
                    (string)obj["crossStreet"],
                    (string)obj["address2"]);

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
    

