Imports System.Net.Http
Imports Newtonsoft.Json

Partial Class Weather_tWeather
    Inherits System.Web.UI.Page

    '宣告物件集合，用以存放取得的資料
    Dim oWs As List(Of WeatherInfo)

    Protected Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click

        '宣告HttpClient
        Dim Client As New HttpClient
        '設定連結的網址
        Dim UriWeather As String = "https://opendata.epa.gov.tw/ws/Data/ATM00698/?$format=json"
        '取得資料，傳給response(HttpResponseMessage)
        Dim response As HttpResponseMessage = Client.GetAsync(UriWeather).Result
        '取得JSON的字串
        Dim jsonWs As String = response.Content.ReadAsStringAsync.Result.ToString
        '透過JsonConvert.DeserializeObject 將 JSON字串 轉成物件集合
        oWs = JsonConvert.DeserializeObject(Of List(Of WeatherInfo))(jsonWs)
        Session("oWs") = oWs
        BindData()


    End Sub

    Private Sub Weather_tWeather_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.lblErr.Text = ""
        Me.lblCnt.Text = ""

        '從Session取回物件集合
        oWs = Session("oWs")
        '如果取得的內容是空的，就先增物件集合，並放回Session
        If oWs Is Nothing Then
            oWs = New List(Of WeatherInfo)
            Session("oWs") = oWs
        End If
    End Sub


    Private Sub BindData()
        Me.lblCnt.Text = oWs.Count.ToString()
        Me.ddlSiteName.DataBind()
        Me.gvWs.DataBind()
        divRecentlyDataBind()
    End Sub

    Private Sub divRecentlyDataBind()
        Dim dao As New WeatherDao
        Dim oW As WeatherInfo = dao.GetMaxWeatherBySiteName(Me.ddlSiteName.SelectedValue)
        If oW.SiteName <> "" Then
            divRecentlyInit()
            lblAtmosphericPressure.Text = oW.AtmosphericPressure
            lblDataCreationDate.Text = oW.DataCreationDate
            lblMoisture.Text = oW.Moisture
            lblRainfall1day.Text = oW.Rainfall1day
            lblSiteName.Text = oW.SiteName
            lblTemperature.Text = oW.Temperature
            lblVisibility.Text = oW.Visibility
            lblWeather.Text = oW.Weather
            lblWindDirection.Text = oW.WindDirection
            lblWindPower.Text = oW.WindPower
        End If
    End Sub

    Private Sub odsSiteName_Selected(sender As Object, e As ObjectDataSourceStatusEventArgs) Handles odsSiteName.Selected
        Dim tLI As New ListItem("請選擇", "")
        Me.ddlSiteName.Items.Insert(0, tLI)
    End Sub

    Private Sub divRecentlyInit()
        Me.lblAtmosphericPressure.Text = ""
        Me.lblDataCreationDate.Text = ""
        Me.lblMoisture.Text = ""
        Me.lblRainfall1day.Text = ""
        Me.lblSiteName.Text = ""
        Me.lblTemperature.Text = ""
        Me.lblVisibility.Text = ""
        Me.lblWeather.Text = ""
        Me.lblWindDirection.Text = ""
        Me.lblWindPower.Text = ""
    End Sub

    Private Sub ddlSiteName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSiteName.SelectedIndexChanged
        divRecentlyDataBind()
    End Sub
End Class
