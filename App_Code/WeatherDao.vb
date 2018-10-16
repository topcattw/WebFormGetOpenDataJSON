Imports Microsoft.VisualBasic

Public Class WeatherDao
    ''' <summary>
    ''' 取得地點不重複的資料並傳回
    ''' </summary>
    ''' <returns></returns>
    Public Function GetDistinctSiteName() As List(Of WSiteNameInfo)
        Try
            '宣告回傳的地點物件集合
            Dim oSNs As New List(Of WSiteNameInfo)
            '宣告並從Session取得天氣物件集合
            Dim oWs As List(Of WeatherInfo) = HttpContext.Current.Session("oWs")
            '如果不是空的
            If oWs IsNot Nothing Then
                '而且有值
                If oWs.Count > 0 Then
                    '透過LINQ，取得地點不重複的內容
                    Dim sRlt = From oW As WeatherInfo In oWs
                               Select oW.SiteName Distinct

                    '宣告地點物件
                    Dim tWN As WSiteNameInfo
                    '取得結果逐一讀取出，新增地點物件，並放入回傳的地點物件集合中
                    For Each s As String In sRlt
                        tWN = New WSiteNameInfo
                        tWN.SiteName = s
                        oSNs.Add(tWN)
                    Next
                End If
            End If
            '回傳地點物件集合
            Return oSNs
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 依據傳入的地點，取得相關資料，並傳回符合的物件集合
    ''' </summary>
    ''' <param name="SiteName">地點</param>
    ''' <returns></returns>
    Public Function GetWeatherBySiteName(ByVal SiteName As String) As List(Of WeatherInfo)
        Try
            '宣告條件撈取結果的物件集合
            Dim oRlts As New List(Of WeatherInfo)
            '宣告並從Session取得天氣物件集合
            Dim oWs As List(Of WeatherInfo) = HttpContext.Current.Session("oWs")

            '如果不是空的
            If oWs IsNot Nothing Then
                '如果傳入的地點有資料
                If SiteName <> "" Then
                    '透過LINQ從物件集合撈取符合地點的資料，並轉成LIST集合物件，放入回傳的物件集合
                    oRlts = (From oW As WeatherInfo In oWs
                             Where oW.SiteName = SiteName
                             Select oW).ToList()
                Else
                    '沒有傳入地點，結果就等於是天氣物件集合的全部
                    oRlts = oWs
                End If
            End If

            '回傳結果
            Return oRlts
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 依據傳入的地點，取得該地點，資料時間最大的內容，並傳回物件
    ''' </summary>
    ''' <param name="SiteName">地點</param>
    ''' <returns></returns>
    Public Function GetMaxWeatherBySiteName(ByVal SiteName As String) As WeatherInfo
        Try
            '宣告撈取的結果物件集合
            Dim oRlts As List(Of WeatherInfo)
            '宣告並從Session取得天氣物件集合
            Dim oWs As List(Of WeatherInfo) = HttpContext.Current.Session("oWs")
            '宣告回傳的物件
            Dim oRlt As New WeatherInfo
            '如果天氣集合不是空的
            If oWs IsNot Nothing Then
                '地點資料不是空的
                If SiteName <> "" Then
                    '撈取結果依據地點篩選，並依據日期由大至小排序
                    oRlts = (
                            From oW As WeatherInfo In oWs
                            Where oW.SiteName = SiteName
                            Select oW
                            Order By oW.DataCreationDate Descending
                                 ).ToList()
                    '回傳的結果是撈取結果集合的第一筆（最大）
                    oRlt = oRlts.First()
                End If
            End If

            '回傳結果
            Return oRlt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class


