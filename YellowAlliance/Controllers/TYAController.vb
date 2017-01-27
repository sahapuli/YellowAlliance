Imports System.Net
Imports System.Web.Http

Public Class TYAController
        Inherits ApiController

    Public Function GetEventList() As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GetEventList 
        'Purpose:   Get list of events from TYA database 
        'Input:     None 
        'Output:    Returns ActionResult object containing list of cEvent objects 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim EventList As New List(Of cEvent)

        Try
            EventList = m_cTYAServer.GetEvents()
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetEvents failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try

        Return Ok(EventList)
    End Function

    Public Function GetEventbyID(ByVal id As String) As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GetEventByID 
        'Purpose:   Get event information for a given event  
        'Input:     None 
        'Output:    Returns ActionResult object containing list of cEvent objects 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim EventList As New List(Of cEvent)

        Try
            EventList = m_cTYAServer.GetEventbyID(CLng(id))
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetEventbyID failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try

        Return Ok(EventList)
    End Function

    Public Function GetTeamDetails(ByVal id As String) As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GeTeamDetails
        'Purpose:   Get information for a specific team   
        'Input:     None 
        'Output:    Returns ActionResult object containing cTeam object 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim TeamDetailList As New List(Of cTeam)

        Try
            TeamDetailList = m_cTYAServer.GetTeambyTeamNumber(CLng(id))
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetTeamInfo failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try
        Return Ok(TeamDetailList)
    End Function

    Public Function GetMatchHistory(ByVal id As String) As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GetMatchHistory
        'Purpose:   Get Match History information for a specific team   
        'Input:     team number  
        'Output:    Returns ActionResult object containing cMatchSchedule object 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim MatchList As New List(Of cMatchSchedule)

        Try
            MatchList = m_cTYAServer.GetMatchHistory(CLng(id))
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetMatchHistory failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try
        Return Ok(MatchList)
    End Function
    Public Function GetAwardListAtEvent(ByVal id As String) As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GetAwardList 
        'Purpose:   Get list of awards at a particular event  
        'Input:     Event ID  
        'Output:    Returns ActionResult object containing list of cAward objects 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim AwardList As New List(Of cAward)

        Try
            AwardList = m_cTYAServer.GetAwardsAtEvent(CLng(id))
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetAwardListatEvent failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try

        Return Ok(AwardList)
    End Function
End Class