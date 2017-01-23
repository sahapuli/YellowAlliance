Imports System.Net
Imports System.Net.Http
Imports System.Web.Http

Public Class TeamController
    Inherits ApiController

    'api/TYA/GetTeamList
    Public Function GetTeamList() As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GetTeamList 
        'Purpose:   Get list of teams from TYA database 
        'Input:     None 
        'Output:    Returns ActionResult object containing list of cTeam objects 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim TeamList As New List(Of cTeam)

        Try
            TeamList = m_cTYAServer.GetTeams()
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetEvents failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try

        Return Ok(TeamList)
    End Function

    Public Function GetMatchList(ByVal id As String) As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GetMatchList 
        'Purpose:   Get list of matches for a given event  
        'Input:     None 
        'Output:    Returns ActionResult object containing list of cMatchSchedule objects 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim MatchList As New List(Of cMatchSchedule)

        Try
            MatchList = m_cTYAServer.GetMatchList(CLng(id))
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetMatchlist failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try
        Return Ok(MatchList)
    End Function


    Public Function GetRankingList(ByVal id As String) As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GeRankingList 
        'Purpose:   Get list of teams in rank order for given event  
        'Input:     None 
        'Output:    Returns ActionResult object containing list of cRanking objects 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim RankingList As New List(Of cRankings)

        Try
            RankingList = m_cTYAServer.GetRankingList(CLng(id))
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetRankinglist failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try
        Return Ok(RankingList)
    End Function

    Public Function GetTeamListAtEvent(ByVal id As String) As IHttpActionResult
        '---------------------------------------------------------------
        'Function:  GetTeamList 
        'Purpose:   Get list of teams attending a particular event  
        'Input:     Event ID  
        'Output:    Returns ActionResult object containing list of cTeam objects 
        '---------------------------------------------------------------
        Dim m_cTYAServer As New cTYAServer
        Dim TeamList As New List(Of cTeam)

        Try
            TeamList = m_cTYAServer.GetTeamsAtEvent(CLng(id))
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetTeamListatEvent failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try

        Return Ok(TeamList)
    End Function
End Class
