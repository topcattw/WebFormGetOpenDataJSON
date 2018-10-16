<%@ Page Language="VB" AutoEventWireup="false" CodeFile="tWeather.aspx.vb" Inherits="Weather_tWeather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblErr" runat="server" Text=""></asp:Label>
            <hr />
            <asp:Button ID="btnGetData" runat="server" Text="取得資料" />
            <hr />
            資料總筆數：<asp:Label ID="lblCnt" runat="server" Text=""></asp:Label><br />
            地區：
            <asp:DropDownList ID="ddlSiteName" runat="server" DataSourceID="odsSiteName" DataTextField="SiteName" DataValueField="SiteName" AutoPostBack="True">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odsSiteName" runat="server" SelectMethod="GetDistinctSiteName" TypeName="WeatherDao">
            </asp:ObjectDataSource>
            <br />
            <div id="divRecently" runat="server">
                <hr />
                最新天氣狀況：
                <br />地點：<asp:Label ID="lblSiteName" runat="server" Text=""></asp:Label>
                <br />風向：<asp:Label ID="lblWindDirection" runat="server" Text=""></asp:Label>
                <br />風力：<asp:Label ID="lblWindPower" runat="server" Text=""></asp:Label>
                <br />可見度：<asp:Label ID="lblVisibility" runat="server" Text=""></asp:Label>
                <br />溫度：<asp:Label ID="lblTemperature" runat="server" Text=""></asp:Label>
                <br />濕度：<asp:Label ID="lblMoisture" runat="server" Text=""></asp:Label>
                <br />氣壓：<asp:Label ID="lblAtmosphericPressure" runat="server" Text=""></asp:Label>
                <br />天氣描述：<asp:Label ID="lblWeather" runat="server" Text=""></asp:Label>
                <br />單日雨量：<asp:Label ID="lblRainfall1day" runat="server" Text=""></asp:Label>
                <br />資料時間：<asp:Label ID="lblDataCreationDate" runat="server" Text=""></asp:Label>
                <hr />
            </div>
            
            <asp:GridView ID="gvWs" runat="server" DataSourceID="odsWs" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SiteName" HeaderText="地點" SortExpression="SiteName" />
                    <asp:BoundField DataField="WindDirection" HeaderText="風向" SortExpression="WindDirection" />
                    <asp:BoundField DataField="WindPower" HeaderText="風力" SortExpression="WindPower" />
                    <asp:BoundField DataField="Visibility" HeaderText="可見度" SortExpression="Visibility" />
                    <asp:BoundField DataField="Temperature" HeaderText="溫度" SortExpression="Temperature" />
                    <asp:BoundField DataField="Moisture" HeaderText="濕度" SortExpression="Moisture" />
                    <asp:BoundField DataField="AtmosphericPressure" HeaderText="氣壓" SortExpression="AtmosphericPressure" />
                    <asp:BoundField DataField="Weather" HeaderText="天氣描述" SortExpression="Weather" />
                    <asp:BoundField DataField="Rainfall1day" HeaderText="單日雨量" SortExpression="Rainfall1day" />
                    <asp:BoundField DataField="Unit" HeaderText="資料單位" SortExpression="Unit" />
                    <asp:BoundField DataField="DataCreationDate" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" HeaderText="資料時間" SortExpression="DataCreationDate" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsWs" runat="server" SelectMethod="GetWeatherBySiteName" TypeName="WeatherDao">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlSiteName" Name="SiteName" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
        </div>
    </form>
</body>
</html>
