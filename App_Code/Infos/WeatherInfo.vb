Imports Microsoft.VisualBasic

Public Class WeatherInfo
    ''' <summary>
    ''' 地點名稱
    ''' </summary>
    Public Property SiteName As String

    ''' <summary>
    ''' 風向
    ''' </summary>
    Public Property WindDirection As String
    ''' <summary>
    ''' 風力
    ''' </summary>
    Public Property WindPower As String

    Public Property Gust As String

    ''' <summary>
    ''' 能見度
    ''' </summary>
    ''' <returns></returns>
    Public Property Visibility As String

    ''' <summary>
    ''' 溫度
    ''' </summary>
    ''' <returns></returns>
    Public Property Temperature As String

    ''' <summary>
    ''' 濕度
    ''' </summary>
    ''' <returns></returns>
    Public Property Moisture As String

    ''' <summary>
    ''' 氣壓
    ''' </summary>
    ''' <returns></returns>
    Public Property AtmosphericPressure As String

    ''' <summary>
    ''' 天氣描述
    ''' </summary>
    ''' <returns></returns>
    Public Property Weather As String

    ''' <summary>
    ''' 單日雨量
    ''' </summary>
    ''' <returns></returns>
    Public Property Rainfall1day As String

    ''' <summary>
    ''' 單位
    ''' </summary>
    ''' <returns></returns>
    Public Property Unit As String

    ''' <summary>
    ''' 資料時間
    ''' </summary>
    ''' <returns></returns>
    Public Property DataCreationDate As Date
End Class

Public Class WSiteNameInfo
    Public Property SiteName As String = ""
End Class