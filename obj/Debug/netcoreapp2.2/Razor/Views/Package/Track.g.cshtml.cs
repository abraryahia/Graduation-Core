#pragma checksum "F:\Project\Core Map\Graduation Core\Views\Package\Track.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "126ae6e167349a700ff8c6fbcfd3c36036dcefc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Package_Track), @"mvc.1.0.view", @"/Views/Package/Track.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Package/Track.cshtml", typeof(AspNetCore.Views_Package_Track))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "F:\Project\Core Map\Graduation Core\Views\_ViewImports.cshtml"
using Graduation_Core;

#line default
#line hidden
#line 2 "F:\Project\Core Map\Graduation Core\Views\_ViewImports.cshtml"
using Graduation_Core.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"126ae6e167349a700ff8c6fbcfd3c36036dcefc0", @"/Views/Package/Track.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8b3662672c334380a63cfa8494ed8337b5d0c11", @"/Views/_ViewImports.cshtml")]
    public class Views_Package_Track : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Graduation_Core.Models.CoordiantesModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("GetMap()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\Project\Core Map\Graduation Core\Views\Package\Track.cshtml"
  
    ViewData["Title"] = "Track";


#line default
#line hidden
            BeginContext(93, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n\r\n");
            EndContext();
            BeginContext(122, 4613, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "126ae6e167349a700ff8c6fbcfd3c36036dcefc05048", async() => {
                BeginContext(128, 2986, true);
                WriteLiteral(@"
    <title>TrackPackage</title>
    <meta charset=""utf-8"" />
    <meta http-equiv=""x-ua-compatible"" content=""IE=Edge"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"" />
    <meta name=""description"" content=""This tutorial shows how to calculate a route and display it on the map."" />
    <meta name=""keywords"" content=""map, gis, API, SDK, services, module, tutorials, routing, directions, route, truck, commercial vehicle"" />
    <meta name=""author"" content=""Microsoft Azure Maps"" />

    <!-- Add references to the Azure Maps Map control JavaScript and CSS files. -->
    <link rel=""stylesheet"" href=""https://atlas.microsoft.com/sdk/javascript/mapcontrol/2/atlas.min.css"" type=""text/css"" />
    <script src=""https://atlas.microsoft.com/sdk/javascript/mapcontrol/2/atlas.min.js""></script>

    <!-- Add a reference to the Azure Maps Services Module JavaScript file. -->
    <script src=""https://atlas.microsoft.com/sdk/javascript/mapcontrol/2/atlas-service.min.js"">");
                WriteLiteral(@"</script>

    <script>
        var map, datasource, client;
        function GetMap() {
            // Instantiate a map object
            var map = new atlas.Map('myMap', {
                //Add your Azure Maps subscription key to the map SDK. Get an Azure Maps key at https://azure.com/maps
                authOptions: {
                    authType: 'subscriptionKey',
                    subscriptionKey: 'qrkBTZt1h2LhYaQqVUeXcZbUUjT1Bm40F9_8sv0fpX0'
                }
            });
            //Wait until the map resources are ready.
            map.events.add('ready', function () {
                //Create a data source and add it to the map.
                datasource = new atlas.source.DataSource();
                map.sources.add(datasource);
                //Add a layer for rendering the route lines and have it render under the map labels.
                map.layers.add(new atlas.layer.LineLayer(datasource, null, {
                    strokeColor: '#2272B9',
                  ");
                WriteLiteral(@"  strokeWidth: 5,
                    lineJoin: 'round',
                    lineCap: 'round'
                }), 'labels');
                //Add a layer for rendering point data.
                map.layers.add(new atlas.layer.SymbolLayer(datasource, null, {
                    iconOptions: {
                        image: ['get', 'icon'],
                        allowOverlap: true
                    },
                    textOptions: {
                        textField: ['get', 'title'],
                        offset: [0, 1.2]
                    },
                    filter: ['any', ['==', ['geometry-type'], 'Point'], ['==', ['geometry-type'], 'MultiPoint']] //Only render Point or MultiPoints in this layer.
                }));
                //Create the GeoJSON objects which represent the start and end points of the route.

            var startPoint = new atlas.data.Feature(new atlas.data.Point([");
                EndContext();
                BeginContext(3115, 11, false);
#line 64 "F:\Project\Core Map\Graduation Core\Views\Package\Track.cshtml"
                                                                     Write(Model.FLong);

#line default
#line hidden
                EndContext();
                BeginContext(3126, 2, true);
                WriteLiteral(", ");
                EndContext();
                BeginContext(3129, 10, false);
#line 64 "F:\Project\Core Map\Graduation Core\Views\Package\Track.cshtml"
                                                                                   Write(Model.FLat);

#line default
#line hidden
                EndContext();
                BeginContext(3139, 125, true);
                WriteLiteral("]), {\r\n                });\r\n                \r\n\r\n                var endPoint = new atlas.data.Feature(new atlas.data.Point([ ");
                EndContext();
                BeginContext(3265, 11, false);
#line 68 "F:\Project\Core Map\Graduation Core\Views\Package\Track.cshtml"
                                                                        Write(Model.TLong);

#line default
#line hidden
                EndContext();
                BeginContext(3276, 3, true);
                WriteLiteral(" , ");
                EndContext();
                BeginContext(3280, 10, false);
#line 68 "F:\Project\Core Map\Graduation Core\Views\Package\Track.cshtml"
                                                                                       Write(Model.TLat);

#line default
#line hidden
                EndContext();
                BeginContext(3290, 1438, true);
                WriteLiteral(@"]), {

                });
                //Add the data to the data source.
                datasource.add([startPoint, endPoint]);
                map.setCamera({
                    bounds: atlas.data.BoundingBox.fromData([startPoint, endPoint]),
                    padding: 80
                });
                // Use SubscriptionKeyCredential with a subscription key
                var subscriptionKeyCredential = new atlas.service.SubscriptionKeyCredential(atlas.getSubscriptionKey());
                // Use subscriptionKeyCredential to create a pipeline
                var pipeline = atlas.service.MapsURL.newPipeline(subscriptionKeyCredential);
                // Construct the RouteURL object
                var routeURL = new atlas.service.RouteURL(pipeline);
                //Start and end point input to the routeURL
                var coordinates = [[startPoint.geometry.coordinates[0], startPoint.geometry.coordinates[1]], [endPoint.geometry.coordinates[0], endPoint.geometry.coordina");
                WriteLiteral(@"tes[1]]];
                //Make a search route request
                routeURL.calculateRouteDirections(atlas.service.Aborter.timeout(10000), coordinates).then((directions) => {
                    //Get data features from response
                    var data = directions.geojson.getFeatures();
                    datasource.add(data);
                });
            });
        }
    </script>
 
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4735, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(4739, 34, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "126ae6e167349a700ff8c6fbcfd3c36036dcefc012523", async() => {
                BeginContext(4764, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4773, 13, true);
            WriteLiteral("\r\n\r\n</html>\r\n");
            EndContext();
            BeginContext(4786, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "126ae6e167349a700ff8c6fbcfd3c36036dcefc013806", async() => {
                BeginContext(4856, 4, true);
                WriteLiteral("Back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4864, 68, true);
            WriteLiteral("\r\n<div onload=\"GetMap()\" id=\"myMap\" class=\"col-lg-8 mx-auto \"></div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Graduation_Core.Models.CoordiantesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
