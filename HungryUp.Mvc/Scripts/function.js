function countdown(elementName, dateNow, hourComplete, functionExpiredTime) {
    var now = new Date();
    var dateNowSplit = dateNow.split(':');
    now.setHours(parseInt(dateNowSplit[0]), parseInt(dateNowSplit[1]), parseInt(dateNowSplit[2]));
    var nowCountDownDate = now.getTime();

    var date = new Date();
    var dateSplit = hourComplete.split(':');
    date.setHours(parseInt(dateSplit[0]), parseInt(dateSplit[1]), parseInt(dateSplit[2]));
    var countDownDate = date.getTime();

    // Update the count down every 1 second
    var x = setInterval(function () {

        // Find the distance between now an the count down date
        var distance = countDownDate - nowCountDownDate;
        
        now.setSeconds(now.getSeconds() + 1);
        nowCountDownDate = now.getTime();

        // Time calculations for days, hours, minutes and seconds
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);

        // Display the result in the element with id="demo"
        document.getElementById(elementName).innerHTML = twoDigits(hours) + ":"
        + twoDigits(minutes) + ":" + twoDigits(seconds);

        // If the count down is finished, write some text 
        if (distance < 1) {
            clearInterval(x);
            functionExpiredTime();
        }
    }, 1000);
}

function twoDigits(n) {
    return (n <= 9 ? "0" + n : n);
}