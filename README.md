This is our Repo for the C# wrapper that we wrote for the Million Hearts Challenge

First:

Include the MillionHeartsAPI dll in your project. This library also relies on JSON.Net and Microsoft's AntiXSS libraries, so the easiest way to do this is to use NuGET to get the package
 
Or, from the Package Manager Console:

    PM> Install-Package MillionHeartsAPI

When we post an update, we'll try to inform you through updates here on GitHub or on our blog at blog.moxehealth.com

How to use the code:

You can initialize the code that you need to make a post sentence in 3 lines of code

1) There's a helper class that contains all of the form values. 

    var archpost = new ArchimedesPostHelper("40", "M", "70", "180", "F", "T", "T", "F", "120", "80", "100", "50", "50", "100", "8.0", "F","F", "2", "F", "1", "1", "F");
 
Only the first 5 values are required. We use default values for the other entries in the system. These are merely placeholders and you should handle exceptions before using this.

2) Create a new MillionHeartsAPI object

    var makepost = new MillionHeartsAPI.MillionHeartsAPI();

3) Use sendArchimedesDataFull to make a POST statement to the API with your post helper as the parameter.

    var post = makepost.sendArchimedesDataFull(archpost);

4) sendArchimedesDataFull returns a ArchimedesResponseHelper object, which contains all of the information from the post, which can be used or transported as needed.

5) Use closestSurescriptsPharmacy to send your calculated lat/long to the Surescripts API. This is the requirements from the Surescripts API. I would recommend using google maps geocoder to handle the geocoding if you don't have a solution in mind.

    var pharm = makepost.closestSurescriptsPharmacy("3a0a572b-4f5d-47a2-9a75-819888576454", (float)44.979965, (float)-93.263836, 2)

6) closestSurescriptsPharmacy returns a SurescriptsResponseHelper, which contains all of the information from the post, which can be used or transported as needed. Address2 and crossStreet are handled as optional fields with a default value of "".
 
There's also a Test MVC3 Website included in the repository that shows this in action. (MightyHeartsTest).


We hope that this helps you on your way. Fork and share in kind. E-mail mark@moxehealth.com if you have any questions with the usage of the classes or for feedback.

License:

MIT License - Please attribute ownership back to the author/source company. You must include the MIT License in all included iterations of the code.

Copyright (c) 2012 Mox eHealth, LLC.
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
