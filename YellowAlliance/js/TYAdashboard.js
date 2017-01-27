/*
 * The Yellow Alliance v0.1
 * Copyright 2016 The Fera Group and FRC 503 Frog Force 
 *
*/
$(document).ready(function () {
    //
    //*******************************************
    /*  Initialize Match Table
    /********************************************/
    //
    if (!$.fn.dataTable.isDataTable('#match-table')) {
        //Set defaults for page sizes
        var table = $("#matchresult-table").DataTable({
            "lengthMenu": [[15, 25, 50, -1], [15, 25, 50, "All"]],
            "aoColumns": [
            { "sTitle": "Match ID", "sClass": "TYA-center", "sWidth": "70px" },
            { "sTitle": "Match Name", "sClass": "TYA-center", "sWidth": "120px" },
            { "sTitle": "Result", "sClass": "TYA-center", "sWidth": "150px" },
            { "sTitle": "Red 1", "sClass": "TYA-center", "sWidth": "100px" },
            { "sTitle": "Red 2", "sClass": "TYA-center", "sWidth": "100px" },
            { "sTitle": "Red 3", "sClass": "TYA-center", "sWidth": "100px" },
            { "sTitle": "Blue 1", "sClass": "TYA-center", "sWidth": "100px" },
            { "sTitle": "Blue 2", "sClass": "TYA-center", "sWidth": "100px" },
            { "sTitle": "Blue 3", "sClass": "TYA-center", "sWidth": "100px" }
            ],
        }); //end data table 

        refreshmatchtable(); 

        //Setup callback function is row on table is clicked
        $('#matchresult-table tbody').on('click', 'tr', function () {
            var aData = table.row(this).data();
            TableitemSelected(aData);
        });

        //refresh the list of events for a user to select
        refresheventlist();
    } // end if

   //
   //*******************************************
   /*  Initialize Rank Table
   /********************************************/
   //
    if (!$.fn.dataTable.isDataTable('#ranking-table')) {
        //Set defaults for page sizes
        var table = $("#ranking-table").DataTable({
            "lengthMenu": [[15, 25, 50, -1], [15, 25, 50, "All"]],
            "aoColumns": [
            { "sTitle": "Rank", "sClass": "TYA-center", "sWidth": "70px" },
            { "sTitle": "Team No", "sClass": "TYA-center", "sWidth": "70px" },
            { "sTitle": "Team Name", "sClass": "TYA-center", "sWidth": "200px" },
            { "sTitle": "Qualification Points", "sClass": "TYA-center", "sWidth": "100px" },
            { "sTitle": "Ranking Points", "sClass": "TYA-center", "sWidth": "80px" },
            { "sTitle": "High Score", "sClass": "TYA-center", "sWidth": "80px" },
            { "sTitle": "Matches", "sClass": "TYA-center", "sWidth": "80px" }
            ],
        }); //end data table 

        refreshrankingtable();

        //Setup callback function is row on table is clicked
        $('#ranking-table tbody').on('click', 'tr', function () {
            var aData = table.row(this).data();
            RankingitemSelected(aData);
        });
    } // end if

    //
    //*******************************************
    /*  Initialize Team Table
    /********************************************/
    //
    if (!$.fn.dataTable.isDataTable('#teams-table')) {
        //Set defaults for page sizes
        var table = $("#teams-table").DataTable({
            "lengthMenu": [[15, 25, 50, -1], [15, 25, 50, "All"]],
            "aoColumns": [
            { "sTitle": "Team No", "sClass": "TYA-left", "sWidth": "70px" },
            { "sTitle": "Name", "sClass": "TYA-left", "sWidth": "280px" },
            { "sTitle": "School/Affiliation", "sClass": "TYA-left" },
            { "sTitle": "City", "sClass": "TYA-left", "sWidth": "100px" },
            { "sTitle": "State", "sClass": "TYA-left", "sWidth": "50px" }
            ],
        });
 
        refreshteams();

        //Setup callback function is row on table is clicked
        $('#teams-table tbody').on('click', 'tr', function () {
            var aData = table.row(this).data();
            teamSelected(aData);
        });
    } // end if

    //
    //*******************************************
    /*  Initialize Awards Table
    /********************************************/
    //
    if (!$.fn.dataTable.isDataTable('#awards-table')) {
        //Set defaults for page sizes
        var table = $("#awards-table").DataTable({
            "lengthMenu": [[15, 25, 50, -1], [15, 25, 50, "All"]],
            "aoColumns": [
            { "sTitle": "ID", "sClass": "TYA-left", "sWidth": "40px" },
            { "sTitle": "Name", "sClass": "TYA-left", "sWidth": "120px" },
            { "sTitle": "Description", "sClass": "TYA-left"},
            { "sTitle": "Team 1", "sClass": "TYA-left", "sWidth": "120px"  },
            { "sTitle": "Team 2", "sClass": "TYA-left", "sWidth": "120px" },
            { "sTitle": "Team 3", "sClass": "TYA-left", "sWidth": "120px" }
            ],
        });
 
        refreshawards();

        //Setup callback function is row on table is clicked
        $('#awards-table tbody').on('click', 'tr', function () {
            var aData = table.row(this).data();
            awardSelected(aData);
        });
    } // end if

  //setup an event handler for the user selecting a different event
    $('#eventsel').change(function () {
        refreshmatchtable();
        refreshrankingtable();
        refreshteams();
        refreshawards();
    });

});  // End of Document Ready function


function refresheventlist() {
    //
    //*******************************************
    /* Get Event List 
    /********************************************/
    var uri = "api/TYA/GetEventList";
    showrefreshbtn("#gtbtn", "Refreshing...");

    $.getJSON(uri, function (data) {
        $('#eventsel').empty();
        $.each(data, function (key, item) {
            var newOption = $('<option value="' + item.EventID + '">' + item.EventDescription + '</option>');
            $('#eventsel').append(newOption);
        });

        //test if URL contains passed ID - if so we want to use it 
        var id = getURLParameters("ID");
        if (typeof id !== "undefined" && id !== "No Parameters Found") {
            var select = document.getElementById("eventsel");
            for (var i = 0; i < select.options.length; i++) {
                if (select.options[i].value === id) {
                    select.options[i].selected = true;
                }
            }
        }


        hiderefreshbtn("#gtbtn", "Done");
        $('#eventsel').trigger("change");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        msgbox(-1, "GetVendorList Failed!", 'Error Occurred: ' + jqXHR.responseText);
        hiderefreshbtn("#gtbtn", "Done");
    });
}

function refreshmatchtable() {
    showrefreshbtn("#gtbtn", "Refreshing...");
    //Get selected event from event dropdown 
    var saveqid = $('#eventsel').val();
    var uri = "api/Team/GetMatchList/"+saveqid;
    var tableData = [];

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            tableData.push(formatrow(item));
        });
        // add row from array to html table
        var t = $("#matchresult-table").DataTable();
        t.clear();
        t.rows.add(tableData).draw();
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Getting Match List!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
}

function formatrow(item) {
    var res = item.RedScore + "-" + item.BlueScore;
    if(item.RedScore > item.BlueScore) {
        res = res + " (Red)";
    } else 
        if (item.BlueScore > item.RedScore) {
        res = res + " (Blue)";
        } else
            if (item.RedScore === item.BlueScore) {
                res = res + " (Tie)";
            }

    var r3 = "";
    var b3 = "";
    if (res === "0-0 (Tie)") { res = "" };
    if (item.RedTeamID3 > 0) { r3 = addLink(item.RedTeamID3) };
    if (item.BlueTeamID3 > 0) { b3 = addLink(item.BlueTeamID3) };

    return [item.MatchID, item.MatchName, res, addLink(item.RedTeamID1),addLink(item.RedTeamID2),r3,addLink(item.BlueTeamID1),addLink(item.BlueTeamID2),b3];
}

function addLink(item) {
    var linkstr = "";
    linkstr = "<a href=\"page-team.html?ID=" + item + "\">" + item + "</a>";
    return linkstr;
}

function refreshrankingtable() {
    showrefreshbtn("#gtbtn", "Refreshing...");
    //Get selected event from event dropdown 
    var saveqid = $('#eventsel').val();
    var uri = "api/Team/GetRankingList/" + saveqid;
    var tableData = [];

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            tableData.push(rankingrow(item));
        });
        // add row from array to html table
        var t = $("#ranking-table").DataTable();
        t.clear();
        t.rows.add(tableData).draw();
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Getting Rank List!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
}

function rankingrow(item) {
    return [item.RankID, item.TeamNumber, item.TeamName, item.QualificationPoints, item.RankingPoints, item.HighestPoints, item.MatchCount];
}

function refreshteams() {
    showrefreshbtn("#gtbtn", "Refreshing...");
    //Get selected event from event dropdown 
    var saveqid = $('#eventsel').val();
    var uri = "api/Team/GetTeamListAtEvent/" + saveqid;
    var tableData = [];

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            tableData.push(formatteamrow(item));
        });
        // add row from array to html table
        var t = $("#teams-table").DataTable();
        t.clear();
        t.rows.add(tableData).draw();
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Getting TeamsAtEvent!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
} // End refreshtable

function formatteamrow(item) {
    return [item.TeamNumber, item.TeamNameLong, item.SchoolName, item.City, item.StateProv];
}

//jump to team table when row is clicked 
function teamSelected(item) {
    window.location.href = "\page-team.html?ID=" + item[0];
}

function refreshawards() {
    showrefreshbtn("#gtbtn", "Refreshing...");
    //Get selected event from event dropdown 
    var saveqid = $('#eventsel').val();
    var uri = "api/TYA/GetAwardListAtEvent/" + saveqid;
    var tableData = [];

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            tableData.push(formatawardrow(item));
        });
        // add row from array to html table
        var t = $("#awards-table").DataTable();
        t.clear();
        t.rows.add(tableData).draw();
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Getting AwardsAtEvent!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
} // End refreshtable

function formatawardrow(item) {
    return [item.AwardID, item.Name, item.Description, item.Team1, item.Team2, item.Team3];
}

//jump to team table when row is clicked 
function awardSelected(item) {
    window.location.href = "\page-team.html?ID=" + item[0];
}



function newrow() {
    //
    //*******************************************
    /* New Vendor Row -clear modal window to enter data
    /********************************************/
    //document.getElementById("vendorid").value = 0;             //Clear vendorurer ID on modal page
    //document.getElementById("vendordesc").value = "";          //clear vendorurer name on modal page
}

function updaterow() {
    //
    //*******************************************
    /* Update Match Schedule Record
    /********************************************/
    var uri = "api/Team/UpdateVendor";

    //go figure out how to get group id
    var g = document.getElementById("vendorid").value;            //get vendor ID from model page
    var d = document.getElementById("vendordesc").value;          //put vendor name on modal page

    var nq = {
        ID: g,
        Description: d
    };

    var testpost = $.post(uri, { "": JSON.stringify(nq) })
    .success(function (data) {
        if (data == 0) {
            msgbox(0, "Update Successful", "Vendor Record Successfully Updated!")
            $('#myModalleaf').modal('toggle');
            refreshvendorlist();
            refreshtable();
        }
        else if (data > 0) {
            msgbox(0, "Add Successful", "New Vendor Record Created!")
            $('#myModalleaf').modal('toggle');
            refreshvendorlist();
            refreshtable();
        }
        else {
            msgbox(-1, "Update Failed!", "Vendor Update Failed!")
        }
    })  //close .success
    // Optional - fires when operation completes with error
    .error(function (data) {
        msgbox(-1, "Update Failed!", "Vendor Update Failed!")
    });
}


function deleterow() {
    //
    //*******************************************
    /* Delete Vendor Record
    /********************************************/
    var uri = "api/Quotes/RemoveVendor";

    //go figure out how to get group id
    var g = document.getElementById("vendorid").value;            //get vendor ID from model page

    var nq = {
        ID: g
    };

    var testpost = $.post(uri, { "": JSON.stringify(nq) })
    .success(function (data) {
        if (data == 0) {
            msgbox(0, "Delete Successful", "Vendor Record Successfully Deleted!")
            $('#myModalleaf').modal('toggle');
            refreshvendorlist();
            refreshtable();
        }
        else if (data > 0) {
            msgbox(0, "Delete Successful", "Vendor Record Successfully Deleted!")
            $('#myModalleaf').modal('toggle');
            refreshvendorlist();
            refreshtable();
        }
        else {
            msgbox(-1, "Delete Failed!", "Vendor Delete Failed!")
        }
    })  //close .success
    // Optional - fires when operation completes with error
    .error(function (data) {
        msgbox(-1, "Delete Failed!", "Vendor Delete Failed!")
    });
}

function addRowWFormat(item) {
    return [item.ID, item.Description];
}

//Show modal window on row click in employee table allowing user to maintain data
function TableitemSelected(item) {
    // document.getElementById("vendorid").value = item[0];            //put vendorurer id on modal page
    //document.getElementById("vendorid").value = $('#vendorselect').val();      //get vendor ID from page
    //document.getElementById("vendordesc").value = item[1];          //put vendorurer name on modal page
    //$('#myModalleaf').modal('show');
}

