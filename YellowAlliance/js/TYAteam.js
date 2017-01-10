/*
 * The Yellow Alliance v0.1
 * Copyright 2016 The Fera Group and FRC 503 Frog Force 
 *
*/

$(document).ready(function () {
    
    //refresh the list of teams for a user to select
    refreshteamlist();

    //setup an event handler for the user selecting a different event
    $('#teamsel').change(function () {
        refreshteam();
    //    refreshrankingtable();
    });

});  // End of Document Ready function

function refreshteamlist() {
    //
    //*******************************************
    /* Get Team List 
    /********************************************/
    var uri = "api/Team/GetTeamList";
    showrefreshbtn("#gtbtn", "Refreshing...");

    $.getJSON(uri, function (data) {
        $('#teamsel').empty();
        $.each(data, function (key, item) {
            var newOption = $('<option value="' + item.TeamNumber + '">' + item.TeamNumber + '-' + item.TeamNameShort + '</option>');
            $('#teamsel').append(newOption);
        });

        //test if URL contains passed ID - if so we want to use it 
        var id = getURLParameters("ID");
        if (typeof id !== "undefined" && id !== "No Parameters Found") {
            var select = document.getElementById("teamsel");
            for (var i = 0; i < select.options.length; i++) {
                if (select.options[i].value === id) {
                    select.options[i].selected = true;
                }
            }
        }
        hiderefreshbtn("#gtbtn", "Done");
        $('#teamsel').trigger("change");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        msgbox(-1, "RefreshteamList Failed!", 'Error Occurred: ' + jqXHR.responseText);
        hiderefreshbtn("#gtbtn", "Done");
    });
}

function refreshteam() {
    showrefreshbtn("#gtbtn", "Refreshing...");

    var tables = $.fn.dataTable.fnTables(true);
    $(tables).each(function () {
        $(this).dataTable().fnDestroy();
    });
   
    $('#match-container').empty();



    //Get selected team number from dropdown 
    var saveqid = $('#teamsel').val();
    var uri = "api/TYA/GetTeamDetails/"+saveqid;
    var tableData = [];

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            //tableData.push(formatrow(item));
            document.getElementById("tno").value = item.TeamNumber;
            document.getElementById("tname").value = item.TeamNameLong;
            document.getElementById("tschool").value = item.SchoolName;
            document.getElementById("tcity").value = item.City;
            document.getElementById("tstate").value = item.StateProv;
        });
        // refresh the match history 
        refreshmatchhistory();
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Refreshing Team!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
} // End refreshtable

function refreshmatchhistory() {
    showrefreshbtn("#gtbtn", "Refreshing...");
    //Get selected team number from dropdown 
    var saveqid = $('#teamsel').val();
    var uri = "api/TYA/GetMatchHistory/" + saveqid;
    var tableData = [];
    $.getJSON(uri, function (data) {
       var lastEventID = 0;
        $.each(data, function (key, item) {
            //if this is a change in event go intialize a new table 
            if (item.EventID !== lastEventID) {
                initMatchWidget(item.EventID);
                lastEventID = item.EventID;
                refresheventinfo(item.EventID);
            } 
            //add match row to table 
            var tableData = [];
            var tn = "#match-history-" + item.EventID;
            tableData.push(formatrow(item));
            var t = $(tn).DataTable();
            t.rows.add(tableData).draw();
        });
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Refreshing Team!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
}

function initMatchWidget(widname) {
    var widgetcontent = "<table class='table table-bordered'><tbody id='match_event_table-" + widname + "'>";
    widgetcontent += "<tr><td width='200px' id='mhistevent-"+widname+"'></td><td width='400px'>";
    widgetcontent += "<table class='dt-responsive table table-sorting table-striped table-hover datatable' id='match-history-" + widname + "'>";
    widgetcontent += "<tbody id='mhistbody-"+widname+"'></tbody></table></td></tr>"
    widgetcontent += "</tbody></table>";

    $("#match-container").append(widgetcontent);
    //point to the match table that we just defined 
    var tn = "#match-history-" + widname;
    if (!$.fn.dataTable.isDataTable(tn)) {
        var table = $(tn).DataTable({
            //"lengthMenu": [[5, 15, 25, -1], [5, 15, 25, "All"]],
            //dom: 'T<"clear">lfrtip',
            dom: 'tfr',
            "bLengthChange": false,
            "bPaginate": false,
            "bFilter": false,
            "aoColumns": [
                { "sTitle": "Match", "sClass": "TYA-center", "sWidth": "45px" },
                {"sTitle": "Red 1", "sClass": "TYA-center", "sWidth": "40px"},
                {"sTitle": "Red 2", "sClass": "TYA-center", "sWidth": "40px"},
                {"sTitle": "Red 3", "sClass": "TYA-center", "sWidth": "40px"},
                {"sTitle": "Blue 1", "sClass": "TYA-center", "sWidth": "40px"},
                {"sTitle": "Blue 2", "sClass": "TYA-center", "sWidth": "40px"},
                {"sTitle": "Blue 3", "sClass": "TYA-center", "sWidth": "40px"},
                {"sTitle": "Red Score", "sClass": "TYA-right", "sWidth": "55px"},
                {"sTitle": "Blue Score", "sClass": "TYA-right", "sWidth": "60px"}
            ]
        })
    }  // end if 


}

function refresheventinfo(eventid) {
    var uri = "api/TYA/GetEventbyID/" + eventid;
    var tableData = [];
    var info = "";
    var parseDate = d3.timeParse("%Y-%m-%dT%H:%M:%S");
    var formatDate = d3.timeFormat("%B %d, %Y"); 
    var formatDate2 = d3.timeFormat("%B %d");

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            info += "<h3>" + item.EventDescription + "</h3>";
            info += "<h5>In " + item.City + ", " + item.State + ", " + item.Country + "</h5>";
            var sd = parseDate(item.StartDate);
            var ed = parseDate(item.EndDate);
            info += "<h6>" + formatDate2(sd) + " - " + formatDate(ed) + "</h6><br>";
        });
        // GO REFRESH TABLE ENTRY FOR THE EVENT 
        var cname = "#mhistevent-" + eventid;
        $(cname).append(info);
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Refreshing Team!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 

   
}




function formatrow(item) {
    return [item.MatchName, item.RedTeamID1, item.RedTeamID2, item.RedTeamID3, item.BlueTeamID1, item.BlueTeamID2, item.BlueTeamID3,item.RedScore, item.BlueScore];
}