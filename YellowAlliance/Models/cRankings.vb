'----------------------------------------------------------------------
'Class Name:    cRankings 
'Author:        Keith Moore     
'Date:          November 2016 
'Purpose:       This object provides data services for the Rankings table 
'               in the Yellow Alliance Web Application
'-----------------------------------------------------------------------
Public Class cRankings
    ' Locale Variables 
    Private m_RankID As Integer
    Private m_TeamNumber As Long
    Private m_TeamName As String
    Private m_QualificationPoints As Integer
    Private m_RankingPoints As Integer
    Private m_HighestPoints As Integer
    Private m_MatchCount As Integer

    '-------------------------------------------------------------------
    'Properties 
    '-------------------------------------------------------------------

    Public Property RankID As Integer
        Get
            Return m_RankID
        End Get
        Set(value As Integer)
            m_RankID = value
        End Set
    End Property
    Public Property TeamNumber As Long
        Get
            Return m_TeamNumber
        End Get
        Set(value As Long)
            m_TeamNumber = value
        End Set
    End Property
    Public Property TeamName As String
        Get
            Return m_TeamName
        End Get
        Set(value As String)
            m_TeamName = value
        End Set
    End Property
    Public Property QualificationPoints As Integer
        Get
            Return m_QualificationPoints
        End Get
        Set(value As Integer)
            m_QualificationPoints = value
        End Set
    End Property
    Public Property RankingPoints As Integer
        Get
            Return m_RankingPoints
        End Get
        Set(value As Integer)
            m_RankingPoints = value
        End Set
    End Property
    Public Property HighestPoints As Integer
        Get
            Return m_HighestPoints
        End Get
        Set(value As Integer)
            m_HighestPoints = value
        End Set
    End Property
    Public Property MatchCount As Integer
        Get
            Return m_MatchCount
        End Get
        Set(value As Integer)
            m_MatchCount = value
        End Set
    End Property

End Class