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
            MatchList = m_cTYAServer.GetMatchList(id)
        Catch ex As Exception
            Dim errmsg = "api/TYA/" & "GetMatchlist failed! Return Code: " & ex.Message.ToString
            Return Content(HttpStatusCode.InternalServerError, errmsg)
        End Try
        Return Ok(MatchList)
    End Function
End Class
