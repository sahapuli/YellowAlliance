/*
 * The Yellow Alliance v0.1
 * Copyright 2016 The Fera Group and FRC 503 Frog Force 
 *
*/
$(document).ready(function () {
    //
    //*******************************************
    /*  Initialize Team Table
    /********************************************/
    //
    if (!$.fn.dataTable.isDataTable('#team-table')) {
        //Set defaults for page sizes
        var table = $("#team-table").DataTable({
            "lengthMenu": [[15, 25, 50, -1], [15, 25, 50, "All"]],
            "aoColumns": [
            { "sTitle": "Team No", "sClass": "TYA-left", "sWidth": "70px" },
            { "sTitle": "Name", "sClass": "TYA-left", "sWidth": "280px" },
            { "sTitle": "School/Affiliation", "sClass": "TYA-left"},
            { "sTitle": "City", "sClass": "TYA-left", "sWidth": "100px" },
            { "sTitle": "State", "sClass": "TYA-left", "sWidth": "50px" }
            ],
        });

        refreshteams();

        //Setup callback function is row on table is clicked
        $('#team-table tbody').on('click', 'tr', function () {
            var aData = table.row(this).data();
            TableitemSelected(aData);
        });
    }
});  // End of Document Ready function

 
function refreshteams() {
    showrefreshbtn("#gtbtn", "Refreshing...");
    var uri = "api/Team/GetTeamList";
    var tableData = [];

    $.getJSON(uri, function (data) {
        $.each(data, function (key, item) {
            tableData.push(formatrow(item));
        });
        // add row from array to html table
        var t = $("#team-table").DataTable();
        t.clear();
        t.rows.add(tableData).draw();
        hiderefreshbtn("#gtbtn", "Done");
    }) // End Json Call 
    // Optional - fires when operation completes with error
    .error(function (jqXHR, textStatus, errorThrown) {
        ErrorMsgBox("Error Getting Teams!", jqXHR.responseJSON.Message, jqXHR.status);
        hiderefreshbtn("#gtbtn", "Done");
    }); // end of JSON Error 
} // End refreshtable

function formatrow(item) {
    return [item.TeamNumber, item.TeamNameLong, item.SchoolName, item.City, item.StateProv];
}

//jump to team table when row is clicked 
function TableitemSelected(item) {
    window.location.href = "\page-team.html?ID="+ item[0];
}

function addLink(item) {
    var linkstr = "";
    linkstr = "<a href=\"page-team.html?ID=" + item + "\">" + item + "</a>";
    return linkstr;
}
