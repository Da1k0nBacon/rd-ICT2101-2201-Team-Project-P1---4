var value = 0
function increment(thisID) {
    value = parseInt(document.getElementById(thisID).value) + 1;
    if (value == 4) {
        value = 0;
    }
    if (value == 0) {
        document.getElementById(thisID).style.backgroundColor = "white";
    }
    else if (value == 1) {
        document.getElementById(thisID).style.backgroundColor = "red";
    }
    else if (value == 2) {
        document.getElementById(thisID).style.backgroundColor = "green";
    }
    else if (value == 3) {
        document.getElementById(thisID).style.backgroundColor = "yellow";
    }
    document.getElementById(thisID).value = value.toString();
}
function submit() {
    var jsonList = [];
    jsonList.push({
        'Grid1': document.getElementById("1").value,
        'Grid2': document.getElementById("2").value,
        'Grid3': document.getElementById("3").value,
        'Grid4': document.getElementById("4").value,
        'Grid5': document.getElementById("5").value,
        'Grid6': document.getElementById("6").value,
        'Grid7': document.getElementById("7").value,
        'Grid8': document.getElementById("8").value,
        'Grid9': document.getElementById("9").value,
        'Grid10': document.getElementById("10").value,
        'Grid11': document.getElementById("11").value,
        'Grid12': document.getElementById("12").value,
        'Grid13': document.getElementById("13").value,
        'Grid14': document.getElementById("14").value,
        'Grid15': document.getElementById("15").value,
        'Grid16': document.getElementById("16").value,
    })
    const jsonString = JSON.stringify(jsonList);

    console.log(jsonString);

    $.ajax({
        type: "POST",
        url: 'SendMapData',
        dataType: "json",
        data: { 'mapData': jsonString },
        cache: false,
        success: function (data) {
            alert("Saved to DB");
        },
        failure: function (data) {
            alert("Failed to Save");
        }
    });

}