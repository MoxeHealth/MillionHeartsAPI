using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//NAME: ArchimedesHelper
//AUTHOR: Mark Olschesky
//PURPOSE: A helper class for storing the items needed for Archimedes API calls.
//COPYRIGHT STUFF: MIT License - Please attribute ownership back to the author/source company. You must include the MIT License in all included iterations of the code.
/*
Copyright (c) 2012 Mox eHealth, LLC.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. */


namespace MillionHeartsAPI
{
    public class ArchimedesPostHelper
    {
        public string age { get; set; }
        public string gender { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string smoker { get; set; }
        public string mi { get; set; }
        public string stroke { get; set; }
        public string diabetes { get; set; }
        public string systolic { get; set; }
        public string diastolic { get; set; }
        public string cholesterol { get; set; }
        public string hdl { get; set; }
        public string ldl { get; set; }
        public string triglycerides { get; set; }
        public string hba1c { get; set; }
        public string cholesterolmeds { get; set; }
        public string bloodpressuremeds { get; set; }
        public string bloodpressuremedcount { get; set; }
        public string aspirin { get; set; }
        public string moderateexercise { get; set; }
        public string vigorousexercise { get; set; }
        public string familymihistory { get; set; }
        public ArchimedesPostHelper()
        {

        }
        //All fields that you could send to Archimedes. Uses C# Optional Parameters for Optional Fields in the API. 
        //Use named parameters to customize your usage of the function if desired. See here for  http://msdn.microsoft.com/en-us/library/dd264739.aspx
        //Since we concatenate the string, remember to cast your ints and floats
        public ArchimedesPostHelper(string age, string gender, string height, string weight, string smoker, string mi, string stroke, string diabetes, string systolic = "0", string diastolic = "0", string cholesterol = "0", string hdl = "0", string ldl = "0", string triglycerides = "0", string hba1c = "0", string cholesterolmeds = "F", string bloodpressuremeds = "F", string bloodpressuremedcount = "0", string aspirin = "F", string moderateexercise = "0", string vigorousexercise = "0", string familymihistory = "F")
        {
            this.age = age;
            this.gender = gender;
            this.height = height;
            this.weight = weight;
            this.smoker = smoker;
            this.mi = mi;
            this.stroke = stroke;
            this.diabetes = diabetes;
            this.systolic = systolic;
            this.diastolic = diastolic;
            this.cholesterol = cholesterol;
            this.hdl = hdl;
            this.ldl = ldl;
            this.triglycerides = triglycerides;
            this.hba1c = hba1c;
            this.cholesterolmeds = cholesterolmeds;
            this.bloodpressuremeds = bloodpressuremeds;
            this.bloodpressuremedcount = bloodpressuremedcount;
            this.aspirin = aspirin;
            this.moderateexercise = moderateexercise;
            this.vigorousexercise = vigorousexercise;
            this.familymihistory = familymihistory;
        }
        //Just the required fields, if you'd rather use it this way or if you're not using C# 2010.
        public ArchimedesPostHelper(string age, string gender, string height, string weight, string smoker, string mi, string stroke, string diabetes)
        {
            this.age = age;
            this.gender = gender;
            this.height = height;
            this.weight = weight;
            this.smoker = smoker;
            this.mi = mi;
            this.stroke = stroke;
            this.diabetes = diabetes;
        }
    }
}
