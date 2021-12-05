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
    var map = new Array();
    for (var i = 1; i < 16; i++) {
        map[i - 1] = document.getElementById(i.toString()).value;
    }
    alert(map);
}