<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="Facebook1.aspx.cs" Inherits="WhereMyFriendsAt.Views.Test.Facebook1" %>

<%@ Register Assembly="facebook.web" Namespace="facebook.web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="http://code.jquery.com/jquery-latest.js" type="text/javascript"></script>

    <script src="http://maps.google.com/maps?file=api&amp;v=2.140&amp;key=ABQIAAAAwROTpWdVzJB01-DGrse6FRTAM0IlodCH2frsiouOajZcGKXT4xQIonFbZ5X-ImDuaI317mpORK6L_g"
        type="text/javascript"></script>

    <script src="http://www.roderickcg.com/heatmap/scripts/HeatMap.js" type="text/javascript"></script>
    
        <script type="text/javascript">
        $(document).ready(function() {
            HeatMap.Settings.ShowTileBorder = false;
            HeatMap.Settings.ShowMarkers = false;
            HeatMap.Settings.DebugMode = false;
            HeatMap.Settings.DefaultZoom = 3;
            HeatMap.Initialize("map");

            var points = [];

//            for (var i = 0; i < 75; i++) {
//                var x = 30 + Math.random();
//                var y = -109 - Math.random();
//                points.push(new HeatMapPoint(x, y));
//            }
//            HeatMap.AddHeatMapPointArray(points);
<% foreach (var user in ViewData.Model) { %>
    <%= string.Format("HeatMap.AddAddress('{0}, {1}')", user.current_location.city, user.current_location.state) %>
<% } %>
            HeatMap.ApplyHeatMap(SetMyCenter);

        });
        function SetMyCenter() {
            HeatMap.GoogleMap().setCenter(HeatMap.GetHeatMapCenter(), HeatMap.Settings.DefaultZoom);
            alert('set center');
        }
    </script>
    
        <div id="map" style="width: 600px; height: 500px">
    </div>
    
    <form id="form1" runat="server">
    <table>
    
        <% WhereMyFriendsAt.Extensions.HtmlHelperExtensions.Repeater<facebook.Schema.user>(Html, ViewData.Model, "row", "row-alt", (user, css) =>
           { %>
        <tr class="<%= css %>">
            <td>
                <%= 
                    string.Format(
                        "{0} {1} is from {2}, {3} and is in {4}, {5}"
                        , user.first_name 
                        , user.last_name 
                        , user.hometown_location.city
                        , user.hometown_location.state
                        , user.current_location.city
                        , user.current_location.state
                    )
               %>
            </td>
        </tr>
        <% }); %>
    </table>
    </form>
</asp:Content>
