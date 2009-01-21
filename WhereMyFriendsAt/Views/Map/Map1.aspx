<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Map1.aspx.cs" Inherits="WhereMyFriendsAt.Views.Map.Map1" %>

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
            HeatMap.Initialize("map");

            var points = [];

            for (var i = 0; i < 75; i++) {
                var x = 30 + Math.random();
                var y = -109 - Math.random();
                points.push(new HeatMapPoint(x, y));
            }
            HeatMap.AddHeatMapPointArray(points);
            HeatMap.GoogleMap().setCenter(HeatMap.GetHeatMapCenter(), HeatMap.Settings.DefaultZoom);
            HeatMap.ApplyHeatMap();

        });
    </script>
    
        <div id="map" style="width: 600px; height: 500px">
    </div>
</asp:Content>
